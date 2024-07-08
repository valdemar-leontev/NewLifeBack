namespace NewLifeDAL.DataModels;

public interface IEntity
{
  public int Id { get; set; }

  public DateTimeOffset CreationDate { get; set; }
}