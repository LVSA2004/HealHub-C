using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealHub.Models
{
    public class Form
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int userId { get; set; }
        public string age { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string symptoms { get; set; }
        public string duration { get; set; }
        public string diseaseHistory { get; set; }
    }
}
