using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppRetry
{
    class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<VPC> VPCS { get; set; }

        public Project(string name, string description) 
        {
            Name = name;
            Description = description;
            VPCS = new List<VPC>();
        }

        public string DisplayInfo() 
        {
            return $"\nProject Name:{Name}\n\nVPC Count:{VPCS.Count}\n\nProject Description:{Description}\n";
        }

    }
}
