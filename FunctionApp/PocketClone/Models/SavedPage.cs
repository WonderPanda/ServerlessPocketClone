using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketClone.Models
{
    public class SavedPage
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
    }
}
