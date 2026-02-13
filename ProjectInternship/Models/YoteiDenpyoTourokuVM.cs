namespace ProjectInternship.Models
{
    public class YoteiDenpyoTourokuVM
    {
        public long? Kaikeind { get; set; }
        public long? Denpyono { get; set; }
        public DateTime? Denpyodt { get; set; }

        public String? Suitokb { get; set; }

        public DateTime? Shiharaidt { get; set; }

        public DateTime? Uketukedt { get; set; }

        public String? BumoncdYkanr{  get; set; }
        public String? BumoncdName { get; set; }
        public String? Biko { get; set; }

        public Boolean isCreated { get; set; }

       
        public List<YoteiDenpyoTourokuVM>? Results { get; set; }
    }

}
