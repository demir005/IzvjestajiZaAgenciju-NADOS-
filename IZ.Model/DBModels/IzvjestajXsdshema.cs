using System;
using System.Collections.Generic;

namespace IZ.Model.DBModels
{
    public partial class IzvjestajXsdshema
    {
        public IzvjestajXsdshema()
        {
            IzvjestajDefinicija = new HashSet<IzvjestajDefinicija>();
            IzvjestajiGenerisani = new HashSet<IzvjestajiGenerisani>();
        }

        public int IzvjestajXsdshemaiId { get; set; }
        public string Shema { get; set; }
        public byte Status { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime? DatumAzuriranja { get; set; }
        public string KorisnikUnosa { get; set; }
        public string KorisnikAzurirao { get; set; }
        public string HederXls { get; set; }

        public virtual ICollection<IzvjestajDefinicija> IzvjestajDefinicija { get; set; }
        public virtual ICollection<IzvjestajiGenerisani> IzvjestajiGenerisani { get; set; }
    }
}
