using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;

namespace ProjectInternship.Services;

public class PlanTransactionDetailService
{
    private readonly PlannedTransactionDbContext _context;

    public PlanTransactionDetailService(
        PlannedTransactionDbContext context)
    {
        _context = context;
    }


    // =============================
    // GET DETAIL
    // =============================

    public async Task<List<PlannedTransactionDetail>>
    GetByDenpyonoAsync(decimal? denpyono)
    {
        return await _context.TransactionDetails

            .Where(x => x.Denpyono == denpyono)

            .OrderBy(x => x.Gyono)

            .ToListAsync();
    }



    // =============================
    // INSERT
    // =============================

    public async Task InsertAsync(
        PlannedTransactionDetail detail)
    {
        detail.InsertDate = DateTime.Now;

        _context.TransactionDetails.Add(detail);

        await _context.SaveChangesAsync();
    }



    // =============================
    // UPDATE
    // =============================

    public async Task UpdateAsync(
        PlannedTransactionDetail model)
    {
        var exist =
            await _context.TransactionDetails
            .FirstOrDefaultAsync(x =>

                x.Denpyono == model.Denpyono
                &&
                x.Gyono == model.Gyono
            );

        if (exist == null) return;


        exist.Idodt = model.Idodt;
        exist.ShuppatsuPlc = model.ShuppatsuPlc;
        exist.MokutekiPlc = model.MokutekiPlc;
        exist.Keiro = model.Keiro;
        exist.Kingaku = model.Kingaku;

        exist.UpdateDate = DateTime.Now;

        await _context.SaveChangesAsync();
    }



    // =============================
    // DELETE 1 DETAIL
    // =============================

    public async Task DeleteAsync(
        decimal? denpyono,
        decimal? gyono)
    {
        var exist =
            await _context.TransactionDetails
            .FirstOrDefaultAsync(x =>

                x.Denpyono == denpyono
                &&
                x.Gyono == gyono
            );

        if (exist == null) return;

        _context.TransactionDetails.Remove(exist);

        await _context.SaveChangesAsync();
    }



    // =============================
    // DELETE ALL DETAIL
    // =============================

    public async Task DeleteAllAsync(
        decimal? denpyono)
    {

        var list =
            await _context.TransactionDetails

            .Where(x =>
                x.Denpyono == denpyono)

            .ToListAsync();


        _context.TransactionDetails
            .RemoveRange(list);

        await _context.SaveChangesAsync();
    }
}