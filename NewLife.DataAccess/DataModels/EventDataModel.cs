namespace NewLife.DataAccess.DataModels;

public class EventDataModel : IEntity
{
  public int Id { get; set; }

  public DateTimeOffset CreationDate { get; set; } = DateTime.Now;

  public required string Name { get; set; }

  public required string Description { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime EndDate { get; set; }

  public int FileId { get; set; }


  public required FileDataModel File { get; set; }

  public ICollection<EventRegistrationDataModel>? EventRegistrations { get; set; }
}