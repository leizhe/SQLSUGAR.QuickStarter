using System.Collections.Generic;

namespace SS.Application.Output
{
    public class GetResults<T> : OutputBase
    {
        public int Total { get; set; }

        public List<T> Data { get; set; }
    }
}