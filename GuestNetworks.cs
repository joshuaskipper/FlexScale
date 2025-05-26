using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppRetry
{
    class GuestNetwork
    {
        public int ID { get; set; }
        public int Instance { get; set; }
        public int CPU { get; set; }
        public int Memory { get; set; }
        public int Storage { get; set; }
        public bool LoadBalancer { get; set; }

        public GuestNetwork(int id, int instance, int cpu, int memory, int storage, bool loadbalancer) 
        {
            ID = id;
            Instance = instance;
            CPU = cpu;
            Memory = memory;
            Storage = storage;
            LoadBalancer = loadbalancer;
        }
    }
}
