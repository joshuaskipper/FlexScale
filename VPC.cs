using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppRetry
{
    class VPC
    {
        public int ID { get; set; }
        public List<GuestNetwork> GuestNetworks { get; set; }

        public VPC(int id) 
        {
            ID = id;
            GuestNetworks = new List<GuestNetwork>();
        }

        
    }
}
