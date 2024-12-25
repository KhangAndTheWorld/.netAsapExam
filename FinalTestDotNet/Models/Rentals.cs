using System.ComponentModel.DataAnnotations;

namespace FinalTestDotNet.Models;

public class Rentals
{
    [Key]
    public int RentalID { get; set; }
    public int CustomerID { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
}