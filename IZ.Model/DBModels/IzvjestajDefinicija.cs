using System;
using System.Collections.Generic;

namespace IZ.Model.DBModels
{
    public partial class IzvjestajDefinicija
    {
        public IzvjestajDefinicija()
        {
            IzvjestajElementi = new HashSet<IzvjestajElementi>();
            IzvjestajiGenerisani = new HashSet<IzvjestajiGenerisani>();
        }

        public int IzvjestajDefinicijaId { get; set; }
        public int? IzvjestajTipId { get; set; }
        public int? IzvjestajXsdshemaiId { get; set; }
        public string KratkiNaziv { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte Status { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime? DatumAzuriranja { get; set; }
        public string KorisnikUnosa { get; set; }
        public string KorisnikAzurirao { get; set; }

        public virtual IzvjestajTip IzvjestajTip { get; set; }
        public virtual IzvjestajXsdshema IzvjestajXsdshemai { get; set; }
        public virtual ICollection<IzvjestajElementi> IzvjestajElementi { get; set; }
        public virtual ICollection<IzvjestajiGenerisani> IzvjestajiGenerisani { get; set; }
    }
}
