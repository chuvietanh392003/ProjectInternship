using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;
using ProjectInternship.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.Services;

public class PlannedTransactionRegistrationService
{
    private readonly PlannedTransactionDbContext _context;
    private readonly PlanTransactionDetailService _detailService;

    public PlannedTransactionRegistrationService(PlanTransactionDetailService detailService,
        PlannedTransactionDbContext context)
    {
        _context = context;
        _detailService = detailService;
    }

    public async Task<bool> IsExist(decimal? denpyono)
    {
        return await _context.PlannedTransactions
            .AnyAsync(x => x.Denpyono == denpyono);
    }

    public async Task<decimal?> RegisterAsync(
        PlannedTransactionRegistrationVM model)
    {
        //foreach (var item in model.Results)
        //{
        //    if (item.isCheckedToDelete == true)
        //    {
        //        await _detailService.DeleteAsync(item.Denpyono, item.Gyono);
        //    }
        //    else
        //    {
        //        if (await _detailService.IsExistAsync(item.Denpyono, item.Gyono))
        //        {
        //            var existItemPlannedTransactionDetail = new PlannedTransactionDetail
        //            {
        //                Denpyono = item.Denpyono,
        //                Gyono = item.Gyono,
        //                Idodt = item.Idodt,
        //                ShuppatsuPlc = item.ShuppatsuPlc,
        //                MokutekiPlc = item.MokutekiPlc,
        //                Keiro = item.Keiro,
        //                Kingaku = item.Kingaku,
        //                UpdateOpeId = "SYSTEM",
        //                UpdatePgmPrm = "Admin",
        //                UpdateDate = DateTime.Now
        //            };
        //            await _detailService.UpdateAsync(existItemPlannedTransactionDetail);
        //        }
        //        else
        //        {
        //            var newItemPlannedTransactionDetail = new PlannedTransactionDetail
        //            {
        //                Denpyono = item.Denpyono,
        //                Gyono = item.Gyono,
        //                Idodt = item.Idodt,
        //                ShuppatsuPlc = item.ShuppatsuPlc,
        //                MokutekiPlc = item.MokutekiPlc,
        //                Keiro = item.Keiro,
        //                Kingaku = item.Kingaku,
        //                InsertOpeId = "SYSTEM",
        //                InsertPgmId = "Admin",
        //                InsertDate = DateTime.Now
        //            };

        //            await _detailService.InsertAsync(newItemPlannedTransactionDetail);
        //        }
        //    }
        //}
        var maxNo =
            await _context.PlannedTransactions
                .Select(x => (int?)x.Denpyono)
                .MaxAsync() ?? 0;

        var header
            =
            await _context.PlannedTransactions
            .FirstOrDefaultAsync(x =>
                x.Denpyono == model.Denpyono);

        if (header == null)
        {
            header = new PlannedTransaction
            {
                Denpyono =
                    model.Denpyono ?? maxNo + 1,

                InsertDate = DateTime.Now,
                InsertOpeId = "SYSTEM",
                InsertPgmId =
                "PlannedTransactionRegistration"
            };

            _context.PlannedTransactions.Add(header);
        }

        header.Kaikeind = model.Kaikeind;
        header.Denpyodt = DateTime.Now;
        header.Uketukedt = model.Uketukedt;
        header.Shiharaidt = model.Shiharaidt;
        header.BumoncdYkanr = model.BumoncdYkanr;
        header.Suitokb = model.Suitokb;
        header.Biko = model.Biko;

        header.UpdateDate = DateTime.Now;
        header.UpdateOpeId = "SYSTEM";
        header.UpdatePgmId =
            "PlannedTransactionRegistration";

        await SaveDetails(header.Denpyono, model);

        await _context.SaveChangesAsync();

        return header.Denpyono;
    }


    private async Task SaveDetails(
    decimal? denpyono,
    PlannedTransactionRegistrationVM model)
    {
        if (model.Results == null) return;
        Console.WriteLine(model.Results);

        foreach (var detail in model.Results)
        {
            var exist =
                await _context.TransactionDetails
                .FirstOrDefaultAsync(x =>
                    x.Denpyono == denpyono &&
                    x.Gyono == detail.Gyono);

            // ===== UPDATE ONLY =====
            if (exist != null)
            {
                exist.Idodt = detail.Idodt;
                exist.ShuppatsuPlc = detail.ShuppatsuPlc;
                exist.MokutekiPlc = detail.MokutekiPlc;
                exist.Keiro = detail.Keiro;
                exist.Kingaku = detail.Kingaku;

                exist.UpdateDate = DateTime.Now;
            }
            else
            {
                // nếu chưa có  ADD 
                _context.TransactionDetails.Add(
                    new PlannedTransactionDetail
                    {
                        Denpyono = denpyono,
                        Gyono = detail.Gyono,

                        Idodt = detail.Idodt,
                        ShuppatsuPlc = detail.ShuppatsuPlc,
                        MokutekiPlc = detail.MokutekiPlc,
                        Keiro = detail.Keiro,
                        Kingaku = detail.Kingaku,

                        InsertDate = DateTime.Now
                    });
            }
        }
    }


    public async Task DeleteAsync(decimal? denpyono)
    {
        var header =
            await _context.PlannedTransactions
            .FirstOrDefaultAsync(x =>
                x.Denpyono == denpyono);

        if (header == null) return;

        var details =
            _context.TransactionDetails
            .Where(x =>
                x.Denpyono == denpyono);

        _context.TransactionDetails
            .RemoveRange(details);

        _context.PlannedTransactions.Remove(header);

        await _context.SaveChangesAsync();
    }


    public async Task LoadDetails(
    PlannedTransactionRegistrationVM model)
    {
        model.Results =
            await _context.TransactionDetails
            .Where(x =>
                x.Denpyono == model.Denpyono)

            .Select(x => new PlannedTransactionDetailVM
            {
                Denpyono = x.Denpyono,
                Gyono = x.Gyono,
                Kingaku = x.Kingaku,
                isCheckedToDelete = false
            })

            .ToListAsync();
    }

    public async Task<decimal?> GetNextGyonoAsync(decimal? denpyono)
    {
        var maxGyono =
            await _context.TransactionDetails
            .Where(x => x.Denpyono == denpyono)
            .Select(x => x.Gyono)
            .MaxAsync();

        return (maxGyono ?? 0) + 1;
    }
}