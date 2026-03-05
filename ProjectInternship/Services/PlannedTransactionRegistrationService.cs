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
    private readonly PlannedTransactionDetailService _detailService;

    public PlannedTransactionRegistrationService(PlannedTransactionDetailService detailService,
        PlannedTransactionDbContext context)
    {
        _context = context;
        _detailService = detailService;
    }

    // =============================
    // CHECK EXIST HEADER
    // =============================

    public async Task<bool> IsExist(decimal? denpyono)
    {
        return await _context.PlannedTransactions
            .AnyAsync(x => x.Denpyono == denpyono);
    }

    // =============================
    // CREATE NEW HEADER MODEL
    // =============================

    public async Task<PlannedTransactionRegistrationVM> CreateNewAsync()
    {
        var maxNo = await _context.PlannedTransactions
            .Select(x => (int?)x.Denpyono)
            .MaxAsync() ?? 0;

        return new PlannedTransactionRegistrationVM
        {
            Denpyono = maxNo + 1,
            Denpyodt = DateTime.Now,
            IsCreated = false
        };
    }

    // =============================
    // GET HEADER DATA
    // =============================

    public async Task<PlannedTransactionRegistrationVM?> GetHeaderDataAsync(decimal? denpyono, bool? isCreated)
    {
        if (denpyono == null) return null;

        var header = await _context.PlannedTransactions
            .Include(x => x.Bumon)
            .FirstOrDefaultAsync(x => x.Denpyono == denpyono);

        if (header == null) return null;

        return new PlannedTransactionRegistrationVM
        {
            Denpyono = header.Denpyono,
            Denpyodt = header.Denpyodt,
            Suitokb = header.Suitokb,
            Shiharaidt = header.Shiharaidt,
            Kaikeind = header.Kaikeind,
            Uketukedt = header.Uketukedt,
            BumoncdYkanr = header.BumoncdYkanr,
            BumoncdName = header.Bumon?.BumonName,
            Biko = header.Biko,
            IsCreated = true
        };
    }

    public async Task<(decimal? id, bool isUpdate)> RegisterAsync(
    PlannedTransactionRegistrationVM model)
    {
        // =========================
        // GET OR CREATE HEADER
        // =========================

        var header = await _context.PlannedTransactions
            .FirstOrDefaultAsync(x =>
                x.Denpyono == model.Denpyono);

        bool isUpdate = header != null;
        if (!isUpdate)
        {
            header = new PlannedTransaction
            {
                Denpyono = model.Denpyono,
                InsertDate = DateTime.Now,
                InsertOpeId = "SYSTEM",
                InsertPgmPrm = "00000",
                InsertPgmId = "PlannedTransactionRegistration"
            };

            _context.PlannedTransactions.Add(header);
        }

        // =========================
        // UPDATE HEADER
        // =========================

        header.Kaikeind = model.Kaikeind;
        header.Denpyodt = DateTime.Now;
        header.Uketukedt = model.Uketukedt;
        header.Shiharaidt = model.Shiharaidt;
        header.BumoncdYkanr = model.BumoncdYkanr;
        header.Suitokb = model.Suitokb;
        header.Biko = model.Biko;

        header.UpdateDate = DateTime.Now;
        header.UpdateOpeId = "SYSTEM";
        header.UpdatePgmPrm = "00000";
        header.UpdatePgmId = "PlannedTransactionRegistration";

        await _context.SaveChangesAsync();

        // =========================
        // HANDLE DETAILS
        // =========================

        if (model.Results != null)
        {
            foreach (var item in model.Results)
            {
                var exists =
                    await _detailService
                        .IsExistAsync(item.Denpyono, item.Gyono);

                if (item.IsCheckedToDelete)
                {
                    if (exists)
                    {
                        await _detailService
                            .DeleteAsync(item.Denpyono, item.Gyono);
                    }

                    continue;
                }

                if (exists)
                {
                    var updateEntity = new PlannedTransactionDetailVM
                    {
                        Denpyono = item.Denpyono,
                        Gyono = item.Gyono,
                        Idodt = item.Idodt,
                        ShuppatsuPlc = item.ShuppatsuPlc,
                        MokutekiPlc = item.MokutekiPlc,
                        Keiro = item.Keiro,
                        Kingaku = item.Kingaku,
                        UpdateOpeId = "SYSTEM",
                        UpdatePgmPrm = "Admin",
                        UpdateDate = DateTime.Now
                    };

                    await _detailService.UpdateAsync(updateEntity);
                }
                else
                {
                    var insertEntity = new PlannedTransactionDetailVM
                    {
                        Denpyono = item.Denpyono,
                        Gyono = item.Gyono,
                        Idodt = item.Idodt,
                        ShuppatsuPlc = item.ShuppatsuPlc,
                        MokutekiPlc = item.MokutekiPlc,
                        Keiro = item.Keiro,
                        Kingaku = item.Kingaku,
                        InsertOpeId = "SYSTEM",
                        InsertPgmId = "Admin",
                        InsertDate = DateTime.Now
                    };

                    await _detailService.InsertAsync(insertEntity);
                }
            }
        }

        await _context.SaveChangesAsync();

        return (header.Denpyono, isUpdate);
    }



    // =========================
    // Delete data by denpyono
    // =========================

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
        await _context.SaveChangesAsync();

        _context.PlannedTransactions.Remove(header);

        await _context.SaveChangesAsync();
    }
    // ================================================================
    // Get data from Meisai table by denpyono and set to model.Results
    // ================================================================
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
                Idodt = x.Idodt,
                ShuppatsuPlc = x.ShuppatsuPlc,
                MokutekiPlc = x.MokutekiPlc,
                Keiro = x.Keiro,
                IsCheckedToDelete = false
            })

            .ToListAsync();
    }
}