using IZ.BLL.Interfejsi;
using IZ.Model.DBModels;
using IZ.Model.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using IZ.Model.ModeliXML;
using IZ.Model.ModeliXML._1LMF;
using IZ.Model.ModeliXML._2MF;

namespace IZ.BLL.Servisi
{
    public class IzvjestajiServis : IIzvjestaji
    {
        private AppDBContext _context;
        public IzvjestajiServis(AppDBContext context)
        {
            _context = context;
        }
        public List<DvojkaVM> VratiSeme()
        {
            var list = _context.IzvjestajDefinicija.Where(x => x.Status == 1).ToList();
            if (list.Count == 0)
                return null;
            var lista = "";
            var listaVM = new List<DvojkaVM>();
            foreach (var i in list)
            {
                var dvojkaVM = new DvojkaVM();
                dvojkaVM.text1 = i.IzvjestajDefinicijaId.ToString();
                dvojkaVM.text2 = i.KratkiNaziv;
                listaVM.Add(dvojkaVM);
            }
            lista = JsonConvert.SerializeObject(listaVM, Newtonsoft.Json.Formatting.None);
            return listaVM;
        }
        public string VratiSemu(int izvjestajId)
        {
            var izvjestaj = _context.IzvjestajDefinicija.Where(x => x.IzvjestajDefinicijaId == izvjestajId).FirstOrDefault();
            if (izvjestaj == null)
                return null;
            var semaId = izvjestaj.IzvjestajXsdshemaiId;
            var semaDB = _context.IzvjestajXsdshema.Where(x => x.IzvjestajXsdshemaiId == semaId).FirstOrDefault();
            var sema = semaDB.HederXls.Trim();
            var s = "";
            s = JsonConvert.SerializeObject(sema, Newtonsoft.Json.Formatting.None);
            return s;
        }
        public ListaSveVM VratiGenIzvjestaje()
        {
            var listaDb = _context.IzvjestajiGenerisani.Where(x => x.Status == 1).ToList().OrderByDescending(x => x.IzvjestajiGenerisaniId);
            var listaM = new List<GenerisaniIzvjestajiVM>();

            foreach (var i in listaDb)
            {
                var novizv = new GenerisaniIzvjestajiVM();
                novizv.IzvjestajiGenerisaniId = i.IzvjestajiGenerisaniId;
                novizv.DatumKreiranja = i.DatumKreiranja;
                novizv.NazivXmlfajla = i.NazivXmlfajla;
                novizv.ImportedExcel = i.ImportedExcel;
                novizv.KratkiNazivDefinicijeI = (_context.IzvjestajDefinicija.Where(x => x.IzvjestajDefinicijaId == i.IzvjestajDefinicijaId && x.Status == 1).FirstOrDefault()).KratkiNaziv;
                listaM.Add(novizv);
            }

            var lista = "";
            lista = JsonConvert.SerializeObject(listaM, Newtonsoft.Json.Formatting.None);
            var listaVM = new ListaSveVM();
            listaVM.sve = lista;
            return listaVM;
        }
        public DvojkaVM VratiXML(int Id)
        {
            var izvjestaj = _context.IzvjestajiGenerisani.Where(x => x.IzvjestajiGenerisaniId == Id).FirstOrDefault();
            var dvojka = new DvojkaVM();
            dvojka.text1 = izvjestaj.NazivXmlfajla;
            dvojka.text2 = "<?xml version='1.0' encoding='UTF-16' standalone='yes'?>" + izvjestaj.Izvjestaj;
            return dvojka;
        }
        public bool Obrisi(int Id)
        {
            try
            {
                var izvjestaj = _context.IzvjestajiGenerisani.Where(x => x.IzvjestajiGenerisaniId == Id).FirstOrDefault();
                izvjestaj.Status = 0;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DvojkaVM> VratiTipoveIzvjestaja()
        {
            var izv = _context.IzvjestajTip.ToList();
            if (izv.Count == 0)
                return null;
            var Lista = new List<DvojkaVM>();
            foreach (var i in izv)
            {
                var dv = new DvojkaVM();
                dv.text1 = i.IzvjestajTipId.ToString();
                dv.text2 = i.Naziv;
                Lista.Add(dv);
            }
            //var lista = "";
           // lista = JsonConvert.SerializeObject(Lista, Newtonsoft.Json.Formatting.None);
            return Lista;
        }
        public string VratiIzvjestajePoTipu(int tipId)
        {
            var izv = _context.IzvjestajDefinicija.Where(x => x.IzvjestajTipId == tipId && x.Status == 1).ToList();
            if (izv.Count == 0)
                return null;
            var Lista = new List<DvojkaVM>();
            foreach(var i in izv)
            {
                var dv = new DvojkaVM();
                dv.text1 = i.IzvjestajDefinicijaId.ToString();
                dv.text2 = i.KratkiNaziv;
                Lista.Add(dv);
            }
            var lista = "";
            lista = JsonConvert.SerializeObject(Lista, Newtonsoft.Json.Formatting.None);
            return lista;
        }
        public string VratiIzvjestajePo3Parametra(string datumOd, string datumDo, string definicijaId)
        {
            int defId = 0;
            
            var listaDb = new List<IzvjestajiGenerisani>();
            var listaM = new List<GenerisaniIzvjestajiVM>();
            DateTime datOd = Convert.ToDateTime("1900-01-01");
            DateTime datDo = Convert.ToDateTime("2050-01-01");
            if (definicijaId != null && definicijaId != "")
              defId = Convert.ToInt32(definicijaId);
            if (datumOd != null && datumOd != "")
                datOd = Convert.ToDateTime(datumOd);
            if (datumDo != null && datumDo != "")
                datDo = Convert.ToDateTime(datumDo);
            if (definicijaId != null && definicijaId != "")
                listaDb = _context.IzvjestajiGenerisani.Where(x => x.IzvjestajDefinicijaId == defId && x.Status == 1 && x.DatumKreiranja > datOd && x.DatumKreiranja < datDo).ToList();//OrderByDescending(x => x.IzvjestajiGenerisaniId);
            else
                listaDb = _context.IzvjestajiGenerisani.Where(x => x.Status == 1 && x.DatumKreiranja > datOd && x.DatumKreiranja < datDo).ToList();
            if (listaDb.Count == 0)
                return "[]";

            foreach (var i in listaDb)
            {
                var novizv = new GenerisaniIzvjestajiVM();               
                novizv.IzvjestajiGenerisaniId = i.IzvjestajiGenerisaniId;
                novizv.DatumKreiranja = i.DatumKreiranja;
                novizv.NazivXmlfajla = i.NazivXmlfajla;
                novizv.ImportedExcel = i.ImportedExcel;
                novizv.KratkiNazivDefinicijeI = (_context.IzvjestajDefinicija.Where(x => x.IzvjestajDefinicijaId == i.IzvjestajDefinicijaId && x.Status == 1).FirstOrDefault()).KratkiNaziv;
                listaM.Add(novizv);
            }

            var lista = "";
            lista = JsonConvert.SerializeObject(listaM, Newtonsoft.Json.Formatting.None);
            return lista;
        }

        #region generisanje izvjestaja
        public bool GenerisiIzvjestaj(int semaId, string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajl)
        {
            if (semaId == 9)
                GenerisiIzvjestaj1LMF(datumOd, datumDo, datumPodnosenja, pod, nazivFajl);
            if (semaId == 10 || semaId == 13)
                GenerisiIzvjestaj2LMF(semaId, datumOd, datumDo, datumPodnosenja, pod, nazivFajl);
            if (semaId == 11)
                GenerisiIzvjestaj1MF(datumOd, datumDo, datumPodnosenja, pod, nazivFajl);
            if (semaId == 12)
                GenerisiIzvjestaj2MF(datumOd, datumDo, datumPodnosenja, pod, nazivFajl);

            return false;
        }
        public bool GenerisiIzvjestaj1LMF(string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajl)
        {
            List<Json5> podaci = JsonConvert.DeserializeObject<List<Json5>>(pod);  //dynamic
            var izvjestajDefinicija = _context.IzvjestajDefinicija.Where(x => x.KratkiNaziv == "1LMF" && x.Status == 1).FirstOrDefault();
            var elementi = _context.IzvjestajElementi.Where(x => x.IzvjestajDefinicijaId == izvjestajDefinicija.IzvjestajDefinicijaId && x.Status == 1).ToList();
            var y = new Model.ModeliXML._1LMF.XMLObrazac();
            var pd = new Model.ModeliXML._1LMF.PodaciDrustva();
            pd.Dokument = new Model.ModeliXML._1LMF.Dokument();

            #region DIO1
            pd.JIBDrustva = "4200326930001";
            pd.Dokument.DatumPodnosenja = datumPodnosenja;
            var Direktor = elementi.Where(x => x.Element == "Direktor").FirstOrDefault();
            if (Direktor != null)
                pd.Dokument.Direktor = Direktor.ElementVrijednosti;
            var Racunovodja = elementi.Where(x => x.Element == "Certificirani racunovodja").FirstOrDefault();
            if (Racunovodja != null)
                pd.Dokument.CertRacunovodja = Racunovodja.ElementVrijednosti;
            var Sastavio = elementi.Where(x => x.Element == "Sastavio").FirstOrDefault();
            if (Sastavio != null)
                pd.Dokument.SastavioImePrezime = Sastavio.ElementVrijednosti;
            pd.Dokument.MjestoPodnosenja = "Sarajevo";
            y.PodaciDrustva = pd;
            var obr = new Model.ModeliXML._1LMF.Obrazac();
            var ps = new Model.ModeliXML._1LMF.Dio1PeriodSifra();
            ps.DatumOd = datumOd;
            ps.DatumDo = datumDo;
            ps.SifraObrasca = "1L-M-F";
            obr.Dio1PeriodSifra = ps; //1
            #endregion DIO1
            #region DIO2
            //------------------------ dio2.1
            var d2 = new Model.ModeliXML._1LMF.Dio2Podaci();
            var podaciLista = new List<Model.ModeliXML._1LMF.Podaci>();
            var podaciKlijent = podaci.Where(x => x.K1 != null && !x.K1.Contains("A.") && !x.K1.Contains("B.") && !x.K1.Contains("C.")).ToList();

            foreach (var p in podaciKlijent)
            {
                var podatak = new Model.ModeliXML._1LMF.Podaci();
                if (p.K3 != null)
                    podatak.AOP = p.K3.Replace(",", "");
                else
                    podatak.AOP = "0";
                if (p.K4 != null)
                    podatak.IznosNezivot = p.K4.Replace(",", "");
                else
                    podatak.IznosNezivot = "0";
                if (p.K5 != null)
                    podatak.IznosZivot = p.K5.Replace(",", "");
                else
                    podatak.IznosZivot = "0";
                podaciLista.Add(podatak);

            }

            d2.Podaci = podaciLista;
            obr.Dio2Podaci = d2;
            #endregion DIO2

            y.Obrazac = obr; //kraj dodaj obrazac u obrazac
            var lista = JsonConvert.SerializeObject(y, Newtonsoft.Json.Formatting.None);


            XNode node = JsonConvert.DeserializeXNode(lista, "XMLObrazac");
            var nodeKomplet = "<?xml version='1.0' encoding='UTF-16' standalone='yes'?>" + node.ToString();
            nodeKomplet = nodeKomplet.Replace("<XMLObrazac>", "<XMLObrazac xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");

            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(nodeKomplet);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmltest.WriteTo(xw);
            String XmlString = sw.ToString();

            var ig = new IzvjestajiGenerisani();

            ig.Izvjestaj = XmlString;
            ig.IzvjestajDefinicijaId = izvjestajDefinicija.IzvjestajDefinicijaId;
            ig.IzvjestajXsdshemaiId = izvjestajDefinicija.IzvjestajXsdshemaiId;
            ig.DatumOd = DateTime.Now;
            ig.DatumDo = DateTime.Now;
            ig.NazivXmlfajla = "4200326930001" + "_1LMF_" + datumOd.Replace("-", "").Substring(0, 6);
            ig.ImportedExcel = nazivFajl;
            ig.DatumKreiranja = DateTime.Now;
            ig.DatumUnosa = DateTime.Now;
            ig.DatumAzuriranja = DateTime.Now;
            ig.Status = 1;
            ig.KorisnikUnosa = "dbo";

            _context.IzvjestajiGenerisani.Add(ig);
            _context.SaveChanges();
            return true;
        }
        public bool GenerisiIzvjestaj2LMF(int semaId, string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajl)
        {
            List<Json34> podaci = JsonConvert.DeserializeObject<List<Json34>>(pod);  //dynamic
            IzvjestajDefinicija izvjestajDefinicija = new IzvjestajDefinicija();
            if (semaId == 10)
            izvjestajDefinicija = _context.IzvjestajDefinicija.Where(x => x.KratkiNaziv == "2LMF_N" && x.Status == 1).FirstOrDefault();
            if (semaId == 13)
                izvjestajDefinicija = _context.IzvjestajDefinicija.Where(x => x.KratkiNaziv == "2LMF_Z" && x.Status == 1).FirstOrDefault();
            var elementi = _context.IzvjestajElementi.Where(x => x.IzvjestajDefinicijaId == izvjestajDefinicija.IzvjestajDefinicijaId && x.Status == 1).ToList();
            var y = new Model.ModeliXML._2LMF.XMLObrazac();
            var pd = new Model.ModeliXML._2LMF.PodaciDrustva();
            pd.Dokument = new Model.ModeliXML._2LMF.Dokument();

            #region DIO1
            pd.JIBDrustva = "4200326930001";
            pd.Dokument.DatumPodnosenja = datumPodnosenja;
            var Direktor = elementi.Where(x => x.Element == "Direktor").FirstOrDefault();
            if (Direktor != null)
                pd.Dokument.Direktor = Direktor.ElementVrijednosti;
            var Racunovodja = elementi.Where(x => x.Element == "Certificirani racunovodja").FirstOrDefault();
            if (Racunovodja != null)
                pd.Dokument.CertRacunovodja = Racunovodja.ElementVrijednosti;
            var Sastavio = elementi.Where(x => x.Element == "Sastavio").FirstOrDefault();
            if (Sastavio != null)
                pd.Dokument.SastavioImePrezime = Sastavio.ElementVrijednosti;
            pd.Dokument.MjestoPodnosenja = "Sarajevo";
            y.PodaciDrustva = pd;
            var obr = new Model.ModeliXML._2LMF.Obrazac();
            var ps = new Model.ModeliXML._2LMF.Dio1PeriodSifra();
            ps.DatumOd = datumOd;
            ps.DatumDo = datumDo;
            ps.SifraObrasca = "2L-M-F";
            obr.Dio1PeriodSifra = ps; //1
            #endregion DIO1

            #region DIO2
            var podaciKlijent = podaci.Where(x => x.K1 != null && x.K1 != "15").ToList();
            var los = new Model.ModeliXML._2LMF.Dio2LikvidnaObavezeStanje();
            var Lplos = new List<Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje>();

            #region petlje
            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "1";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K4 != null)
                    pl.Stanje = p.K4.Replace(",", "");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "2";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K5 != null)
                    pl.Stanje = p.K5.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "3";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K6 != null)
                    pl.Stanje = p.K6.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "4";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K7 != null)
                    pl.Stanje = p.K7.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "5";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K8 != null)
                    pl.Stanje = p.K8.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "6";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K9 != null)
                    pl.Stanje = p.K9.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "7";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K10 != null)
                    pl.Stanje = p.K10.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "8";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K11 != null)
                    pl.Stanje = p.K11.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "9";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K12 != null)
                    pl.Stanje = p.K12.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "10";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K13 != null)
                    pl.Stanje = p.K13.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }
            
            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "11";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K14 != null)
                    pl.Stanje = p.K14.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "12";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K15 != null)
                    pl.Stanje = p.K15.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "13";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K16 != null)
                    pl.Stanje = p.K16.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "14";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K17 != null)
                    pl.Stanje = p.K17.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "15";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K18 != null)
                    pl.Stanje = p.K18.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "16";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K19 != null)
                    pl.Stanje = p.K19.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "17";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K20 != null)
                    pl.Stanje = p.K20.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "18";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K21 != null)
                    pl.Stanje = p.K21.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "19";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K22 != null)
                    pl.Stanje = p.K22.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "20";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K23 != null)
                    pl.Stanje = p.K23.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "21";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K24 != null)
                    pl.Stanje = p.K24.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "22";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K25 != null)
                    pl.Stanje = p.K25.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "23";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K26 != null)
                    pl.Stanje = p.K26.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "24";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K27 != null)
                    pl.Stanje = p.K27.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "25";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K28 != null)
                    pl.Stanje = p.K28.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "26";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K29 != null)
                    pl.Stanje = p.K29.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "27";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K30 != null)
                    pl.Stanje = p.K30.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "28";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K31 != null)
                    pl.Stanje = p.K31.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                if (p.K32 == null)
                    break;
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "29";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K32 != null)
                    pl.Stanje = p.K32.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            foreach (var p in podaciKlijent)
            {
                if (p.K33 == null)
                    break;
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "30";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K33 != null)
                    pl.Stanje = p.K33.Replace(",", "").Replace("0.00", "0");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }
            foreach (var p in podaciKlijent)
            {
                if (p.K34 == null)
                    break;
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeStanje();
                pl.RbrDanaUMjesecu = "31";
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                if (p.K34 != null)
                    pl.Stanje = p.K34.Replace(",", "");
                else
                    pl.Stanje = "0";
                Lplos.Add(pl);
            }

            #endregion petlje

            los.PodaciLikvidnaObavezeStanje = Lplos;
            #endregion DIO2

            #region DIO3
            var lok = new Model.ModeliXML._2LMF.Dio3LikvidnaObavezeKonto();
            var Lplok = new List<Model.ModeliXML._2LMF.PodaciLikvidnaObavezeKonto>();

            foreach (var p in podaciKlijent)
            {
                var pl = new Model.ModeliXML._2LMF.PodaciLikvidnaObavezeKonto();
                pl.LikvidnaObaveze = Convert.ToInt32(p.K1).ToString("D2");
                pl.KontoSinteticki = p.K3;
                Lplok.Add(pl);
            }

            lok.PodaciLikvidnaObavezeKonto  = Lplok;
            #endregion DIO3

            #region DIO4
            var kl = new Model.ModeliXML._2LMF.Dio4KoefLikvidnosti();
            var Lpkl = new List<Model.ModeliXML._2LMF.PodaciKoefLikv>();
            var pr = podaci.Where(x => x.K1 != null && x.K1 == "15").FirstOrDefault();

            #region DIO4 petlje
            var PKL1 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL1.RbrDanaUMjesecu = "1";
            PKL1.KoefLikvidnosti = pr.K4;
            Lpkl.Add(PKL1);
            var PKL2 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL2.RbrDanaUMjesecu = "2";
            PKL2.KoefLikvidnosti = pr.K5;
            Lpkl.Add(PKL2);
            var PKL3 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL3.RbrDanaUMjesecu = "3";
            PKL3.KoefLikvidnosti = pr.K6;
            Lpkl.Add(PKL3);
            var PKL4 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL4.RbrDanaUMjesecu = "4";
            PKL4.KoefLikvidnosti = pr.K7;
            Lpkl.Add(PKL4);
            var PKL5 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL5.RbrDanaUMjesecu = "5";
            PKL5.KoefLikvidnosti = pr.K8;
            Lpkl.Add(PKL5);
            var PKL6 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL6.RbrDanaUMjesecu = "6";
            PKL6.KoefLikvidnosti = pr.K9;
            Lpkl.Add(PKL6);
            var PKL7 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL7.RbrDanaUMjesecu = "7";
            PKL7.KoefLikvidnosti = pr.K10;
            Lpkl.Add(PKL7);
            var PKL8 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL8.RbrDanaUMjesecu = "8";
            PKL8.KoefLikvidnosti = pr.K11;
            Lpkl.Add(PKL8);
            var PKL9 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL9.RbrDanaUMjesecu = "9";
            PKL9.KoefLikvidnosti = pr.K12;
            Lpkl.Add(PKL9);
            var PKL10 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL10.RbrDanaUMjesecu = "10";
            PKL10.KoefLikvidnosti = pr.K13;
            Lpkl.Add(PKL10);
            var PKL11 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL11.RbrDanaUMjesecu = "11";
            PKL11.KoefLikvidnosti = pr.K14;
            Lpkl.Add(PKL11);
            var PKL12 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL12.RbrDanaUMjesecu = "12";
            PKL12.KoefLikvidnosti = pr.K15;
            Lpkl.Add(PKL12);
            var PKL13 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL13.RbrDanaUMjesecu = "13";
            PKL13.KoefLikvidnosti = pr.K17;
            Lpkl.Add(PKL13);
            var PKL14 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL14.RbrDanaUMjesecu = "14";
            PKL14.KoefLikvidnosti = pr.K17;
            Lpkl.Add(PKL14);
            var PKL15 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL15.RbrDanaUMjesecu = "15";
            PKL15.KoefLikvidnosti = pr.K18;
            Lpkl.Add(PKL15);
            var PKL16 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL16.RbrDanaUMjesecu = "16";
            PKL16.KoefLikvidnosti = pr.K19;
            Lpkl.Add(PKL16);
            var PKL17 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL17.RbrDanaUMjesecu = "17";
            PKL17.KoefLikvidnosti = pr.K20;
            Lpkl.Add(PKL17);
            var PKL18 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL18.RbrDanaUMjesecu = "18";
            PKL18.KoefLikvidnosti = pr.K21;
            Lpkl.Add(PKL18);
            var PKL19 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL19.RbrDanaUMjesecu = "19";
            PKL19.KoefLikvidnosti = pr.K22;
            Lpkl.Add(PKL19);
            var PKL20 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL20.RbrDanaUMjesecu = "20";
            PKL20.KoefLikvidnosti = pr.K23;
            Lpkl.Add(PKL20);
            var PKL21 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL21.RbrDanaUMjesecu = "21";
            PKL21.KoefLikvidnosti = pr.K24;
            Lpkl.Add(PKL21);
            var PKL22 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL22.RbrDanaUMjesecu = "22";
            PKL22.KoefLikvidnosti = pr.K25;
            Lpkl.Add(PKL22);
            var PKL23 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL23.RbrDanaUMjesecu = "23";
            PKL23.KoefLikvidnosti = pr.K26;
            Lpkl.Add(PKL23);
            var PKL24 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL24.RbrDanaUMjesecu = "24";
            PKL24.KoefLikvidnosti = pr.K27;
            Lpkl.Add(PKL24);
            var PKL25 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL25.RbrDanaUMjesecu = "25";
            PKL25.KoefLikvidnosti = pr.K28;
            Lpkl.Add(PKL25);
            var PKL26 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL26.RbrDanaUMjesecu = "26";
            PKL26.KoefLikvidnosti = pr.K29;
            Lpkl.Add(PKL26);
            var PKL27 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL27.RbrDanaUMjesecu = "27";
            PKL27.KoefLikvidnosti = pr.K30;
            Lpkl.Add(PKL27);
            var PKL28 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
            PKL28.RbrDanaUMjesecu = "28";
            PKL28.KoefLikvidnosti = pr.K31;
            Lpkl.Add(PKL28);
            if (pr.K32 != null)
            {
                var PKL29 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
                PKL29.RbrDanaUMjesecu = "29";
                PKL29.KoefLikvidnosti = pr.K32;
                Lpkl.Add(PKL29);
            }
            if (pr.K33 != null)
            {
                var PKL30 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
                PKL30.RbrDanaUMjesecu = "30";
                PKL30.KoefLikvidnosti = pr.K33;
                Lpkl.Add(PKL30);
            }
            if (pr.K34 != null)
            {
                var PKL31 = new Model.ModeliXML._2LMF.PodaciKoefLikv();
                PKL31.RbrDanaUMjesecu = "31";
                PKL31.KoefLikvidnosti = pr.K34;
                Lpkl.Add(PKL31);
            }

            kl.PodaciKoefLikv = Lpkl;
            #endregion DIO4 petlje

            #endregion DIO4

            //dodaj sve djelove
            obr.Dio2LikvidnaObavezeStanje = los;
            obr.Dio3LikvidnaObavezeKonto = lok;
            obr.Dio4KoefLikvidnosti = kl;
            y.Obrazac = obr; //kraj dodaj obrazac u obrazac
            var lista = JsonConvert.SerializeObject(y, Newtonsoft.Json.Formatting.None);


            XNode node = JsonConvert.DeserializeXNode(lista, "XMLObrazac");
            var nodeKomplet = "<?xml version='1.0' encoding='UTF-16' standalone='yes'?>" + node.ToString();
            nodeKomplet = nodeKomplet.Replace("<XMLObrazac>", "<XMLObrazac xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");

            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(nodeKomplet);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmltest.WriteTo(xw);
            String XmlString = sw.ToString();

            var ig = new IzvjestajiGenerisani();

            ig.Izvjestaj = XmlString;
            ig.IzvjestajDefinicijaId = izvjestajDefinicija.IzvjestajDefinicijaId;
            ig.IzvjestajXsdshemaiId = izvjestajDefinicija.IzvjestajXsdshemaiId;
            ig.DatumOd = DateTime.Now;
            ig.DatumDo = DateTime.Now;
            if (semaId == 10)
                ig.NazivXmlfajla = "4200326930001" + "_2LMF_N_" + datumOd.Replace("-", "").Substring(0, 6);
            if (semaId == 13)
                ig.NazivXmlfajla = "4200326930001" + "_2LMF_Z_" + datumOd.Replace("-", "").Substring(0, 6);
            ig.ImportedExcel = nazivFajl;
            ig.DatumKreiranja = DateTime.Now;
            ig.DatumUnosa = DateTime.Now;
            ig.DatumAzuriranja = DateTime.Now;
            ig.Status = 1;
            ig.KorisnikUnosa = "dbo";

            _context.IzvjestajiGenerisani.Add(ig);
            _context.SaveChanges();


            return true;
        }
        public bool GenerisiIzvjestaj1MF(string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajl)
        {
            List<Json8> podaci = JsonConvert.DeserializeObject<List<Json8>>(pod);  //dynamic
            var izvjestajDefinicija = _context.IzvjestajDefinicija.Where(x => x.KratkiNaziv == "1MF" && x.Status == 1).FirstOrDefault();
            var elementi = _context.IzvjestajElementi.Where(x => x.IzvjestajDefinicijaId == izvjestajDefinicija.IzvjestajDefinicijaId && x.Status == 1).ToList();
            var y = new Model.ModeliXML._1MF.XMLObrazac();
            var pd = new Model.ModeliXML._1MF.PodaciDrustva();
            pd.Dokument = new Model.ModeliXML._1MF.Dokument();

            #region DIO1
            pd.JIBDrustva = "4200326930001";
            pd.Dokument.DatumPodnosenja = datumPodnosenja;
            var Direktor = elementi.Where(x => x.Element == "Direktor").FirstOrDefault();
            if (Direktor != null)
                pd.Dokument.Direktor = Direktor.ElementVrijednosti;
            var Aktuar = elementi.Where(x => x.Element == "Ovlasteni aktuar").FirstOrDefault();
            if (Aktuar != null)
                pd.Dokument.OvlasteniAktuar = Aktuar.ElementVrijednosti;
            pd.Dokument.MjestoPodnosenja = "Sarajevo";
            y.PodaciDrustva = pd;
            var obr = new Model.ModeliXML._1MF.Obrazac();
            var ps = new Model.ModeliXML._1MF.Dio1PeriodSifra();
            ps.DatumOd = datumOd;
            ps.DatumDo = datumDo;
            ps.SifraObrasca = "1-M-F";
            obr.Dio1PeriodSifra = ps; //1
            #endregion DIO1
            #region DIO2
            //------------------------ dio2.1
            var vre = new Model.ModeliXML._1MF.Dio2VrstaRizikaEntitet();
            var Lvre = new List<Model.ModeliXML._1MF.PodaciVrstaRizikaEntitet>();
            var podaciDio2 = podaci.Where(x => x.K1 != null && !x.K2.Contains("OSIGURANJ")).ToList();

            foreach (var p in podaciDio2)
            {
                var FBiH = new Model.ModeliXML._1MF.PodaciVrstaRizikaEntitet();
                FBiH.VrstaRizika = p.K1;
                FBiH.Entitet = "FBiH";
                if (p.K3 != null)
                    FBiH.BrojPolica = p.K3.Replace(",", "");
                else
                    FBiH.BrojPolica = "0";
                if (p.K4 != null)
                    FBiH.IznosPremije = p.K4.Replace(",", "");
                else
                    FBiH.IznosPremije = "0";
                Lvre.Add(FBiH);
                var RS = new Model.ModeliXML._1MF.PodaciVrstaRizikaEntitet();
                RS.VrstaRizika = p.K1;
                RS.Entitet = "RS";
                if (p.K5 != null)
                    RS.BrojPolica = p.K5.Replace(",", "");
                else
                    RS.BrojPolica = "0";
                if (p.K6 != null)
                    RS.IznosPremije = p.K6.Replace(",", "");
                else
                    RS.IznosPremije = "0";

                Lvre.Add(RS);
            }

            vre.PodaciVrstaRizikaEntitet = Lvre;
            obr.Dio2VrstaRizikaEntitet = vre;
            //------------------------ dio2.1 KRAJ

            //------------------------ dio2.2
            var vr = new Model.ModeliXML._1MF.Dio2VrstaRizika();
            var Lvr = new List<Model.ModeliXML._1MF.PodaciVrstaRizika>();

            foreach (var p in podaciDio2)
            {
                var s = new Model.ModeliXML._1MF.PodaciVrstaRizika();
                s.VrstaRizika = p.K1;
                if (p.K7 != null)
                    s.BrojPolica = p.K7.Replace(",", "");
                else
                    s.BrojPolica = "0";
                if (p.K8 != null)
                    s.IznosPremije = p.K8.Replace(",", "");
                else
                    s.IznosPremije = "0";
                Lvr.Add(s);
            }

            vr.PodaciVrstaRizika = Lvr;
            obr.Dio2VrstaRizika = vr;
            //------------------------ dio2.2 KRAJ
            #endregion DIO2
            #region DIO3
            var vroe = new Model.ModeliXML._1MF.Dio3VrstaOsiguranjaEntitet(); //dio3.1
            var Lpvro = new List<Model.ModeliXML._1MF.PodaciVrstaOsiguranjaEntitet>();
            var podaciDio3 = podaci.Where(x => x.K1 == null).ToList();
            podaciDio3.RemoveRange(19, 3);

            foreach (var p in podaciDio3)
            {
                var FBiH = new Model.ModeliXML._1MF.PodaciVrstaOsiguranjaEntitet();
                FBiH.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                FBiH.Entitet = "FBiH";
                if (p.K3 != null)
                    FBiH.BrojPolica = p.K3.Replace(",", "");
                else
                    FBiH.BrojPolica = "0";
                if (p.K4 != null)
                    FBiH.IznosPremije = p.K4.Replace(",", "");
                else
                    FBiH.IznosPremije = "0";
                Lpvro.Add(FBiH);
                var RS = new Model.ModeliXML._1MF.PodaciVrstaOsiguranjaEntitet();
                RS.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                RS.Entitet = "RS";
                if (p.K5 != null)
                    RS.BrojPolica = p.K5.Replace(",", "");
                else
                    RS.BrojPolica = "0";
                if (p.K6 != null)
                    RS.IznosPremije = p.K6.Replace(",", "");
                else
                    RS.IznosPremije = "0";
  
                Lpvro.Add(RS);
            }

            vroe.PodaciVrstaOsiguranjaEntitet = Lpvro;
            obr.Dio3VrstaOsiguranjaEntitet = vroe;

            var vro = new Model.ModeliXML._1MF.Dio3VrstaOsiguranja(); //dio3.2
            var Lvro = new List<Model.ModeliXML._1MF.PodaciVrstaOsiguranja>();


            foreach (var p in podaciDio3)
            {
                var s = new Model.ModeliXML._1MF.PodaciVrstaOsiguranja();
                s.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                if (p.K7 != null)
                    s.BrojPolica = p.K7.Replace(",", "");
                else
                    s.BrojPolica = "0";
                if (p.K8 != null)
                    s.IznosPremije = p.K8.Replace(",", "");
                else
                    s.IznosPremije = "0";
                Lvro.Add(s);
            }

            vro.PodaciVrstaOsiguranja = Lvro;
            obr.Dio3VrstaOsiguranja = vro;

            #endregion DIO3
            #region DIO4

            var goe = new Model.ModeliXML._1MF.Dio4GrupaOsiguranjaEntitet(); //dio 4.1
            var Lgoe = new List<Model.ModeliXML._1MF.PodaciGrupaOsiguranjaEntitet>();
            var podaciDio4 = podaci.Where(x => x.K1 == null && x.K2 != null && x.K2.Contains("OSIGURANJA")).ToList();
            var p4Nez = podaciDio4[0];
            var p4Zivot = podaciDio4[1];

            var FBiHNez = new Model.ModeliXML._1MF.PodaciGrupaOsiguranjaEntitet();
            FBiHNez.GrupaOsiguranja = "Nezivotna";
            FBiHNez.Entitet = "FBiH";
            if (p4Nez.K3 != null)
                FBiHNez.BrojPolica = p4Nez.K3.Replace(",", "");
            else
                FBiHNez.BrojPolica = "0";
            if (p4Nez.K4 != null)
                FBiHNez.IznosPremije = p4Nez.K4.Replace(",", "");
            else
                FBiHNez.IznosPremije = "0";
          
            Lgoe.Add(FBiHNez);

            var RSNez = new Model.ModeliXML._1MF.PodaciGrupaOsiguranjaEntitet();
            RSNez.GrupaOsiguranja = "Nezivotna";
            RSNez.Entitet = "RS";
            if (p4Nez.K5 != null)
                RSNez.BrojPolica = p4Nez.K5.Replace(",", "");
            else
                RSNez.BrojPolica = "0";
            if (p4Nez.K6 != null)
                RSNez.IznosPremije = p4Nez.K6.Replace(",", "");
            else
                RSNez.IznosPremije = "0";
            
            Lgoe.Add(RSNez);

            var FBiHZ = new Model.ModeliXML._1MF.PodaciGrupaOsiguranjaEntitet();
            FBiHZ.GrupaOsiguranja = "Zivotna";
            FBiHZ.Entitet = "FBiH";
            if (p4Zivot.K3 != null)
                FBiHZ.BrojPolica = p4Zivot.K3.Replace(",", "");
            else
                FBiHZ.BrojPolica = "0";
            if (p4Zivot.K4 != null)
                FBiHZ.IznosPremije = p4Zivot.K4.Replace(",", "");
            else
                FBiHZ.IznosPremije = "0";
           
            Lgoe.Add(FBiHZ);

            var RSZ = new Model.ModeliXML._1MF.PodaciGrupaOsiguranjaEntitet();
            RSZ.GrupaOsiguranja = "Zivotna";
            RSZ.Entitet = "RS";
            if (p4Zivot.K5 != null)
                RSZ.BrojPolica = p4Zivot.K5.Replace(",", "");
            else
                RSZ.BrojPolica = "0";
            if (p4Zivot.K6 != null)
                RSZ.IznosPremije = p4Zivot.K6.Replace(",", "");
            else
                RSZ.IznosPremije = "0";
          
            Lgoe.Add(RSZ);

            goe.PodaciGrupaOsiguranjaEntitet = Lgoe;
            obr.Dio4GrupaOsiguranjaEntitet = goe;

            var go = new Model.ModeliXML._1MF.Dio4GrupaOsiguranja(); //dio 4.2
            var Lgo = new List<Model.ModeliXML._1MF.PodaciGrupaOsiguranja>();

            var pgoN = new Model.ModeliXML._1MF.PodaciGrupaOsiguranja();
            pgoN.GrupaOsiguranja = "Nezivotna";
            if (p4Nez.K7 != null)
                pgoN.BrojPolica = p4Nez.K7.Replace(",", "");
            else
                pgoN.BrojPolica = "0";
            if (p4Nez.K8 != null)
                pgoN.IznosPremije = p4Nez.K8.Replace(",", "");
            else
                pgoN.IznosPremije = "0";
          
            Lgo.Add(pgoN);

            var pgoZ = new Model.ModeliXML._1MF.PodaciGrupaOsiguranja();
            pgoZ.GrupaOsiguranja = "Zivotna";
            if (p4Zivot.K7 != null)
                pgoZ.BrojPolica = p4Zivot.K7.Replace(",", "");
            else
                pgoZ.BrojPolica = "0";
            if (p4Zivot.K8 != null)
                pgoZ.IznosPremije = p4Zivot.K8.Replace(",", "");
            else
                pgoZ.IznosPremije = "0";
          
            Lgo.Add(pgoZ);

            go.PodaciGrupaOsiguranja = Lgo;
            obr.Dio4GrupaOsiguranja = go;
            #endregion DIO4

            y.Obrazac = obr; //kraj dodaj obrazac u obrazac
            var lista = JsonConvert.SerializeObject(y, Newtonsoft.Json.Formatting.None);


            XNode node = JsonConvert.DeserializeXNode(lista, "XMLObrazac");
            var nodeKomplet = "<?xml version='1.0' encoding='UTF-16' standalone='yes'?>" + node.ToString();
            nodeKomplet = nodeKomplet.Replace("<XMLObrazac>", "<XMLObrazac xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");

            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(nodeKomplet);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmltest.WriteTo(xw);
            String XmlString = sw.ToString();

            var ig = new IzvjestajiGenerisani();

            ig.Izvjestaj = XmlString;
            ig.IzvjestajDefinicijaId = izvjestajDefinicija.IzvjestajDefinicijaId;
            ig.IzvjestajXsdshemaiId = izvjestajDefinicija.IzvjestajXsdshemaiId;
            ig.DatumOd = DateTime.Now;
            ig.DatumDo = DateTime.Now;
            ig.NazivXmlfajla = "4200326930001" + "_1MF_" + datumOd.Replace("-", "").Substring(0, 6);
            ig.ImportedExcel = nazivFajl;
            ig.DatumKreiranja = DateTime.Now;
            ig.DatumUnosa = DateTime.Now;
            ig.DatumAzuriranja = DateTime.Now;
            ig.Status = 1;
            ig.KorisnikUnosa = "dbo";

            _context.IzvjestajiGenerisani.Add(ig);
            _context.SaveChanges();


            return true;
        }
        public bool GenerisiIzvjestaj2MF(string datumOd, string datumDo, string datumPodnosenja, string pod, string nazivFajl)
        {
            List<Json21> podaci = JsonConvert.DeserializeObject<List<Json21>>(pod);  //dynamic
            var izvjestajDefinicija = _context.IzvjestajDefinicija.Where(x => x.KratkiNaziv == "2MF" && x.Status == 1).FirstOrDefault();
            var elementi = _context.IzvjestajElementi.Where(x => x.IzvjestajDefinicijaId == izvjestajDefinicija.IzvjestajDefinicijaId && x.Status == 1).ToList();
            var y = new Model.ModeliXML._2MF.XMLObrazac();
            var pd = new Model.ModeliXML._2MF.PodaciDrustva();
            pd.Dokument = new Model.ModeliXML._2MF.Dokument();

            #region DIO1
            pd.JIBDrustva = "4200326930001";
            pd.Dokument.DatumPodnosenja = datumPodnosenja;
            var Direktor = elementi.Where(x => x.Element == "Direktor").FirstOrDefault(); 
            if (Direktor != null)
                pd.Dokument.Direktor = Direktor.ElementVrijednosti;
            var Aktuar = elementi.Where(x => x.Element == "Ovlasteni aktuar").FirstOrDefault(); 
            if (Aktuar != null)
            pd.Dokument.OvlasteniAktuar = Aktuar.ElementVrijednosti;  
            pd.Dokument.MjestoPodnosenja = "Sarajevo";
            y.PodaciDrustva = pd;
            var obr = new Model.ModeliXML._2MF.Obrazac();
            var ps = new Model.ModeliXML._2MF.Dio1PeriodSifra();
            ps.DatumOd = datumOd;
            ps.DatumDo = datumDo;
            ps.SifraObrasca = "2-M-F";
            obr.Dio1PeriodSifra = ps; //1
            #endregion DIO1
            #region DIO2
            //------------------------ dio2.1
            var vre = new Dio2VrstaRizikaEntitet(); 
            var Lvre = new List<PodaciVrstaRizikaEntitet>();
            var podaciDio2 = podaci.Where(x => x.K1 != null && !x.K2.Contains("OSIGURANJ")).ToList();

            foreach(var p in podaciDio2)
            {
                var FBiH = new PodaciVrstaRizikaEntitet();
                FBiH.VrstaRizika = p.K1;
                FBiH.Entitet = "FBiH";
                if (p.K3 != null)
                    FBiH.BrojPrijSteta = p.K3.Replace(",", "");
                else
                    FBiH.BrojPrijSteta = "0";
                if (p.K4 != null)
                    FBiH.BrojOdbSteta = p.K4.Replace(",", "");
                else
                    FBiH.BrojOdbSteta = "0";
                if (p.K5 != null)
                    FBiH.BrojIsplSteta = p.K5.Replace(",", "");
                else
                    FBiH.BrojIsplSteta = "0";
                if (p.K6 != null)
                    FBiH.BrojRijesSteta = p.K6.Replace(",", "");
                else
                    FBiH.BrojRijesSteta = "0";
                if (p.K7 != null)
                    FBiH.IznosRijesSteta = p.K7.Replace(",", "");
                else
                    FBiH.IznosRijesSteta = "0";
                if (p.K8 != null)
                    FBiH.BrojRezSteta = p.K8.Replace(",", "");
                else
                    FBiH.BrojRezSteta = "0";
                if (p.K9 != null)
                    FBiH.IznosRezSteta = p.K9.Replace(",", "");
                else
                    FBiH.IznosRezSteta = "0";
                Lvre.Add(FBiH);
                var RS = new PodaciVrstaRizikaEntitet();
                RS.VrstaRizika = p.K1;
                RS.Entitet = "RS";
                if (p.K10 != null)
                    RS.BrojPrijSteta = p.K10.Replace(",", "");
                else
                    RS.BrojPrijSteta = "0";
                if (p.K11 != null)
                    RS.BrojOdbSteta = p.K11.Replace(",", "");
                else
                    RS.BrojOdbSteta = "0";
                if (p.K12 != null)
                    RS.BrojIsplSteta = p.K12.Replace(",", "");
                else
                    RS.BrojIsplSteta = "0";
                if (p.K13 != null)
                    RS.BrojRijesSteta = p.K13.Replace(",", "");
                else
                    RS.BrojRijesSteta = "0";
                if (p.K14 != null)
                    RS.IznosRijesSteta = p.K14.Replace(",", "");
                else
                    RS.IznosRijesSteta = "0";
                if (p.K15 != null)
                    RS.BrojRezSteta = p.K15.Replace(",", "");
                else
                    RS.BrojRezSteta = "0";
                if (p.K16 != null)
                    RS.IznosRezSteta = p.K16.Replace(",", "");
                else
                    RS.IznosRezSteta = "0";
                Lvre.Add(RS);
            }

            vre.PodaciVrstaRizikaEntitet = Lvre;
            obr.Dio2VrstaRizikaEntitet = vre;
            //------------------------ dio2.1 KRAJ

            //------------------------ dio2.2
            var vr = new Dio2VrstaRizika();
            var Lvr = new List<PodaciVrstaRizika>();

            foreach (var p in podaciDio2)
            {
                var s = new PodaciVrstaRizika();
                s.VrstaRizika = p.K1;
                if (p.K17 != null)
                    s.BrojPrijSteta = p.K17.Replace(",", "");
                else
                    s.BrojPrijSteta = "0";
                if (p.K18 != null)
                    s.BrojRijesSteta = p.K18.Replace(",", "");
                else
                    s.BrojRijesSteta = "0";
                if (p.K19 != null)
                    s.IznosRijesSteta = p.K19.Replace(",", "");
                else
                    s.IznosRijesSteta = "0";
                if (p.K20 != null)
                    s.BrojRezSteta = p.K20.Replace(",", "");
                else
                    s.BrojRezSteta = "0";
                if (p.K21 != null)
                    s.IznosRezSteta = p.K21.Replace(",", "");
                else
                    s.IznosRezSteta = "0";
                Lvr.Add(s);
            }

            vr.PodaciVrstaRizika = Lvr;
            obr.Dio2VrstaRizika = vr;
            //------------------------ dio2.2 KRAJ
            #endregion DIO2
            #region DIO3
            var vroe = new Dio3VrstaOsiguranjaEntitet(); //dio3.1
            var Lpvro = new List<PodaciVrstaOsiguranjaEntitet>();
            var podaciDio3 = podaci.Where(x => x.K1 == null).ToList();
            podaciDio3.RemoveRange(19, 3);

            foreach (var p in podaciDio3)
            {
                var FBiH = new PodaciVrstaOsiguranjaEntitet();
                FBiH.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                FBiH.Entitet = "FBiH";
                if (p.K3 != null)
                    FBiH.BrojPrijSteta = p.K3.Replace(",", "");
                else
                    FBiH.BrojPrijSteta = "0";
                if (p.K4 != null)
                    FBiH.BrojOdbSteta = p.K4.Replace(",", "");
                else
                    FBiH.BrojOdbSteta = "0";
                if (p.K5 != null)
                    FBiH.BrojIsplSteta = p.K5.Replace(",", "");
                else
                    FBiH.BrojIsplSteta = "0";
                if (p.K6 != null)
                    FBiH.BrojRijesSteta = p.K6.Replace(",", "");
                else
                    FBiH.BrojRijesSteta = "0";
                if (p.K7 != null)
                    FBiH.IznosRijesSteta = p.K7.Replace(",", "");
                else
                    FBiH.IznosRijesSteta = "0";
                if (p.K8 != null)
                    FBiH.BrojRezSteta = p.K8.Replace(",", "");
                else
                    FBiH.BrojRezSteta = "0";
                if (p.K9 != null)
                    FBiH.IznosRezSteta = p.K9.Replace(",", "");
                else 
                    FBiH.IznosRezSteta = "0";
                Lpvro.Add(FBiH);
                var RS = new PodaciVrstaOsiguranjaEntitet();
                RS.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                RS.Entitet = "RS";
                if (p.K10 != null)
                    RS.BrojPrijSteta = p.K10.Replace(",", "");
                else
                    RS.BrojPrijSteta = "0";
                if (p.K11 != null)
                    RS.BrojOdbSteta = p.K11.Replace(",", "");
                else
                    RS.BrojOdbSteta = "0";
                if (p.K12 != null)
                    RS.BrojIsplSteta = p.K12.Replace(",", "");
                else
                    RS.BrojIsplSteta = "0";
                if (p.K13 != null)
                    RS.BrojRijesSteta = p.K13.Replace(",", "");
                else
                    RS.BrojRijesSteta = "0";
                if (p.K14 != null)
                    RS.IznosRijesSteta = p.K14.Replace(",", "");
                else
                    RS.IznosRijesSteta = "0";
                if (p.K15 != null)
                    RS.BrojRezSteta = p.K15.Replace(",", "");
                else
                    RS.BrojRezSteta = "0";
                if (p.K16 != null)
                    RS.IznosRezSteta = p.K16.Replace(",", "");
                else
                    RS.IznosRezSteta = "0";
                Lpvro.Add(RS);
            }

            vroe.PodaciVrstaOsiguranjaEntitet = Lpvro;
            obr.Dio3VrstaOsiguranjaEntitet = vroe;

            var vro = new Dio3VrstaOsiguranja(); //dio3.2
            var Lvro = new List<PodaciVrstaOsiguranja>();


            foreach (var p in podaciDio3)
            {
                var s = new PodaciVrstaOsiguranja();
                s.VrstaOsiguranja = p.K2.Replace("UKUPNO ", "");
                if (p.K17 != null)
                    s.BrojPrijSteta = p.K17.Replace(",", "");
                else
                    s.BrojPrijSteta = "0";
                if (p.K18 != null)
                    s.BrojRijesSteta = p.K18.Replace(",", "");
                else
                    s.BrojRijesSteta = "0";
                if (p.K19 != null)
                    s.IznosRijesSteta = p.K19.Replace(",", "");
                else
                    s.IznosRijesSteta = "0";
                if (p.K20 != null)
                    s.BrojRezSteta = p.K20.Replace(",", "");
                else
                    s.BrojRezSteta = "0";
                if (p.K21 != null)
                    s.IznosRezSteta = p.K21.Replace(",", "");
                else
                    s.IznosRezSteta = "0";
               Lvro.Add(s);
            }

            vro.PodaciVrstaOsiguranja = Lvro;
            obr.Dio3VrstaOsiguranja = vro;

            #endregion DIO3
            #region DIO4

            var goe = new Dio4GrupaOsiguranjaEntitet(); //dio 4.1
            var Lgoe = new List<PodaciGrupaOsiguranjaEntitet>();
            var podaciDio4 = podaci.Where(x => x.K1 == null && x.K2 != null && x.K2.Contains("OSIGURANJA")).ToList();
            var p4Nez = podaciDio4[0];
            var p4Zivot = podaciDio4[1];

            var FBiHNez = new PodaciGrupaOsiguranjaEntitet();
            FBiHNez.GrupaOsiguranja = "Nezivotna";
            FBiHNez.Entitet = "FBiH";
            if (p4Nez.K3 != null)
                FBiHNez.BrojPrijSteta = p4Nez.K3.Replace(",", "");
            else
                FBiHNez.BrojPrijSteta = "0";
            if (p4Nez.K4 != null)
                FBiHNez.BrojOdbSteta = p4Nez.K4.Replace(",", "");
            else
                FBiHNez.BrojOdbSteta = "0";
            if (p4Nez.K5 != null)
                FBiHNez.BrojIsplSteta = p4Nez.K5.Replace(",", "");
            else
                FBiHNez.BrojIsplSteta = "0";
            if (p4Nez.K6 != null)
                FBiHNez.BrojRijesSteta = p4Nez.K6.Replace(",", "");
            else
                FBiHNez.BrojRijesSteta = "0";
            if (p4Nez.K7 != null)
                FBiHNez.IznosRijesSteta = p4Nez.K7.Replace(",", "");
            else
                FBiHNez.IznosRijesSteta = "0";
            if (p4Nez.K8 != null)
                FBiHNez.BrojRezSteta = p4Nez.K8.Replace(",", "");
            else
                FBiHNez.BrojRezSteta = "0";
            if (p4Nez.K9 != null)
                FBiHNez.IznosRezSteta = p4Nez.K9.Replace(",", "");
            else
                FBiHNez.IznosRezSteta = "0";
            Lgoe.Add(FBiHNez);

            var RSNez = new PodaciGrupaOsiguranjaEntitet();
            RSNez.GrupaOsiguranja = "Nezivotna";
            RSNez.Entitet = "RS";
            if (p4Nez.K10 != null)
                RSNez.BrojPrijSteta = p4Nez.K10.Replace(",", "");
            else
                RSNez.BrojPrijSteta = "0";
            if (p4Nez.K11 != null)
                RSNez.BrojOdbSteta = p4Nez.K11.Replace(",", "");
            else
                RSNez.BrojOdbSteta = "0";
            if (p4Nez.K12 != null)
                RSNez.BrojIsplSteta = p4Nez.K12.Replace(",", "");
            else
                RSNez.BrojIsplSteta = "0";
            if (p4Nez.K13 != null)
                RSNez.BrojRijesSteta = p4Nez.K13.Replace(",", "");
            else
                RSNez.BrojRijesSteta = "0";
            if (p4Nez.K14 != null)
                RSNez.IznosRijesSteta = p4Nez.K14.Replace(",", "");
            else
                RSNez.IznosRijesSteta = "0";
            if (p4Nez.K15 != null)
                RSNez.BrojRezSteta = p4Nez.K15.Replace(",", "");
            else
                RSNez.BrojRezSteta = "0";
            if (p4Nez.K16 != null)
                RSNez.IznosRezSteta = p4Nez.K16.Replace(",", "");
            else
                RSNez.IznosRezSteta = "0";
            Lgoe.Add(RSNez);

            var FBiHZ = new PodaciGrupaOsiguranjaEntitet();
            FBiHZ.GrupaOsiguranja = "Zivotna";
            FBiHZ.Entitet = "FBiH";
            if (p4Zivot.K3 != null)
                FBiHZ.BrojPrijSteta = p4Zivot.K3.Replace(",", "");
            else
                FBiHZ.BrojPrijSteta = "0";
            if (p4Zivot.K4 != null)
                FBiHZ.BrojOdbSteta = p4Zivot.K4.Replace(",", "");
            else
                FBiHZ.BrojOdbSteta = "0";
            if (p4Zivot.K5 != null)
                FBiHZ.BrojIsplSteta = p4Zivot.K5.Replace(",", "");
            else
                FBiHZ.BrojIsplSteta = "0";
            if (p4Nez.K6 != null)
                FBiHZ.BrojRijesSteta = p4Zivot.K6.Replace(",", "");
            else
                FBiHZ.BrojRijesSteta = "0";
            if (p4Zivot.K7 != null)
                FBiHZ.IznosRijesSteta = p4Zivot.K7.Replace(",", "");
            else
                FBiHZ.IznosRijesSteta = "0";
            if (p4Zivot.K8 != null)
                FBiHZ.BrojRezSteta = p4Zivot.K8.Replace(",", "");
            else
                FBiHZ.BrojRezSteta = "0";
            if (p4Zivot.K9 != null)
                FBiHZ.IznosRezSteta = p4Zivot.K9.Replace(",", "");
            else
                FBiHZ.IznosRezSteta = "0";
           Lgoe.Add(FBiHZ);

            var RSZ = new PodaciGrupaOsiguranjaEntitet();
            RSZ.GrupaOsiguranja = "Zivotna";
            RSZ.Entitet = "RS";
            if (p4Zivot.K10 != null)
                RSZ.BrojPrijSteta = p4Zivot.K10.Replace(",", "");
            else
                RSZ.BrojPrijSteta = "0";
            if (p4Zivot.K11 != null)
                RSZ.BrojOdbSteta = p4Zivot.K11.Replace(",", "");
            else
                RSZ.BrojOdbSteta = "0";
            if (p4Zivot.K12 != null)
                RSZ.BrojIsplSteta = p4Zivot.K12.Replace(",", "");
            else
                RSZ.BrojIsplSteta = "0";
            if (p4Zivot.K13 != null)
                RSZ.BrojRijesSteta = p4Zivot.K13.Replace(",", "");
            else
                RSZ.BrojRijesSteta = "0";
            if (p4Zivot.K14 != null)
                RSZ.IznosRijesSteta = p4Zivot.K14.Replace(",", "");
            else
                RSZ.IznosRijesSteta = "0";
            if (p4Zivot.K15 != null)
                RSZ.BrojRezSteta = p4Zivot.K15.Replace(",", "");
            else
                RSZ.BrojRezSteta = "0";
            if (p4Zivot.K16 != null)
                RSZ.IznosRezSteta = p4Zivot.K16.Replace(",", "");
            else
                RSZ.IznosRezSteta = "0";
            Lgoe.Add(RSZ);

            goe.PodaciGrupaOsiguranjaEntitet = Lgoe;
            obr.Dio4GrupaOsiguranjaEntitet = goe;

            var go = new Dio4GrupaOsiguranja(); //dio 4.2
            var Lgo = new List<PodaciGrupaOsiguranja>();

            var pgoN = new PodaciGrupaOsiguranja();
            pgoN.GrupaOsiguranja = "Nezivotna";
            if (p4Nez.K17 != null)
                pgoN.BrojPrijSteta = p4Nez.K17.Replace(",", "");
            else
                pgoN.BrojPrijSteta = "0";
            if (p4Nez.K18 != null)
                pgoN.BrojRijesSteta = p4Nez.K18.Replace(",", "");
            else
                pgoN.BrojRijesSteta = "0";
            if (p4Nez.K19 != null)
                pgoN.IznosRijesSteta = p4Nez.K19.Replace(",", "");
            else
                pgoN.IznosRijesSteta = "0";
            if (p4Nez.K20 != null)
                pgoN.BrojRezSteta = p4Nez.K20.Replace(",", "");
            else
                pgoN.BrojRezSteta = "0";
            if (p4Nez.K21 != null)
                pgoN.IznosRezSteta = p4Nez.K21.Replace(",", "");
            else
                pgoN.IznosRezSteta = "0";
           Lgo.Add(pgoN);

            var pgoZ = new PodaciGrupaOsiguranja();
            pgoZ.GrupaOsiguranja = "Zivotna";
            if (p4Zivot.K17 != null)
                pgoZ.BrojPrijSteta = p4Zivot.K17.Replace(",", "");
            else
                pgoZ.BrojPrijSteta = "0";
            if (p4Zivot.K18 != null)
                pgoZ.BrojRijesSteta = p4Zivot.K18.Replace(",", "");
            else
                pgoZ.BrojRijesSteta = "0";
            if (p4Zivot.K19 != null)
                pgoZ.IznosRijesSteta = p4Zivot.K19.Replace(",", "");
            else
                pgoZ.IznosRijesSteta = "0";
            if (p4Zivot.K20 != null)
                pgoZ.BrojRezSteta = p4Zivot.K20.Replace(",", "");
            else
                pgoZ.BrojRezSteta = "0";
            if (p4Zivot.K21 != null)
                pgoZ.IznosRezSteta = p4Zivot.K21.Replace(",", "");
            else
                pgoZ.IznosRezSteta = "0";
           Lgo.Add(pgoZ);

            go.PodaciGrupaOsiguranja = Lgo;
            obr.Dio4GrupaOsiguranja = go;
            #endregion DIO4

            y.Obrazac = obr; //kraj dodaj obrazac u obrazac
            var lista = JsonConvert.SerializeObject(y, Newtonsoft.Json.Formatting.None);


            XNode node = JsonConvert.DeserializeXNode(lista, "XMLObrazac");
            var nodeKomplet = "<?xml version='1.0' encoding='UTF-16' standalone='yes'?>" + node.ToString();
            nodeKomplet = nodeKomplet.Replace("<XMLObrazac>", "<XMLObrazac xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");

            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(nodeKomplet);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmltest.WriteTo(xw);
            String XmlString = sw.ToString();

            var ig = new IzvjestajiGenerisani();
           
            ig.Izvjestaj = XmlString;
            ig.IzvjestajDefinicijaId = izvjestajDefinicija.IzvjestajDefinicijaId;
            ig.IzvjestajXsdshemaiId = izvjestajDefinicija.IzvjestajXsdshemaiId;
            ig.DatumOd = DateTime.Now;
            ig.DatumDo = DateTime.Now;
            ig.NazivXmlfajla = "4200326930001" + "_2MF_" + datumOd.Replace("-", "").Substring(0, 6);
            ig.ImportedExcel = nazivFajl;
            ig.DatumKreiranja = DateTime.Now;
            ig.DatumUnosa = DateTime.Now;
            ig.DatumAzuriranja = DateTime.Now;
            ig.Status = 1;
            ig.KorisnikUnosa = "dbo";

            _context.IzvjestajiGenerisani.Add(ig);
            _context.SaveChanges();


            return true;
        }
        #endregion generisanje izvjestaja
    }
}
