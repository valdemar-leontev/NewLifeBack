using MediatR;
using NewLifeDAL.DataModels;

namespace NewLifeApi.Queries;

public class GetPhotoByIdQuery : IRequest<byte[]>
{
  public int Id { get; set; }

  public GetPhotoByIdQuery(int id)
  {
    Id = id;
  }
}

