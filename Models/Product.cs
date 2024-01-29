using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Product
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted {get; set;}

    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    public string? ImageUrl {get; set;}
}