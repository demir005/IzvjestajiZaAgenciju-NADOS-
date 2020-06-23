using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IZ.Model.VM
{
    public class GenerisaniIzvjestajiVM
    {
        public int IzvjestajiGenerisaniId { get; set; }
        public int? IzvjestajDefinicijaId { get; set; }
        public int? IzvjestajXsdshemaiId { get; set; }
        public string ShemaXSD { get; set; }
        public string KratkiNazivDefinicijeI { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
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

    }
}
