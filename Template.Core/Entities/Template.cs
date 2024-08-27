namespace Template.Core.Entities;

public class Template : BaseEntity
{
    public string Name { get; set;} = "";

    public Guid TemplateId { get; set; }
    [ForeignKey(nameof(TemplateId))]
    public virtual Template? Parent { get; set; }

    public virtual ICollection<Template> Childs { get; set; } = new List<Template>();
}