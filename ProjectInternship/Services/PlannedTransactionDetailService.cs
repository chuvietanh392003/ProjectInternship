/**
 * ---------------------------------------------
 * Class Name : PlannedTransactionDetailService
 * Description:
 *     Service class for handling Planned
 *     Transaction Detail (予定伝票明細) operations.
 *
 *     Provides methods to:
 *         - Retrieve detail records by Denpyono or Gyono
 *         - Create new detail model
 *         - Check existence of a detail record
 *         - Insert, update, and delete detail records
 *
 *     Uses Entity Framework Core to interact
 *     with TransactionDetails table.
 * ---------------------------------------------
 */
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Services;

public class PlannedTransactionDetailService
{
    private readonly PlannedTransactionDbContext _context;

    public PlannedTransactionDetailService(
        PlannedTransactionDbContext context)
    {
        _context = context;
    }

    // =============================
    // GET DETAILS BY DENPYONO
    // =============================

    public async Task<List<PlannedTransactionDetailVM>>
    GetByDenpyonoAsync(decimal? denpyono)
    {
        return await _context.TransactionDetails
            .Where(x => x.Denpyono == denpyono)
            .OrderBy(x => x.Gyono)
            .Select(x => new PlannedTransactionDetailVM
            {
                Denpyono = x.Denpyono,
                Gyono = x.Gyono,
                Idodt = x.Idodt,
                ShuppatsuPlc = x.ShuppatsuPlc,
                MokutekiPlc = x.MokutekiPlc,
                Keiro = x.Keiro,
                Kingaku = x.Kingaku,
                IsCheckedToDelete = false,
            })
            .ToListAsync();
    }


    // =============================
    // GET DETAIL BY GYONO
    // =============================

    public async Task<PlannedTransactionDetailVM?>
    GetByGyonoAsync(decimal? denpyono, decimal? gyono, bool? isCreated)
    {
        return await _context.TransactionDetails
            .Where(x => x.Denpyono == denpyono && x.Gyono == gyono)
            .Select(x => new PlannedTransactionDetailVM
            {
                Denpyono = x.Denpyono,
                Gyono = x.Gyono,
                Idodt = x.Idodt,
                ShuppatsuPlc = x.ShuppatsuPlc,
                MokutekiPlc = x.MokutekiPlc,
                Keiro = x.Keiro,
                Kingaku = x.Kingaku,
                IsCheckedToDelete = false,
                IsCreated = isCreated
            })
            .FirstOrDefaultAsync();
    }

    // =============================
    // Gen newmodel
    // =============================

    public async Task<PlannedTransactionDetailVM?>
    GenNewModelAsync(decimal? denpyono, decimal? gyono, bool? isCreated)
    {
        var newDatailModel = new PlannedTransactionDetailVM
        {
            Denpyono = denpyono,
            Gyono = gyono,
            IsCreated = false
        };
        return newDatailModel;
    }


    // =============================
    // CHECK EXIST
    // =============================

    public async Task<bool> IsExistAsync(
        decimal? denpyono,
        decimal? gyono)
    {
        var entity  =  await _context.TransactionDetails
            .FirstOrDefaultAsync(x =>
                x.Denpyono == denpyono &&
                x.Gyono == gyono);
        return entity != null;
    }


    // =============================
    // INSERT
    // =============================

    public async Task InsertAsync(
        PlannedTransactionDetailVM model)
    {
        var entity = new PlannedTransactionDetail
        {
            Denpyono = model.Denpyono,
            Gyono = model.Gyono,
            Idodt = model.Idodt,
            ShuppatsuPlc = model.ShuppatsuPlc,
            MokutekiPlc = model.MokutekiPlc,
            Keiro = model.Keiro,
            Kingaku = model.Kingaku,

            InsertDate = DateTime.Now,
            InsertOpeId = "SYSTEM",
            InsertPgmPrm = "00000",
            InsertPgmId = "TransRg"
        };

        _context.TransactionDetails.Add(entity);

        await _context.SaveChangesAsync();
    }


    // =============================
    // UPDATE
    // =============================

    public async Task UpdateAsync(
        PlannedTransactionDetailVM model)
    {
        var exist = await _context.TransactionDetails
            .FirstOrDefaultAsync(x =>
                x.Denpyono == model.Denpyono &&
                x.Gyono == model.Gyono);
        if (exist == null) return;
        bool isChanged =
       exist.Idodt != model.Idodt ||
       exist.ShuppatsuPlc != model.ShuppatsuPlc ||
       exist.MokutekiPlc != model.MokutekiPlc ||
       exist.Keiro != model.Keiro ||
       exist.Kingaku != model.Kingaku;

        if (!isChanged) return;

        exist.Idodt = model.Idodt;
        exist.ShuppatsuPlc = model.ShuppatsuPlc;
        exist.MokutekiPlc = model.MokutekiPlc;
        exist.Keiro = model.Keiro;
        exist.Kingaku = model.Kingaku;

        exist.UpdateDate = DateTime.Now;
        exist.UpdateOpeId = "SYSTEM";
        exist.UpdatePgmPrm = "00000";
        exist.UpdatePgmId = "TransRg";

        await _context.SaveChangesAsync();
    }

    // =============================
    // DELETE 1 DETAIL
    // =============================

    public async Task DeleteAsync(
        decimal? denpyono,
        decimal? gyono)
    {
        var exist = await _context.TransactionDetails
            .FirstOrDefaultAsync(x =>
                x.Denpyono == denpyono &&
                x.Gyono == gyono);
        if (exist == null) return;
        _context.TransactionDetails.Remove(exist);

        await _context.SaveChangesAsync();
    }
}

   