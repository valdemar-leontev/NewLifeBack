namespace NewLife.DataAccess.DataModels;

public class FileDataModel : IEntity
{
  public int Id { get; set; }

  public DateTimeOffset CreationDate { get; set; } = DateTime.Now;

  public required string FilePath { get; set; }

  public DateTime UploadedAt { get; set; }


  public ICollection<EventDataModel>? Events { get; set; }
}
