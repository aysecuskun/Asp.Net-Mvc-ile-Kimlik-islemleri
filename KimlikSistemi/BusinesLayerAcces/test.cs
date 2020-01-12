using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayerAcces
{
 public class Test { 
    
        public Test()
        {
            DataAccesLayer.DataBaseContext db = new DataAccesLayer.DataBaseContext();
            db.Database.CreateIfNotExists();
        }
    
    }
}
