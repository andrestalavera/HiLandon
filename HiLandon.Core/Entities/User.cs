namespace HiLandon.Core.Entities;

public class User
{
    
#if V2
    public int? Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
#endif

}