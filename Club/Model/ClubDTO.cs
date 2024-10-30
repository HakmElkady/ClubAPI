using System.ComponentModel.DataAnnotations;

namespace Club.Model
{
    public class ClubDTO
    {
        public int ClubId { get; set; }

        [Required, MaxLength(50)]
        public string ClubName { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

    }
}
