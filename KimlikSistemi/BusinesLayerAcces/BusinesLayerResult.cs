using Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayerAcces
{
   
        public class BusinesLayerResult<T> where T : class
        {
            public List<string> Errors { get; set; }
            public T Result { get; set; }
            public BusinesLayerResult()
            {
                Errors = new List<string>();
            }

            internal void AddError(ErrorMessage userNotFound, string v)
            {
                throw new NotImplementedException();
            }
        }
    
}
