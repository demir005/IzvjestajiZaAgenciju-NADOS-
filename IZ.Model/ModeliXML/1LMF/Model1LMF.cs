using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.Model.ModeliXML._1LMF
{
    public class Model1LMF
    {
    }

	public class Dokument
	{
		public string CertRacunovodja { get; set; }
		public string SastavioImePrezime { get; set; }
		public string Direktor { get; set; }
		public string MjestoPodnosenja { get; set; }
		public string DatumPodnosenja { get; set; }
	}

	public class PodaciDrustva
	{
		public string JIBDrustva { get; set; }
		public Dokument Dokument { get; set; }
	}

	public class Dio1PeriodSifra
	{
		public string DatumOd { get; set; }
		public string DatumDo { get; set; }
		public string SifraObrasca { get; set; }
	}

	public class Podaci
	{
		public string AOP { get; set; }
		public string IznosNezivot { get; set; }
		public string IznosZivot { get; set; }
	}

	public class Dio2Podaci
	{
		public List<Podaci> Podaci { get; set; }
	}

	public class Obrazac
	{
		public Dio1PeriodSifra Dio1PeriodSifra { get; set; }
		public Dio2Podaci Dio2Podaci { get; set; }
	}

	public class XMLObrazac
	{
		public PodaciDrustva PodaciDrustva { get; set; }
		public Obrazac Obrazac { get; set; }
	}
}
