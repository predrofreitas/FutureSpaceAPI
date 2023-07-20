
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Launcher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid LaunchId { get; set; }
        public string LaunchJson { get; set; }
        public DateTime ImportDate { get; set; }
    }
}