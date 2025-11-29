# 🗓️ EventAPI - Sistema de Eventos com Geoprocessamento

API REST para gerenciamento de eventos, públicos ou privados, com funcionalidades de geoprocessamento, desenvolvida em .NET 8.

## 🚀 Funcionalidades

- ✅ **CRUD Completo** de eventos
- 🌍 **Geoprocessamento** - Busca de eventos por proximidade geográfica
- 📍 **Geocodificação** - Conversão de endereços em coordenadas (OpenStreetMap Nominatim)
- 🗺️ **Integração com Mapas** - Visualização em mapas interativos
- 🔍 **Filtros Avançados** - Por data, localização, categoria
- 📄 **Paginação** de resultados
- ✅ **Validações** com FluentValidation
- 🐳 **Docker Ready** - Pronta para containerização
- 📚 **Documentação Interativa** com Swagger/OpenAPI

## 🛠️ Tecnologias

- **.NET 8**
- **Entity Framework Core**
- **MariaDB/MySQL** (Pomelo.EntityFrameworkCore.MySql)
- **AutoMapper**
- **FluentValidation**
- **Swagger/OpenAPI**
- **xUnit** (Testes)

## 📋 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MariaDB/MySQL](https://mariadb.org/) ou Docker
- [Git](https://git-scm.com/)

## ⚡ Quick Start

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/event-api.git
cd event-api
```

### 2. Configure a conexão com o banco de dados

Crie um arquivo `appsettings.Development.json` na raiz do projeto com a seguinte estrutura:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=**your db server address**;Port=**your db port**;Database=**your database name**;User=**your database user**;Password=**your database password**;"
  }
}
```

### 3. Execute a aplicação
```bash
dotnet restore
dotnet run
```

A aplicação estará acessível em http://localhost:5050 e a documentação Swagger em http://localhost:5050/swagger.

## 📡 Endpoints da API

Eventos
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/events` | Lista todos os eventos |
| GET | `/api/events/{id}` | Busca evento por ID |
| POST | `/api/events` | Cria um novo evento |
| PUT | `/api/events/{id}` | Atualiza um evento |
| DELETE | `/api/events/{id}` | Exclui um evento |
| GET | `/api/events/nearby` | Eventos por proximidade geográfica |

## 👨‍💻 Autor
Thiago Fumega 