using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Services;

public class PlannedTransactionService
{
    private readonly PlannedTransactionDbContext _context;

    public PlannedTransactionService(
        PlannedTransactionDbContext context)
    {
        _context = context;
    }

    public async Task<ResultVM<PlannedTransactionSearchVM>>
     SearchAsync(PlannedTransactionSearchVM model)
    {
        var query = _context.PlannedTransactions
            .AsNoTracking()
            .Include(x => x.Bumon)
            .AsQueryable();

        if (model.Kaikeind.HasValue)
        {
            query = query.Where(x =>
                x.Kaikeind == model.Kaikeind);
        }
        if(model.DenpyonoFrom > model.DenpyonoTo)
        {
            return ResultVM<PlannedTransactionSearchVM>.Fail("伝票番号が無効です");
        }
        if (model.DenpyonoFrom.HasValue)
        {
            query = query.Where(x =>
                x.Denpyono >= model.DenpyonoFrom);
        }

        if (model.DenpyonoTo.HasValue)
        {
            query = query.Where(x =>
                x.Denpyono <= model.DenpyonoTo);
        }

        if (model.UketukedtFrom.HasValue)
        {
            query = query.Where(x =>
                x.Uketukedt >= model.UketukedtFrom);
        }

        if (model.UketukedtTo.HasValue)
        {
            query = query.Where(x =>
                x.Uketukedt <= model.UketukedtTo);
        }

        if (model.DenpyodtFrom.HasValue)
        {
            query = query.Where(x =>
                x.Denpyodt >= model.DenpyodtFrom);
        }

        if (model.DenpyodtTo.HasValue)
        {
            query = query.Where(x =>
                x.Denpyodt <= model.DenpyodtTo);
        }

        // suitokb filter
        if (!string.IsNullOrEmpty(model.Suitofuri)
            && !string.IsNullOrEmpty(model.Genkin))
        {
            query = query.Where(x =>
                x.Suitokb == "振込"
                || x.Suitokb == "現金");
        }
        else if (!string.IsNullOrEmpty(model.Suitofuri))
        {
            query = query.Where(x =>
                x.Suitokb == "振込");
        }
        else if (!string.IsNullOrEmpty(model.Genkin))
        {
            query = query.Where(x =>
                x.Suitokb == "現金");
        }

        model.Results = await query.ToListAsync();

        model.TotalKingaku =
            model.Results
                .Where(x => x.Kingaku.HasValue)
                .Sum(x => x.Kingaku.Value);

        return ResultVM<PlannedTransactionSearchVM>.Successful(model); 
    }
}