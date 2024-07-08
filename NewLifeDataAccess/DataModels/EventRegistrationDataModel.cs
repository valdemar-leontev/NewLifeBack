namespace NewLifeDAL.DataModels;

public class EventRegistrationDataModel : EventRegistrationModel, IEntity
{
  public int Id { get; set; }

  public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;

  public EventDataModel? Event { get; set; }
}