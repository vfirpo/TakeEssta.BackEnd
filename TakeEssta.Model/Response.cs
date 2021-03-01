using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public enum MessageType
    {
        OK = 0,
        Error = 1,
        Alert = 2,
        Info = 3

    }
    public class Response<T>
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }

        public object Value { get; set; }

        public IList<T> Items { get; set; }

        public T Item { get; set; }
    }
}
