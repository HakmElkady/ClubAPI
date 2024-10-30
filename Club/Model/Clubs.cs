using System.ComponentModel.DataAnnotations;

namespace Club.Model
{
    public class Clubs
    {
        [Key]
        public int ClubId { get; set; }

        [Required , MaxLength(50)]
        public string ClubName { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        public DateTime PingTime { get; set; }

        public List<Employee> employees { get; set; }

    }
}
