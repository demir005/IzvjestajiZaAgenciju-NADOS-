using IZ.Model.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.BLL.Interfejsi
{
    public interface IDemIzvjestaji
    {
        public bool DemirMetodaDemo();

        public List<DvojkaVM> VratiTipove();

        public List<DvojkaVM> VratiDefinicije();

        //ListaSveVM UcitajIzvjestaj();

        public string VratiIzvjestajPoTipu(int tipId);

    }
}
