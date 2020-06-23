using System;
using System.Collections.Generic;

namespace IZ.Model.DBModels
{
    public partial class IzvjestajElementi
    {
        public int IzvjestajElementiId { get; set; }
        public int? IzvjestajDefinicijaId { get; set; }
        public string Element { get; set; }
        public string ElementVrijednosti { get; set; }
        public byte Status { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime? DatumAzuriranja { get; set; }
        public string KorisnikUnosa { get; set; }
        public string KorisnikAzurirao { get; set; }

       

        public virtual IzvjestajDefinicija IzvjestajDefinicija { get; set; }
    }
}
