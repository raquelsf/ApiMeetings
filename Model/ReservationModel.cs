using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMeetings.Model
{
  public class ReservationModel
  {
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    public Guid RoomId { get; set; }

    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    public DateTime DateInitial { get; set; }


    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    public DateTime DateEnd { get; set; }
  }
}
