using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMeetings.Model
{
  public class RoomModel
  {
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo {0} é Obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

    public string Description { get; set; }
    public int Floor { get; set; }
    public int MaxPeople { get; set; }
    public bool HasTV { get; set; }
    public bool HasPainting { get; set; }
  }
}
