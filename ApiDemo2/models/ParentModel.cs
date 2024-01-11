using System.ComponentModel.DataAnnotations;

namespace ApiDemo2.models;

public class ParentModel
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<ChildModel> ChildModels { get; set; }
}