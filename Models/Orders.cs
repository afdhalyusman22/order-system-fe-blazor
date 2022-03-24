using System.ComponentModel.DataAnnotations;

namespace order_system_fe_blazor.Models.Orders;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Customers
{
    public int id { get; set; }
    public string firstname { get; set; }
    public object lastname { get; set; }
}

public class TravelPackage
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

public class Status
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Orders
{
    public int id { get; set; }
    public string orderId { get; set; }
    public DateTime orderDate { get; set; }
    public Customers customers { get; set; }
    public TravelPackage travel_package { get; set; }
    public Status status { get; set; }
    public string remark { get; set; }
}

public class ModerateOrders
{
    [Required]
    public int? status { get; set; }
    public string remark { get; set; }
}

