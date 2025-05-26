# Cloud Infrastructure Design App

This console application allows users to design and summarize a cloud infrastructure project by collecting input on virtual private clouds (VPCs), guest networks, and instance specifications such as CPU, memory, storage, and load balancers. The app then outputs a detailed summary and final totals.

## Features

- Collect project name and description
- Add multiple VPCs to a project
- Add multiple guest networks within each VPC
- Specify instances, CPUs, memory, storage, and load balancer settings
- Summarize details for each VPC and guest network
- Display final totals including:
  - Total VPCs
  - Total guest networks
  - Total instances
  - Total CPUs
  - Total memory (GB)
  - Total storage (GB)
  - Total load balancers

## Usage

1. Download all files except README.md and place them in a folder.
2. Open the folder in your C# development environment (preferably Visual Studio Code or Visual Studio).
3. Run the application.
4. Follow the console prompts to enter your project details.
5. View the summary and final totals in the console output.

## Sample Flow

- Enter project name and description.
- Specify the number of VPCs.
- For each VPC, enter:
  - Number of guest networks.
  - For each guest network:
    - Number of instances.
    - CPUs, memory, and storage per instance.
    - Whether a load balancer is included.
- View a detailed breakdown and final resource totals.

## Prerequisites

- .NET (compatible with your environment)
- Humanizer library (`using Humanizer;`)

## License

This project is open-source and available under the MIT License.

## Acknowledgements

This app was inspired by a project idea discussed with a mentor and further developed for hands-on learning in C#.
