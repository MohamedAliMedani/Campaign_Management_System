namespace Campaign_Management_System.Src.Model
{
public class Campaign:Entity
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime ScheduledDate { get; set; }
}
}