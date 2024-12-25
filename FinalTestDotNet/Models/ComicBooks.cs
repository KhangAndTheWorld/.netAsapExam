using System.ComponentModel.DataAnnotations;

namespace FinalTestDotNet.Models;

public class ComicBooks
{
    [Key]
    public int ComicBookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal PricePerDay { get; set; }
}