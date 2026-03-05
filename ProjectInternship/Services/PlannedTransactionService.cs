using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    public async Task<PlannedTransactionSearchVM>
SearchAsync(PlannedTransactionSearchVM model)
    {
        var query = _context.PlannedTransactions
            .AsNoTracking()
            .Include(x => x.Bumon)
            .AsQueryable();

        if (model.Kaikeind.HasValue)
            query = query.Where(x =>
                x.Kaikeind == model.Kaikeind);

        if (model.DenpyonoFrom.HasValue)
            query = query.Where(x =>
                x.Denpyono >= model.DenpyonoFrom);

        if (model.DenpyonoTo.HasValue)
            query = query.Where(x =>
                x.Denpyono <= model.DenpyonoTo);

        if (model.UketukedtFrom.HasValue)
            query = query.Where(x =>
                x.Uketukedt >= model.UketukedtFrom);

        if (model.UketukedtTo.HasValue)
        {
            var toDate = model.UketukedtTo.Value.Date.AddDays(1);
            query = query.Where(x =>
                x.Uketukedt <= toDate);
        }
            

        if (model.DenpyodtFrom.HasValue)
            query = query.Where(x =>
                x.Denpyodt >= model.DenpyodtFrom);

        if (model.DenpyodtTo.HasValue)
        {
            var toDate = model.DenpyodtTo.Value.Date.AddDays(1);
            query = query.Where(x =>
                x.Denpyodt <= toDate);
        }
            

        // suitokb filter
        if (model.Suitofuri == ("false")
            && model.Genkin == ("false"))
        {
            query = query.Where(x =>
                x.Suitokb == "振込"
                || x.Suitokb == "現金");
        }
        else if (model.Genkin == ("false"))
        {
            query = query.Where(x =>
                x.Suitokb == "振込");
        }
        else if (model.Suitofuri == ("false"))
        {
            query = query.Where(x =>
                x.Suitokb == "現金");
        }
        else
        {
            query = query.Where(x =>
                x.Suitokb == "振込"
                || x.Suitokb == "現金");
        }

        model.Results = await query.ToListAsync();

        model.TotalKingaku =
            model.Results
                .Where(x => x.Kingaku.HasValue)
                .Sum(x => x.Kingaku.Value);

        return model; 
    }
}