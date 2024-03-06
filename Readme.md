### Proyecto con Arquitectura N-Capas orientada a dominio

Este proyecto fue realizado siguiendo el curso de Arquitectura de Aplicaciones Empresariales, donde se explica el uso de diferentes patrones y NuGets para la base de un proyecto API Rest en ASP.NET.

#### Patrones de diseño utilizados:

- Patrón Health Check
- Patrón Repository y Unit of Work
- Rate Limiting

Además, se implementaron:

- Versionado
- Docker
- Validaciones con Fluent Validator
- Pruebas Unitarias con MSTest
- JWT
- Redis
- Arquitectura Limpia
- RabbitMQ
- SendGrid
- Swagger y ReDoc
- Bogus

### Tecnologías

El proyecto utiliza varias tecnologías de código abierto:

- [Visual Studio](https://visualstudio.microsoft.com/es/downloads/): Editor de código
- [ASP.NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0): Construcción de API REST y Biblioteca de clases
- [Docker](https://www.docker.com/): Para crear la imagen de la aplicación
- [SQL Server](https://www.microsoft.com/en-us/sql-server): Base de datos

### Instalación

Para ejecutar el proyecto, es necesario contar con:

- [SDK .NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0) y [ASP.NET Core Runtime](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)
- SQL Server
- Docker

#### Instalación de Redis con Docker

Puede instalar Redis utilizando Docker ejecutando los siguientes comandos:

```bash
docker pull redis
docker run --name mi-redis -d -p 6379:6379 redis
```

#### Instalación de RabbitMQ con Docker

Puede instalar RabbitMQ utilizando Docker ejecutando los siguientes comandos:

```bash
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management
```
Luego, agregue al archivo appsettings.json los valores para las variables de entorno:
```
{
  "ConnectionStrings:NorthwindConnection": "Data Source=HOST;Initial Catalog=databaseName;Integrated Security=False;Trusted_Connection=True;TrustServerCertificate=True",
  "ConnectionStrings:RedisConnection": "localhost:6379,user=default,password=123456,ssl=False,abortConnect=False",
  "Config": {
    "OriginCors": "http://localhost:60468",
    "Secret": "a", 
    "Issuer": "a",
    "Audience": "a"
  },
  "HealthChecksUI": {
    "HealthChecks": [
      {
        "Name": "Health Checks API",
        "Uri": "/health"
      }
    ],
    "EvaluationTimeInSeconds": 5
  },
  "RateLimiting": {
    "PermitLimit": 4,
    "Window": 30,
    "QueueLimit": 0
  },
  "RabbitMqOptions": {
    "HostName": "localhost",
    "VirtualHost": "/",
    "UserName": "guest",
    "Password": "guest"
  },
  "Sendgrid": {
    "ApiKey": "", 
    "FromEmail": "", 
    "FromUser": "", 
    "SandboxMode": "false",
    "ToAddress": "", 
    "ToUser": ""
  }
}
```

Asegúrese de reemplazar las variables HOST, databaseName y los valores para Redis, Sendgrid y JWT con la configuración adecuada.