using System.ComponentModel.DataAnnotations;

namespace ApiDemo2.models;

public class ChildModel
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
}