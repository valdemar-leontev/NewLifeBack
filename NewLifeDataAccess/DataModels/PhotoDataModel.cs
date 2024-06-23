namespace NewLifeDAL.DataModels;

public class PhotoDataModel
{
  public int Id { get; set; }

  public required string Title { get; set; }

  public required string FilePath { get; set; }

  public DateTime UploadedAt { get; set; }
}
