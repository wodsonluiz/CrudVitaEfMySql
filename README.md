# CrudVitaEfMySql 

## Requisitos
##### Install [dotnet 3.1.*](https://dotnet.microsoft.com/download/dotnet/3.1) 
##### Install [dotnet-ef](https://docs.microsoft.com/pt-br/ef/core/get-started/overview/install) 
##### Install [Docker](https://docs.docker.com/get-docker/) 

## Create database in Docker
```
cd CrudVitaEfMySql\resources\docker-support
docker-compose up -d
```

## Create migrations
```
cd CrudVitaEfMySql\src\CrudVitaEfMySql
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Run Application
```
cd CrudVitaEfMySql\src\CrudVitaEfMySql
dotnet run
```
![Screenshot_2](https://user-images.githubusercontent.com/13908258/115157599-84c8f880-a060-11eb-8ffd-4f976dbf43d6.png)

#### Open your browser and paste http://localhost:5000 and be very happy =)