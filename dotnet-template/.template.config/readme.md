# dotnet new

## Installation

```bash
cd dotnet-template
dotnet new -i .\
```

Then generate your new model:

```bash
cd src
dotnet new model --ModelName=Book --DbTableName=Books --ServiceName=BookService --WithTest=true
```