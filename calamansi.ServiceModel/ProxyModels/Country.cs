namespace calamansi.ServiceModel.ProxyModels;

public class Country
{
    public string Name { get; set; }
    public List<string> Tld { get; set; } = null;
    public string Cca2 { get; set; }
    public int? Ccn3 { get; set; } = null;
    public string Cca3 { get; set; }
    public bool? Independent { get; set; } = null;
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, object> Currencies { get; set; } = null;
    public Idd Idd { get; set; }
    public List<string> Capital { get; set; } = null;
    public List<string> AltSpellings { get; set; }
    public string Region { get; set; }
    public Dictionary<string, object> Languages { get; set; } = null;
    public Dictionary<string, object> Translations { get; set; }
    public List<double> Latlng { get; set; }
    public bool Landlocked { get; set; }
    public double Area { get; set; }
    public Dictionary<string, object> Demonyms { get; set; } = null;
    public string Flag { get; set; }
    public Maps Maps { get; set; }
    public int Population { get; set; }
    public Car Car { get; set; }
    public List<string> Timezones { get; set; }
    public List<string> Continents { get; set; }
    public Flags Flags { get; set; }
    public CoatOfArms CoatOfArms { get; set; }
    public string StartOfWeek { get; set; }
    public CapitalInfo CapitalInfo { get; set; }
}

 public class Car
 {
     public List<string> signs { get; set; }
     public string side { get; set; }
 }
 public class CapitalInfo
 {
     public List<double> latlng { get; set; }
 }

 public class Flags
 {
     public string png { get; set; }
     public string svg { get; set; }
     public string alt { get; set; }
 }

 public class Idd
 {
     public string root { get; set; }
     public List<string> suffixes { get; set; }
 }

 public class Maps
 {
     public string googleMaps { get; set; }
     public string openStreetMaps { get; set; }
 }

 public class CoatOfArms
 {
     public string png { get; set; }
     public string svg { get; set; }
 }
