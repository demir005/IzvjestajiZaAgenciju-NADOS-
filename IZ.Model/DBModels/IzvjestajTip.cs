using System;
using System.Collections.Generic;

namespace IZ.Model.DBModels
{
    public partial class IzvjestajTip
    {
        public IzvjestajTip()
        {
            IzvjestajDefinicija = new HashSet<IzvjestajDefinicija>();
        }

        public int IzvjestajTipId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<IzvjestajDefinicija> IzvjestajDefinicija { get; set; }
    }
}
