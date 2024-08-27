# GraphQL Template Api

You can see how to do a template with .Net in [Microsoft:Custom Templates](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)

So you could create a template in the same way as:
```bash
dotnet new install Microsoft.Azure.WebJobs.ProjectTemplates
```

So you need to run the next steps:
Install this template:
```bash
dotnet new install .
```

If this template is updated, you can use command bellow:
```bash
dotnet new update .
```

To create a project with this template, use:
```bash
dotnet new graphql-api -n Product
```

Install EF
```bash
dotnet tool install --global dotnet-ef
```

This project uses .env variables
```env
DB_NAME=template-cs-staging

DB_HOST=localhost

DB_PORT=5432

DATABASE_USER=user-template

DATABASE_PASSWORD=t3mpl4t3
```