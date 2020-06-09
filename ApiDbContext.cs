using Microsoft.EntityFrameworkCore;

namespace ApiMeetings.Model
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<RoomModel> Rooms { get; set; }
  }
}
