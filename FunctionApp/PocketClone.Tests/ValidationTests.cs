using NUnit.Framework;
using PocketClone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xunit;

namespace PocketClone.Tests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void CanValidate()
        {
            var savedPage = new SavedPage();
            var context = new ValidationContext(savedPage, null, null);

            var results = new List<ValidationResult>();
            var test = Validator.TryValidateObject(savedPage, context, results);

            "".ToString();
        }
    }
}
