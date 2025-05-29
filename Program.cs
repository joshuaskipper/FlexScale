using Humanizer;
using System;
using System.IO;

namespace CloudAppRetry 
{
    class Program
    {
        static void Main(string[] args) 
        {
            //creating filepath
            string filepath = "GuestNetworks.txt";

            List<Project> allProjects = new List<Project>();
            List<VPC> allVPCS = new List<VPC>();
            List<GuestNetwork> allGuestNetworks = new List<GuestNetwork>();
            //Just adding the date
            Console.WriteLine($"{DateTime.Today.ToString("D")}");

            // Grabbing the project name
            Console.WriteLine("\nWhat is your project name?");
            var projName = Console.ReadLine();

            Console.WriteLine($"\nAdd a description for {projName}");
            var projDesc = Console.ReadLine();
            int projVPC;
            Console.WriteLine($"\nHow many VPCS for {projName}");
            while(!int.TryParse(Console.ReadLine(), out projVPC)) 
            {
                Console.WriteLine("Invalid value, please enter a numeric value.");
            }
            Project myProject = new Project(projName, projDesc);


            for (int i = 1; i <= projVPC; i++) 
            {
                VPC myVPC = new VPC(i);
                myProject.VPCS.Add(myVPC);
                allVPCS.Add(myVPC);
                int projGuestNetworks;
                Console.WriteLine($"\nHow many Guest Networks for your {i.Ordinalize()} VPC?");
                while (!int.TryParse(Console.ReadLine(), out projGuestNetworks)) 
                {
                    Console.WriteLine("Invalid value, please enter a numeric value.");
                }
                for (int j = 1; j <= projGuestNetworks; j++) 
                {
                    int projInstance;
                    int projCPU;
                    int projMemory;
                    int projStorage;
                    bool projLoadBalancer;
                    Console.WriteLine($"\nHow many Instances for your {j.Ordinalize()} Guest Network?");
                    while (!int.TryParse(Console.ReadLine(), out projInstance))
                    {
                        Console.WriteLine("Invalid value, please enter a numeric value.");
                    }
                    Console.WriteLine($"\nCPUs per Instance?");
                    while (!int.TryParse(Console.ReadLine(), out projCPU))
                    {
                        Console.WriteLine("Invalid value, please enter a numeric value.");
                    }
                    Console.WriteLine($"\nMemory per Instance?");
                    while (!int.TryParse(Console.ReadLine(), out projMemory))
                    {
                        Console.WriteLine("Invalid value, please enter a numeric value.");
                    }
                    Console.WriteLine($"\nPrimary Storage per Instance?");
                    while (!int.TryParse(Console.ReadLine(), out projStorage))
                    {
                        Console.WriteLine("Invalid value, please enter a numeric value.");
                    }
                    Console.WriteLine($"Does Guest Network {j} have a Load Balancer? (yes/no)");
                    if (Console.ReadLine().Trim().ToLower() == "yes")
                    {
                        projLoadBalancer = true;
                    }
                    else 
                    {
                        projLoadBalancer = false;
                    }
                    GuestNetwork myGN = new GuestNetwork(j,projInstance,projCPU, projMemory, projStorage, projLoadBalancer);
                    myVPC.GuestNetworks.Add(myGN);
                    allGuestNetworks.Add(myGN);
                }
                

            }
            int k = 0;
            Console.WriteLine(myProject.DisplayInfo());
            foreach (var project in myProject.VPCS) 
            {
                Console.WriteLine($"-------------VPC{project.ID}-------------");
                foreach (var guestnetwork in project.GuestNetworks) 
                {
                    k++;
                    Console.WriteLine($"GuestNetwork {k}");
                    Console.WriteLine($"Instance:{guestnetwork.Instance}");
                    Console.WriteLine($"CPUs:{guestnetwork.CPU * guestnetwork.Instance}");
                    Console.WriteLine($"Memory(GB):{guestnetwork.Memory * guestnetwork.Instance}");
                    Console.WriteLine($"Primary Storage(GB):{guestnetwork.Storage * guestnetwork.Instance}");
                    Console.WriteLine($"LoadBalancer:{(guestnetwork.LoadBalancer ? "Yes":"No")}\n");


                }
                Console.WriteLine($"------------------------------------------------------\n");
            }

            using (StreamWriter writer = new StreamWriter(filepath)) 
            {
                writer.WriteLine("GuestNetwork,Instance,CPUs,Memory,PrimaryStorage,LoadBalancer");
                foreach (var gn in allGuestNetworks) 
                {
                    writer.WriteLine(gn.DisplayGN());
                }
            }

                // At the very end of your Main method

                // Final Totals
                int totalVPCs = allVPCS.Count;
            int totalGuestNetworks = allGuestNetworks.Count;
            int totalInstances = 0;
            int totalCPUs = 0;
            int totalMemory = 0;
            int totalStorage = 0;
            int totalLoadBalancers = 0;

            foreach (var vpc in allVPCS)
            {
                foreach (var gn in vpc.GuestNetworks)
                {
                    totalInstances += gn.Instance;
                    totalCPUs += gn.CPU * gn.Instance;
                    totalMemory += gn.Memory * gn.Instance;
                    totalStorage += gn.Storage * gn.Instance;
                    if (gn.LoadBalancer) totalLoadBalancers++;
                }
            }

            // Display the totals
            Console.WriteLine("============== Final Totals ==============");
            Console.WriteLine($"Total VPCs: {totalVPCs}");
            Console.WriteLine($"Total Guest Networks: {totalGuestNetworks}");
            Console.WriteLine($"Total Instances: {totalInstances}");
            Console.WriteLine($"Total CPUs: {totalCPUs}");
            Console.WriteLine($"Total Memory (GB): {totalMemory}");
            Console.WriteLine($"Total Storage (GB): {totalStorage}");
            Console.WriteLine($"Total Load Balancers: {totalLoadBalancers}");
            Console.WriteLine("==========================================");


            //Added 5/28/2025 first post completion change
            //export data in txt file...



        }
    }
}
