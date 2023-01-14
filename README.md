# Avaliação de Materiais

# Rodar Front-end

`cd materials-evaluation-spa`
`ng serve`

# C# Scaffolds

`dotnet aspnet-codegenerator controller -name MaterialsController -async -api -m Material -dc DatabaseContext -outDir API/Controllers`

# Comandos

## Migrations

`dotnet ef migrations add NomeDaMigration`

`dotnet ef database update`
