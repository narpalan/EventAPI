# 🗓️ EventAPI - Sistema de Eventos com Geoprocessamento

API REST para gerenciamento de eventos, públicos ou privados, com funcionalidades de geoprocessamento, desenvolvida em .NET 8.

## 🚀 Funcionalidades

### 📋 Gestão de Eventos
- ✅ **CRUD Completo** de eventos com Entity Framework Core
- ✅ **Validações Robustas** - FluentValidation com regras customizadas
- ✅ **Arquitetura em Camadas** - Repository Pattern + Service Pattern
- ✅ **Migrações Estruturais** - Versionamento de schema com EF Core Migrations
- ✅ **Logging Estruturado** - Para melhor rastreamento em produção utilizando ILogger

### 🌍 Geoprocessamento
- ✅ **Busca por Proximidade** - Algoritmo de Haversine para eventos próximos
- ✅ **Modelo Geoespacial** - Coordenadas com precisão decimal(9,6) e índices otimizados
- ✅ **Cálculos de Distância** - Implementação eficiente para raios personalizados

### 🔧 Arquitetura & DevOps
- ✅ **Injeção de Dependência** - Configuração modular e testável
- ✅ **Documentação Interativa** - Swagger/OpenAPI com exemplos práticos
- ✅ **Configuração Multi-ambiente** - Desenvolvimento vs Produção
- ✅ **Entity Framework Core** - ORM com suporte a MariaDB/MySQL

## 🚧 Em Desenvolvimento

### 🛡️ Preparação para Produção
- 🔄 **Health Checks** - Endpoints `/health` e `/ready` para monitoramento
- 🔄 **Middleware de Segurança** - Headers de segurança e tratamento global de erros
- 🔄 **Configuração Railway** - Variáveis de ambiente e deploy optimization

### 📍 Serviços de Localização
- 🔄 **Geocodificação** - Integração com OpenStreetMap Nominatim
- 🔄 **API de Mapas** - Preparação para Leaflet + OpenStreetMap
- 🔄 **Validação de Endereços** - Serviço de geocodificação reversa

### ⚡ Performance & Otimização
- 🔄 **Cache em Memória** - Para consultas frequentes
- 🔄 **Compressão de Respostas** - Gzip para melhor performance
- 🔄 **Otimização de Consultas** - Query profiling e índices

## 🧭 Funcionalidades Futuras

### 👥 Sistema de Usuários & Autenticação
- 🔜 **CRUD de Usuários** - Gestão de perfis e autenticação
- 🔜 **Autorização JWT** - Controle de acesso baseado em roles
- 🔜 **Sistema de Favoritos** - Eventos favoritados e lista pessoal
- 🔜 **Perfis Personalizados** - Preferências e histórico

### 🔔 Notificações & Monitoramento
- 🔜 **Sistema de WatchPoints** - Pontos de vigilância para monitoramento
- 🔜 **Notificações em Tempo Real** - WebSocket para alertas imediatos
- 🔜 **Notificações por E-mail** - Alertas periódicos e resumos
- 🔜 **Sistema de Observação** - Monitoramento de áreas específicas

### 🗺️ Geoprocessamento Avançado
- 🔜 **Geofencing Avançado** - Polígonos complexos para áreas de vigilância
- 🔜 **Heatmaps Interativos** - Visualização de densidade de eventos
- 🔜 **Rotas e Direções** - Cálculo de rotas para eventos
- 🔜 **Geocodificação em Lote** - Processamento múltiplo de endereços

### 📊 Análise & Engajamento
- 🔜 **Sistema de Reviews/Avaliações** - Feedback e ratings para eventos
- 🔜 **Relatórios e Estatísticas** - Analytics e métricas de uso
- 🔜 **Sistema de Recomendação** - Algoritmo baseado em comportamento
- 🔜 **Compartilhamento Social** - Integração com redes sociais

### 🐳 Infraestrutura & Escala
- 🔜 **Dockerização** - Containerização completa da aplicação
- 🔜 **Paginação Avançada** - Cursor-based pagination para grandes datasets
- 🔜 **API Versioning** - Controle de versões da API
- 🔜 **Rate Limiting** - Limitação de requisições por usuário

### 🔍 Buscas & Filtros
- 🔜 **Filtros Avançados** - Por data, categoria, preço, etc.
- 🔜 **Busca Full-Text** - Pesquisa semântica em títulos e descrições
- 🔜 **Salvar Pesquisas** - Histórico e pesquisas favoritas

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
Thiago Fumega - Desenvolvedor Full-Stack 