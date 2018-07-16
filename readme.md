# GTN Module Editor
Application for editing AppXpress module exports from the GT-Nexus platform

## How to use

1. Download and run the program
2. Import a module by entering `import [path-to-zip-file]`
3. Select a working item path
   - In module root (command line starts with `/[module-name-here]>`)
     - Use `ls` to list design roots
     - Use `cd [design-type]` to select a design root
     - Use `cd [design-type]/[field-name]` to select a field root
   - In design root (line starts with `/[module-name-here]/[design-type-here]>`)
     - Use `ls` to list fields
     - Use `cd [field-name]` to go to a field root
     - Use `cd ..` to go back to the module root
   - In field root (line starts with `/[module-name-here]/[design-type-here]/[field-name-here]>`)
     - Use `cd ..` to go back to the design root
     - Use `cd ../..` to go back to the module root
4. Edit module, design, or field properties
   - Use `listp` to list the properties on the working item
   - Use `getp [key]` to get the current value of a property
   - Use `setp [key] [value]` to set the value of a property
5. Export your new module using `export [path-to-store-zip]`

## How to build

You will need to install the .NET Core using the instructions [here](https://www.microsoft.com/net/learn/get-started) to build this application.
Once you've edited the files you want to change, open the repository folder in a terminal and enter `dotnet run`. The .NET Core will build and launch the application automatically.
