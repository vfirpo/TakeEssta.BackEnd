using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class PageItems<T>
    {
        public int RecordCounts { get; set; }

        public int CurrentPage { get; set; }

        public IList<T> Items { get; set; }
    }
}
