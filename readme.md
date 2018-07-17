# GTN Module Editor
Application for editing AppXpress module exports from the GT-Nexus platform

## How to use

This application requires the .NET Core runtime.
Download and install it from [here](https://www.microsoft.com/net/download/dotnet-core/2.1) before continuing.
Use the "Build apps - SDK" column if you want to develop; otherwise use the "Run apps - Runtime" column to use this program.

1. Download and extract the release ZIP file for your system
2. Open a terminal in the extracted folder
3. Start the application by running `dotnet ModuleEditor.dll`
4. Import a module by entering `import [path-to-zip-file]`
5. Select a working item path
   - In module root (line starts with `/[module-name-here]>`)
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
6. Edit module, design, or field properties
   - Select target module/design/field as command path first
   - Use `listp` to list the properties on the working item
   - Use `getp [key]` to get the current value of a property
   - Use `setp [key] [value]` to set the value of a property
7. Remove unwanted designs or fields
   - With the design/field selected, use `rm` to remove it
8. Export your new module using `export [path-to-store-zip]`

## How to build

You will need to install the .NET Core using the instructions [here](https://www.microsoft.com/net/learn/get-started) to build this application.
Once you've edited the files you want to change, open the repository folder in a terminal and enter `dotnet run`. The .NET Core will build and launch the application automatically.
