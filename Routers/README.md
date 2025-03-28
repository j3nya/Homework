# Optimizing routers connectivity.
This is a console application that builds an optimal network configuration by describing the network topology from a text file.
## Functionality
* Builds graph which represents the network from input text file
* Builds maximal spanning tree from built graph
* Describes tree representing optimized network in output file
## How to use
Run the application by passing two arguments: input and output file paths. The input file must contain a text description of the network configuration of the following form:

{router1 number}: {router2 number} ({bandwidth}), ..., {routerN number} ({bandwidth})

Example input can be seen in tests.

In the project root directory run following commands
```shell 
dotnet build
```
```shell
dotnet run -- "inputfilepath" "outputfilepath"
```