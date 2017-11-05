using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Validation;

namespace PocketClone.Models
{
    public class SavedPage
    {
        [Required]
        public string Title { get; set; }
        
        [Url]
        public string Url { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}
