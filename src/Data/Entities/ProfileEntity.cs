namespace Data.Entities;

public class ProfileEntity
{
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }

    public int TimeZone { get; set; }
}
