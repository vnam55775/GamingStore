using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.Models.ViewModels
{
    public class GamingListViewModel
    {
        public IEnumerable<Gaming> Gamings { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentGenre { get; set; }
    }
}
