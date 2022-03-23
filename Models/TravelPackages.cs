namespace order_system_fe_blazor.Models.TravelPackages;

public class Small
{
    public string ext { get; set; }
    public string url { get; set; }
    public string hash { get; set; }
    public string mime { get; set; }
    public string name { get; set; }
    public object path { get; set; }
    public double size { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class Thumbnail
{
    public string ext { get; set; }
    public string url { get; set; }
    public string hash { get; set; }
    public string mime { get; set; }
    public string name { get; set; }
    public object path { get; set; }
    public double size { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class Medium
{
    public string ext { get; set; }
    public string url { get; set; }
    public string hash { get; set; }
    public string mime { get; set; }
    public string name { get; set; }
    public object path { get; set; }
    public double size { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class Formats
{
    public Small small { get; set; }
    public Thumbnail thumbnail { get; set; }
    public Medium medium { get; set; }
}

public class File
{
    public int id { get; set; }
    public string name { get; set; }
    public string alternativeText { get; set; }
    public string caption { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public Formats formats { get; set; }
    public string hash { get; set; }
    public string ext { get; set; }
    public string mime { get; set; }
    public double size { get; set; }
    public string url { get; set; }
    public object previewUrl { get; set; }
    public string provider { get; set; }
    public object provider_metadata { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}

public class TravelPackages
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<File> files { get; set; }
}

