namespace HiLandon.Core.Entities;

public class Tag
{

#if V2||V3
    public int? Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Post> Posts { get; set; } = [];
#endif

}