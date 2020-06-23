using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.Model.VM
{
    public class IzvjestajDefinicijeVM
    {
        public int IzvjestajDefinicijeId { get; set; }
        public string KratkiNaziv { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string NazivXsdSheme { get; set; }

        //Elementi iz IzvjestajElementi

        public string Direktor { get; set; }
        public string OvlasteniAktuar { get; set; }
        public string CertRacunovodja { get; set; }
        public string SastavioImePrezime { get; set; }
    }
}
