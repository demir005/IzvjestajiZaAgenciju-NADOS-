using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IZ.BLL.Interfejsi;
using IZ.Model.VM;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Xml;

namespace IZ.Web.Controllers
{
    public class IzvjestajiController : Controller
    {

        private IIzvjestaji _izvjestajiServis;
        public string _rootPath;
        public IzvjestajiController(IIzvjestaji izvjestajiServis, IWebHostEnvironment env) // IWebHostEnvironment
        {
            _izvjestajiServis = izvjestajiServis;
            _rootPath = env.WebRootPath;
        }

        public IActionResult GenerisaniIzvjestaji()
        {
            ViewBag.SelektTip = _izvjestajiServis.VratiTipoveIzvjestaja();
            var lista = _izvjestajiServis.VratiGenIzvjestaje();
            return View(lista);
        }

        public string VratiIzvjestaje(string datumOd, string datumDo, string definicijaId)
        {
            var lista = _izvjestajiServis.VratiIzvjestajePo3Parametra(datumOd, datumDo, definicijaId);
            return lista;
        }
        public IActionResult UcitajDodajSemu()
        {
            return View("DodajSemu");
        }

        public IActionResult UcitajDodajIzvjestaj()
        {
            ViewBag.SelektTip = _izvjestajiServis.VratiTipoveIzvjestaja();
            return View("DodajIzvjestaj");
        }

        public string VratiSemu(int semaId)
        {
            return _izvjestajiServis.VratiSemu(semaId);
        }

        public bool SpasiSemu(string semaNaziv, string sema)
        {
            return true;
        }
        public bool SpasiPodatke(int semaId, string datumOd, string datumDo, string datumPodnosenja, string podaci, string podaciBezPrveDvijeKolone, string jsonSamo, string jsonPoseban, string jsonPodaciBezHeadera, string nazivFajla)
        {
            _izvjestajiServis.GenerisiIzvjestaj(semaId, datumOd, datumDo, datumPodnosenja, jsonPodaciBezHeadera, nazivFajla);
            return true;
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(_rootPath + "\\UploadExcel\\", file.FileName); // spasava u wwwroot
                // var filePath = Path.Combine("D:\\novi\\", file.FileName); moze spasit i na drugi disk
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return null;
        }

        public bool SemaPostoji(string semaNaziv, string sema)
        {
            //ako u bazi postoji sema sa tim Naziv poljem vrati true
            //ako postoji sadrzaj kolone Shema u bazi u tabeli Seme da je isti kao i proslijedjeni string sema vrati true
            // info: poredis ih kao stringove
            //ako nema nista od tog vrati false
            return false;
        }

        public IActionResult DownloadXML(int Id, string xmlIme)
        {
            var podaci = _izvjestajiServis.VratiXML(Id);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(podaci.text2);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(_rootPath + "\\TempXML\\" + podaci.text1 + ".xml", settings))
            {
                doc.Save(writer);
            }
            var filePath = Path.Combine(_rootPath + "\\TempXML\\", podaci.text1 + ".xml");
            string fileName = podaci.text1 + ".xml";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return File(fileBytes, "application/force-download", fileName);
            }
            return Ok("Došlo je do greške!Fajl sa ovim nazivom ne postoji.");
        }

        public IActionResult DownloadExcel(string xmlNaziv)
        {
            var filePath = Path.Combine(_rootPath + "\\UploadExcel\\", xmlNaziv);
            // string fileName = xmlNaziv + ".xls";          
            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/force-download", xmlNaziv);
            }
            //else
            //{
            //    var filePath1 = Path.Combine(_rootPath + "\\UploadExcel\\", xmlNaziv + ".xlsx");
            //    string fileName1 = xmlNaziv + ".xlsx";
            //    if (System.IO.File.Exists(filePath1))
            //    {
            //        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath1);
            //        return File(fileBytes, "application/force-download", fileName1);
            //    }
            //}
            return Ok("Došlo je do greške!Fajl sa ovim nazivom ne postoji.");
        }

        public IActionResult Obrisi(int Id)
        {
            _izvjestajiServis.Obrisi(Id);
            var lista = _izvjestajiServis.VratiGenIzvjestaje();
            return View("GenerisaniIzvjestaji", lista);
        }

        [HttpGet]
        public string VratiIzvjestajePoTipu(int tipId)
        {
            var izvjestaji = _izvjestajiServis.VratiIzvjestajePoTipu(tipId);
            return izvjestaji;
        }
    }
}