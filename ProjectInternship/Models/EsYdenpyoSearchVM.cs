namespace ProjectInternship.Models
{
    public class EsYdenpyoSearchVM
    {
        public long? Kaikeind { get; set; }
        public long? DenpyonoFrom { get; set; }
        public long? DenpyonoTo { get; set; }

        public DateTime? DenpyodtFrom { get; set; }
        public DateTime? DenpyodtTo { get; set; }

        public DateTime? UketukedtFrom { get; set; }
        public DateTime? UketukedtTo { get; set; }

        public String? Suitofuri { get; set; }
        public String? Genkin { get; set; }
       
        public decimal? TotalKingaku { get; set; }
        public List<EsYdenpyo>? Results { get; set; }
    }

}
