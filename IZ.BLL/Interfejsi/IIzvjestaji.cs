using IZ.Model.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.BLL.Interfejsi
{
    public interface IIzvjestaji
    {
        public List<DvojkaVM> VratiSeme();
        public string VratiSemu(int semaId);
        bool GenerisiIzvjestaj(int semaId, string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajla);
        ListaSveVM VratiGenIzvjestaje();
        public string VratiIzvjestajePo3Parametra(string datumOd, string datumDo, string definicijaId);
        public DvojkaVM VratiXML(int Id);
        public bool Obrisi(int Id);
        public string VratiIzvjestajePoTipu(int tipId);
        public List<DvojkaVM> VratiTipoveIzvjestaja();
    }
}
