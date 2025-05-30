using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CloudAppRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize file path
            string filepath = "GuestNetworks.txt";
            List<Project> allProjects = new List<Project>();
            List<VPC> allVPCS = new List<VPC>();
            List<GuestNetwork> allGuestNetworks = new List<GuestNetwork>();

            Console.WriteLine($"{DateTime.Today.ToString("D")}\n");

            string projName = ReadString("What is your project name?");
            string projDesc = ReadString($"\nAdd a description for {projName}");
            int projVPC = ReadInt($"\nHow many VPCs for {projName}?");

            Project myProject = new Project(projName, projDesc);
            allProjects.Add(myProject);

            for (int i = 1; i <= projVPC; i++)
            {
                VPC myVPC = new VPC(i);
                myProject.VPCS.Add(myVPC);
                allVPCS.Add(myVPC);

                int projGuestNetworks = ReadInt($"\nHow many Guest Networks for your {i.Ordinalize()} VPC?");
                for (int j = 1; j <= projGuestNetworks; j++)
                {
                    int projInstance = ReadInt($"\nHow many Instances for your {j.Ordinalize()} Guest Network?");
                    int projCPU = ReadInt("CPUs per Instance?");
                    int projMemory = ReadInt("Memory per Instance (GB)?");
                    int projStorage = ReadInt("Primary Storage per Instance (GB)?");
                    bool projLoadBalancer = ReadYesNo($"Does Guest Network {j} have a Load Balancer? (yes/no)");

                    GuestNetwork myGN = new GuestNetwork(j, projInstance, projCPU, projMemory, projStorage, projLoadBalancer);
                    myVPC.GuestNetworks.Add(myGN);
                    allGuestNetworks.Add(myGN);
                }
            }

            // Generate contents for file output
            StringBuilder output = new StringBuilder();
            int k = 0;

            output.AppendLine(myProject.DisplayInfo());

            foreach (var vpc in myProject.VPCS)
            {
                output.AppendLine($"*VPC{vpc.ID}");
                foreach (var gn in vpc.GuestNetworks)
                {
                    k++;
                    output.AppendLine($"GuestNetwork {k}");
                    output.AppendLine($"Instance: {gn.Instance}");
                    output.AppendLine($"CPUs: {gn.CPU * gn.Instance}");
                    output.AppendLine($"Memory(GB): {gn.Memory * gn.Instance}");
                    output.AppendLine($"Primary Storage(GB): {gn.Storage * gn.Instance}");
                    output.AppendLine($"LoadBalancer: {(gn.LoadBalancer ? "Yes" : "No")}\n");
                }
                output.AppendLine("------------------------------------------------------\n");
            }



            // Final Totals
            int totalInstances = 0, totalCPUs = 0, totalMemory = 0, totalStorage = 0, totalLoadBalancers = 0;

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

            output.AppendLine("============== Final Totals ==============");
            output.AppendLine($"Total VPCs: {allVPCS.Count}");
            output.AppendLine($"Total Guest Networks: {allGuestNetworks.Count}");
            output.AppendLine($"Total Instances: {totalInstances}");
            output.AppendLine($"Total CPUs: {totalCPUs}");
            output.AppendLine($"Total Memory (GB): {totalMemory}");
            output.AppendLine($"Total Storage (GB): {totalStorage}");
            output.AppendLine($"Total Load Balancers: {totalLoadBalancers}");
            output.AppendLine("==========================================");

            File.WriteAllText(filepath, output.ToString());
            Console.WriteLine(output.ToString());


        }

        // Repeat methods
        static int ReadInt(string prompt)
        {
            int value;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
            return value;
        }

        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        static bool ReadYesNo(string prompt)
        {
            Console.WriteLine(prompt);
            string response = Console.ReadLine().Trim().ToLower();
            return response == "yes" || response == "y";
        }
    }
}
