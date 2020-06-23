using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IZ.BLL.Interfejsi;
using IZ.Model.VM;

namespace IZ.Web.Controllers
{
    public class DemIzvjestajiController : Controller
    {

        private IDemIzvjestaji _demIzvjestajiServis;
        private IIzvjestaji _izvjestajiServis;
        public DemIzvjestajiController(IDemIzvjestaji demIzvjestajiServis,   IIzvjestaji izvjestajiServis)
        {
            _demIzvjestajiServis = demIzvjestajiServis;
            _izvjestajiServis = izvjestajiServis;
        }

        //ovo ispod je bez veze defaultna metoda
        public IActionResult Index()
        {
            return View();
        }

        public string VratiDefinicijeIzvjestaj(int tipId)
        {
            var lista = _demIzvjestajiServis.VratiIzvjestajPoTipu(tipId);
            return lista;
        }
        

        public IActionResult TipIzvjestaja()
        {           
            ViewBag.SelektTip = _demIzvjestajiServis.VratiTipove();
            ViewBag.SelektDef = _demIzvjestajiServis.VratiDefinicije();
            return View("Index");
        }

        [HttpGet]
        public string VratiIzvjestajPoTipu(int tipId)
        {
            var izvjestaj = _izvjestajiServis.VratiIzvjestajePoTipu(tipId);
            return izvjestaj;
        }  
    }
}