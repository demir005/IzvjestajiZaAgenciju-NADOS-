using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.Model.ModeliXML._2LMF
{
    public class Model2LMF
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

	public class PodaciLikvidnaObavezeStanje
	{
		public string RbrDanaUMjesecu { get; set; }
		public string LikvidnaObaveze { get; set; }
		public string Stanje { get; set; }
	}

	public class Dio2LikvidnaObavezeStanje
	{
		public List<PodaciLikvidnaObavezeStanje> PodaciLikvidnaObavezeStanje { get; set; }
	}

	public class PodaciLikvidnaObavezeKonto
	{
		public string LikvidnaObaveze { get; set; }
		public string KontoSinteticki { get; set; }
	}

	public class Dio3LikvidnaObavezeKonto
	{
		public List<PodaciLikvidnaObavezeKonto> PodaciLikvidnaObavezeKonto { get; set; }
	}

	public class PodaciKoefLikv
	{
		public string RbrDanaUMjesecu { get; set; }
		public string KoefLikvidnosti { get; set; }
	}

	public class Dio4KoefLikvidnosti
	{
		public List<PodaciKoefLikv> PodaciKoefLikv { get; set; }
	}

	public class Obrazac
	{
		public Dio1PeriodSifra Dio1PeriodSifra { get; set; }
		public Dio2LikvidnaObavezeStanje Dio2LikvidnaObavezeStanje { get; set; }
		public Dio3LikvidnaObavezeKonto Dio3LikvidnaObavezeKonto { get; set; }
		public Dio4KoefLikvidnosti Dio4KoefLikvidnosti { get; set; }
	}

	public class XMLObrazac
	{
		public PodaciDrustva PodaciDrustva { get; set; }
		public Obrazac Obrazac { get; set; }
	}
}
