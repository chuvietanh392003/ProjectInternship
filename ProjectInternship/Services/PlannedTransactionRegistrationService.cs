using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Services;

public class PlannedTransactionRegistrationService
{
    private readonly PlannedTransactionDbContext _context;

    public PlannedTransactionRegistrationService(
        PlannedTransactionDbContext context)
    {
        _context = context;
    }

    public async Task<decimal?> RegisterAsync(
        PlannedTransactionRegistrationVM model)
    {
        var maxNo =
            await _context.PlannedTransactions
                .Select(x => (int?)x.Denpyono)
                .MaxAsync() ?? 0;

        var maxGyono =
            await _context.TransactionDetails
                .Select(x => (int?)x.Denpyono)
                .MaxAsync() ?? 0;

        var header =
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

        foreach (var detail in model.Results)
        {
            var exist =
                await _context.TransactionDetails
                .FirstOrDefaultAsync(x =>
                    x.Denpyono == denpyono &&
                    x.Gyono == detail.Gyono);

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
                _context.TransactionDetails.Add(
                    new PlannedTransactionDetail
                    {
                        Denpyono = denpyono,
                        Gyono = detail.Gyono,

                        Idodt = detail.Idodt,
                        ShuppatsuPlc =
                            detail.ShuppatsuPlc,
                        MokutekiPlc =
                            detail.MokutekiPlc,
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
            .ToListAsync();

        model.TotalKingaku =
            model.Results
            .Where(x => x.Kingaku.HasValue)
            .Sum(x => x.Kingaku.Value);
    }
}