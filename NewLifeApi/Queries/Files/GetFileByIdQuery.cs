using MediatR;

namespace NewLifeApi.Queries.Files;

public class GetFileByIdQuery : IRequest<byte[]>
{
  public int Id { get; set; }

  public GetFileByIdQuery(int id)
  {
    Id = id;
  }
}
