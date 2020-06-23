using System;
using System.Collections.Generic;

namespace IZ.Model.DBModels
{
    public partial class IzvjestajiGenerisani
    {
        public int IzvjestajiGenerisaniId { get; set; }
        public int? IzvjestajDefinicijaId { get; set; }
        public int? IzvjestajXsdshemaiId { get; set; }
        public string Izvjestaj { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string ImportedExcel { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public byte Status { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime? DatumAzuriranja { get; set; }
        public string KorisnikUnosa { get; set; }
        public string KorisnikAzurirao { get; set; }
        public string NazivXmlfajla { get; set; }

        public virtual IzvjestajDefinicija IzvjestajDefinicija { get; set; }
        public virtual IzvjestajXsdshema IzvjestajXsdshemai { get; set; }
    }
}
