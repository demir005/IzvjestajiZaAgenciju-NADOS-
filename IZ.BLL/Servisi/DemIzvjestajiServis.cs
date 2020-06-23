using IZ.BLL.Interfejsi;
using IZ.Model.DBModels;
using IZ.Model.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IZ.BLL.Servisi
{
    public class DemIzvjestajiServis : IDemIzvjestaji
    {
        private AppDBContext _context;
        public DemIzvjestajiServis(AppDBContext context)
        {
            _context = context;
        }

        public bool DemirMetodaDemo()
        {
            return true;
        }

        
       /// <summary>
       /// Dropdown menu za Nazive izvjestaja
       /// </summary>
       /// <returns></returns>
        public List<DvojkaVM> VratiDefinicije()
        {
            var def = _context.IzvjestajDefinicija.ToList();
            if (def.Count == 0)
                return null;
            var defVM = new List<DvojkaVM>();
            foreach (var item in def)
            {
                var izvDef = new DvojkaVM();
                izvDef.text1 = item.IzvjestajDefinicijaId.ToString();
                izvDef.text2 = item.KratkiNaziv;
                defVM.Add(izvDef);
            }
            return defVM;
        }

        /// <summary>
        /// Popunjavanje, filtriranje Datatabele
        /// </summary>
        /// <param name="tipId"></param>
        /// <returns></returns>
        public string VratiIzvjestajPoTipu(int tipId)
        {
            var listDb = new List<IzvjestajDefinicija>();
            if (tipId == 0)
                listDb = _context.IzvjestajDefinicija.ToList();
            else
                listDb = _context.IzvjestajDefinicija.Where(x => x.IzvjestajDefinicijaId == tipId).ToList();
            if (listDb.Count == 0)
                return "[]";
            var listM = new List<IzvjestajDefinicijeVM>();
            foreach(var item in listDb)
            {
                var dizv = new IzvjestajDefinicijeVM();
                dizv.IzvjestajDefinicijeId = item.IzvjestajDefinicijaId;
                dizv.KratkiNaziv = item.KratkiNaziv;
                dizv.Naziv = item.Naziv;
                dizv.Opis = item.Opis;
                dizv.NazivXsdSheme = (_context.IzvjestajXsdshema.Where(x => x.IzvjestajXsdshemaiId == item.IzvjestajXsdshemaiId && x.Status == 1).FirstOrDefault()).Shema;
                var elementi = _context.IzvjestajElementi.Where(x => x.IzvjestajDefinicijaId == item.IzvjestajDefinicijaId && x.Status == 1).ToList();
                var direktor = elementi.Where(x => x.Element == "Direktor").FirstOrDefault();
                if (direktor != null)
                    dizv.Direktor = direktor.ElementVrijednosti;
                else
                    dizv.Direktor = "";
                var racunovodja = elementi.Where(x => x.Element == "CertRacunovodja").FirstOrDefault();
                if (racunovodja != null)
                    dizv.CertRacunovodja = racunovodja.ElementVrijednosti;
                else
                    dizv.CertRacunovodja = "";
                var Aktuar = elementi.Where(x => x.Element == "Ovlasteni aktuar").FirstOrDefault();
                if (Aktuar != null)
                    dizv.OvlasteniAktuar = Aktuar.ElementVrijednosti;
                else
                    dizv.OvlasteniAktuar = "";
                var Sastavio = elementi.Where(x => x.Element == "SastavioImePrezime").FirstOrDefault();
                if (Sastavio != null)
                    dizv.SastavioImePrezime = Sastavio.ElementVrijednosti;
                else
                    dizv.SastavioImePrezime = "";
                listM.Add(dizv);
            }
            var lista = "";
            lista = JsonConvert.SerializeObject(listM.OrderByDescending(x => x.KratkiNaziv).ToList(), Newtonsoft.Json.Formatting.None);
            return lista;

        }

        /// <summary>
        /// Dropdown za Tipove Izvjestaja (mjesecni, kvartalni, godisnji)
        /// </summary>
        /// <returns></returns>
        public List<DvojkaVM> VratiTipove()
        {
            var lista = _context.IzvjestajTip.ToList();
            if (lista.Count == 0)
                return null;
            var listaVM = new List<DvojkaVM>();
            foreach (var i in lista)
            {
                var tipVM = new DvojkaVM();
                tipVM.text1 = i.IzvjestajTipId.ToString();
                tipVM.text2 = i.Naziv;
                listaVM.Add(tipVM);
            }
            return listaVM;
        }
    }
}
