using System.ComponentModel.DataAnnotations;

namespace FinalTestDotNet.Models;

public class Customers
{
    [Key]
    public int CustomerID { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateAt { get; set; }
}