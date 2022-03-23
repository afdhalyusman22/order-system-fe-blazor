using System.ComponentModel.DataAnnotations;

namespace order_system_fe_blazor.Models.Customers;

public class Attributes
{
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}

public class Data
{
    public int id { get; set; }
    public Attributes attributes { get; set; }
}

public class Pagination
{
    public int page { get; set; }
    public int pageSize { get; set; }
    public int pageCount { get; set; }
    public int total { get; set; }
}

public class Meta
{
    public Pagination pagination { get; set; }
}

public class Customers
{
    public List<Data> data { get; set; }
    public Meta meta { get; set; }
}

public class CustomerDetail
{
    public int id { get; set; }
    [Required]
    public string firstname { get; set; }
    public string lastname { get; set; }
    [Required]
    public string phone { get; set; }
    [Required]
    public string address { get; set; }

}