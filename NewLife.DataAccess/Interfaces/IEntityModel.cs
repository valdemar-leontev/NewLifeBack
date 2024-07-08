namespace NewLife.DataAccess.DataModels;

public interface IEntity
{
  public int Id { get; set; }

  public DateTimeOffset CreationDate { get; set; }
}