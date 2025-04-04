# Calculate an arithmetic expression.
This is a console application that calculates an string parse tree representation from a text file.
## Functionality
* Builds tree which is described in input text file
* Prints and expression
* Print result of calculation of the expression
## How to use
Run the application by passing one arguments: input file path. The input file must contain a text description of the arithmetic expression of the following form:

({operator} {operand1} {operand2})

Example input can be seen in tests.

In the project root directory run following commands
```shell
dotnet build
```
```shell
dotnet run -- "inputfilepath"
```
