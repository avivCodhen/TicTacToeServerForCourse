using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class RequestModel
    {
        public int x { get; set; }
        public int y { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Room { get; set; }
    }
}