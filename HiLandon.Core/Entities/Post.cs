namespace HiLandon.Core.Entities;

public class Post
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

#if V2
    public bool Published { get; set; }
    public DateTime Created { get; set; }
    public User? User { get; set; }
    public int UserId { get; set; }
#endif

#if V2||V3
    public ICollection<Tag> Tags { get; set; } = [];
#endif

}
