using System;
using System.Collections.Generic;
using System.Text;

namespace IZ.Model.ModeliXML._2MF
{
    public class Model2MF
    {
    }

	public class Dokument
	{
		public string OvlasteniAktuar { get; set; }
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

	public class PodaciVrstaRizikaEntitet
	{
		public string VrstaRizika { get; set; }
		public string Entitet { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojOdbSteta { get; set; }
		public string BrojIsplSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}


	public class Dio2VrstaRizikaEntitet
	{
		public List<PodaciVrstaRizikaEntitet> PodaciVrstaRizikaEntitet { get; set; }
	}

	public class PodaciVrstaRizika
	{
		public string VrstaRizika { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}

	public class Dio2VrstaRizika
	{
		public List<PodaciVrstaRizika> PodaciVrstaRizika { get; set; }
	}

	public class PodaciVrstaOsiguranjaEntitet
	{
		public string VrstaOsiguranja { get; set; }
		public string Entitet { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojOdbSteta { get; set; }
		public string BrojIsplSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}

	public class Dio3VrstaOsiguranjaEntitet
	{
		public List<PodaciVrstaOsiguranjaEntitet> PodaciVrstaOsiguranjaEntitet { get; set; }
	}

	public class PodaciVrstaOsiguranja
	{
		public string VrstaOsiguranja { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}

	public class Dio3VrstaOsiguranja
	{
		public List<PodaciVrstaOsiguranja> PodaciVrstaOsiguranja { get; set; }
	}

	public class PodaciGrupaOsiguranjaEntitet
	{
		public string GrupaOsiguranja { get; set; }
		public string Entitet { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojOdbSteta { get; set; }
		public string BrojIsplSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}

	public class Dio4GrupaOsiguranjaEntitet
	{
		public List<PodaciGrupaOsiguranjaEntitet> PodaciGrupaOsiguranjaEntitet { get; set; }
	}

	public class PodaciGrupaOsiguranja
	{
		public string GrupaOsiguranja { get; set; }
		public string BrojPrijSteta { get; set; }
		public string BrojRijesSteta { get; set; }
		public string IznosRijesSteta { get; set; }
		public string BrojRezSteta { get; set; }
		public string IznosRezSteta { get; set; }
	}

	public class Dio4GrupaOsiguranja
	{
		public List<PodaciGrupaOsiguranja> PodaciGrupaOsiguranja { get; set; }
	}


	public class Obrazac
	{
		public Dio1PeriodSifra Dio1PeriodSifra { get; set; }
		public Dio2VrstaRizikaEntitet Dio2VrstaRizikaEntitet { get; set; }
		public Dio2VrstaRizika Dio2VrstaRizika { get; set; }
		public Dio3VrstaOsiguranjaEntitet Dio3VrstaOsiguranjaEntitet { get; set; }
		public Dio3VrstaOsiguranja Dio3VrstaOsiguranja { get; set; }
		public Dio4GrupaOsiguranjaEntitet Dio4GrupaOsiguranjaEntitet { get; set; }
		public Dio4GrupaOsiguranja Dio4GrupaOsiguranja { get; set; }
	}

	public class XMLObrazac
	{
		public PodaciDrustva PodaciDrustva { get; set; }
		public Obrazac Obrazac { get; set; }
		//      [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		//public string Xsi { get; set; }
	}
}
