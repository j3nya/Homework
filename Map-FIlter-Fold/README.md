# Map, filter and fold.
Functions applied to the list of numbers and functions working with its elements.
## Functionality
* Map returns a list of the results of applying the input function to each element.
* Filter returns the list of elements for which the boolean function returned true
* Fold returns the cumulative value obtained after the whole pass of the list.
## How to use
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
