using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Validation
{
    public class ValidUrlAttribute : ValidationAttribute
    {
        public ValidUrlAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var text = value as string;
            Uri uri;

            return (!string.IsNullOrWhiteSpace(text) && Uri.TryCreate(text, UriKind.Absolute, out uri));
        }
    }
}
