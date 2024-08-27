# GraphQL Template Api

You can see how to do a template in .Net with this [link](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)

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
dotnet new msgql --db Product -n Product
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


 Boiler plate of hot chocolate with graphql. With this project, you are able to make many projects with the same structure
Topics
graphql template boilerplate csharp backend dotnet-core backend-api

```
dotnet pack --output nupkgs
```