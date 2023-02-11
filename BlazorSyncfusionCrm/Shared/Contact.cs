using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorSyncfusionCrm.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string NickName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
