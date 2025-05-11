# Homeworks during second semester
## Burrows-Wheeler transform
 The input is a string, the output of the program is a string transformed by the Burroughs-Wheeler algorithm and the position of the end of the string as a result of the transformation. An inverse transformation is also implemented, which accepts the transformed string and position and returns the original string
## Trie
Data structure for storing a set of strings.
#### Methods
* bool Add (returns true if such string was not in Trie)
* bool Contains
* bool Remove
* int HowManyStartsWithPrefix(string prefix)

## Lempel-Ziv-Welch compress algorithm
Works badly, still in procces
## Routers
#### Optimizing routers connectivity.
This is a console application that builds an optimal network configuration by describing the network topology from a text file.
#### Functionality
* Builds graph which represents the network from input text file
* Builds maximal spanning tree from built graph
* Describes tree representing optimized network in output file
#### How to use
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
## Map, Filter, Fold


Functions applied to the list of numbers and functions working with its elements.


#### Functionality


* Map returns a list of the results of applying the input function to each element.


* Filter returns the list of elements for which the boolean function returned true


* Fold returns the cumulative value obtained after the whole pass of the list.


#### How to use


1. Build project: in the Map-Filter-Fold/Map-Filter-Fold run following command

``` bash
dotnet build
```


2. Add .dll reference in your .csproj file (Most likely containing in bin/Debug/net9.0):





``` csharp
<ItemGroup>
    <Reference Include="Map-Filter-Fold">
        <HintPath>{path to .dll file}</HintPath>
    </Reference>
</ItemGroup>
```


3. For the Map function, the arguments must consist of a list of elements and a function that accepts element of the same type as elements and returns element of the same type.


4. For the Filter function, the arguments must consist of a list of elements and a function that accept element of the same type and returns bool value.


5. For the Fold function, the arguments must consist of a list of elements, starting value (same type as elements) and function taking two elements and returning result of the operation on them.
## Parse tree

#### Calculate an arithmetic expression.


This is a console application that calculates an string parse tree representation from a text file.


#### Functionality


* Builds tree which is described in input text file


* Prints and expression


* Print result of calculation of the expression


#### How to use


Run the application by passing one arguments: input file path. The input file must contain a text description of the arithmetic expression of the following form:

({operator} {operand1} {operand2})

Example input can be seen in tests.
In the console app project root directory run following commands

```shell
dotnet build
```
```shell
dotnet run -- "inputfilepath"
```
## GUI Calculator
 A graphical calculator that calculates operations immediately (pressing “7”, “+” and “3” “+” will display “10 +”)
#### How to use
In the WinForms app root directory run following commands


```shell
dotnet build
```


```shell
dotnet run
```

