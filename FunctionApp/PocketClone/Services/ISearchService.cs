using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketClone.Services
{
    public interface ISearchService
    {
        Task IndexItem(object item);
    }
}
