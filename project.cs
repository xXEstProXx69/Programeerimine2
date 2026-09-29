public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime Deadline { get; set; }
    public decimal Budget { get; set; }
    public decimal HourlyRate { get; set; }
    public string Team { get; set; }
}


public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public decimal EstimatedHours { get; set; }
    public string ResponsiblePerson { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public decimal? FixedPrice { get; set; }
}

public class WorkLog
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Hours { get; set; }
    public string Worker { get; set; }
    public string Description { get; set; }
}