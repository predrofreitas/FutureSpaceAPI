# FutureSpaceAPI

```markdown
# FutureSpaceAPI - Controlador de Lançadores

Bem-vindo à FutureSpaceAPI! Este documento fornece uma visão geral do Controlador de Lançadores, que gerencia lançadores, seus status e operações. O Controlador de Lançadores é uma parte da aplicação FutureSpaceAPI e permite que os usuários interajam com dados de lançadores.

## Sumário

1. [Introdução](#introdução)
2. [Endpoints da API](#endpoints-da-api)
   - [Obter Status da API](#obter-status-da-api)
   - [Obter Lançador por ID](#obter-lançador-por-id)
   - [Atualizar Lançador](#atualizar-lançador)
   - [Excluir Lançador](#excluir-lançador)
   - [Obter Lançadores com Paginação](#obter-lançadores-com-paginação)
   - [Agendar Tarefa Recorrente](#agendar-tarefa-recorrente)
3. [Autenticação](#autenticação)
4. [Tratamento de Erros](#tratamento-de-erros)

## 1. Introdução

O Controlador de Lançadores é responsável por gerenciar lançadores, fornecer informações sobre lançadores, atualizar dados de lançadores, excluir lançadores e agendar tarefas recorrentes para executar serviços de lançadores.

## 2. Endpoints da API

### Obter Status da API

**Endpoint:** `GET /launcher`

Descrição: Obter o status da API.

Exemplo de Requisição:
```http
GET /launcher
```

Exemplo de Resposta:
```json
{
    "status": "REST Back-end Challenge 20201209 Rodando"
}
```

### Obter Lançador por ID

**Endpoint:** `GET /launcher/{launcherId}`

Descrição: Obter um lançador pelo seu identificador exclusivo.

Parâmetros:
- `launcherId` (GUID): O identificador exclusivo do lançador.

Exemplo de Requisição:
```http
GET /launcher/123e4567-e89b-12d3-a456-426655440000
```

Exemplo de Resposta (200 OK):
```json
{
  "id": "9279744e-46b2-4eca-adea-f1379672ec81",
  "url": "https://ll.thespacedevs.com/2.2.0/launch/9279744e-46b2-4eca-adea-f1379672ec81/",
  "launch_library_id": 1829,
  "slug": "atlas-lv-3a-samos-2",
  "name": "Atlas LV-3A | Samos 2",
  "status": {
    "id": 3,
    "name": "Success"
  },
  "net": "1961-01-31T20:21:19Z",
  "window_end": "1961-01-31T20:21:19Z",
  "window_start": "1961-01-31T20:21:19Z",
  "inhold": false,
  "tbdtime": false,
  "tbddate": false,
  "probability": 0,
  "holdreason": "",
  "failreason": "",
  "hashtag": "",
  "launch_service_provider": {
    "id": 161,
    "url": "https://ll.thespacedevs.com/2.2.0/agencies/161/",
    "name": "United States Air Force",
    "type": "Government"
  },
  "rocket": {
    "id": 2362,
    "configuration": {
      "id": 183,
      "launch_library_id": 193,
      "url": "https://ll.thespacedevs.com/2.2.0/config/launcher/183/",
      "name": "Atlas Agena B",
      "family": "Atlas",
      "full_name": "Atlas LV-3 Agena B",
      "variant": "LV-3 Agena B"
    }
  },
  "mission": null,
  "pad": {
    "id": 93,
    "url": "https://ll.thespacedevs.com/2.2.0/pad/93/",
    "agency_id": 161,
    "name": "Space Launch Complex 3W",
    "info_url": null,
    "wiki_url": "",
    "map_url": "http://maps.google.com/maps?q=34.644+N,+120.593+W",
    "latitude": "34.644",
    "longitude": "-120.593",
    "location": {
      "id": 11,
      "url": "https://ll.thespacedevs.com/2.2.0/location/11/",
      "name": "Vandenberg AFB, CA, USA",
      "country_code": "USA",
      "map_image": "https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_11_20200803142416.jpg",
      "total_launch_count": 83,
      "total_landing_count": 3
    },
    "map_image": "https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_93_20200803143225.jpg",
    "total_launch_count": 3
  },
  "webcast_live": false,
  "image": null,
  "infographic": null,
  "program": []
}

```

### Atualizar Lançador

**Endpoint:** `PUT /launcher/{launcherId}`

Descrição: Atualizar um lançador com novas informações.

Parâmetros:
- `launcherId` (GUID): O identificador exclusivo do lançador a ser atualizado.

Corpo da Requisição: As novas informações do lançador (em formato JSON).

Exemplo de Requisição:
```http
PUT /launcher/123e4567-e89b-12d3-a456-426655440000
Content-Type: application/json

{
    "launcherName": "Falcon 9",
    "launchDate": "2023-07-20T14:00:00Z",
    "status": "Em Andamento",
    "payload": "Satélite 2"
}
```

### Excluir Lançador

**Endpoint:** `DELETE /launcher/{launcherId}`

Descrição: Excluir um lançador pelo seu identificador exclusivo.

Parâmetros:
- `launcherId` (GUID): O identificador exclusivo do lançador a ser excluído.

Exemplo de Requisição:
```http
DELETE /launcher/123e4567-e89b-12d3-a456-426655440000
```

### Obter Lançadores com Paginação

**Endpoint:** `GET /launcher/launchers`

Descrição: Obter uma lista de lançadores com suporte a paginação.

Parâmetros:
- `page` (int): O número da página.
- `pageSize` (int): O número de itens por página.

Exemplo de Requisição:
```http
GET /launcher/launchers?page=1&pageSize=10
```

Exemplo de Resposta (200 OK):
```json
{
    "totalItems": 50,
    "currentPage": 1,
    "pageSize": 10,
    "launchers": [
        {
            "launcherId": "123e4567-e89b-12d3-a456-426655440000",
            "launcherName": "Falcon 9",
            "launchDate": "2023-07-20T12:00:00Z",
            "status": "Pronto",
            "payload": "Satélite 1"
        },
        // Mais lançadores...
    ]
}
```

### Agendar Job

**Endpoint:** `GET /launcher/RecurringJob`

Descrição: Agendar uma tarefa recorrente para executar serviços de lançadores diariamente.

Exemplo de Requisição:
```http
GET /launcher/RecurringJob
```

## 3. Autenticação

Para acessar os endpoints do Controlador de Lançadores, você precisa incluir uma chave de API no cabeçalho `Authorization` de suas solicitações HTTP. Utilize a "ApiKey" com valor "ApiSecretKey".

## 4. Tratamento de Erros

A API retorna códigos de status HTTP apropriados e mensagens de erro em caso de problemas. Aqui estão os códigos de status comuns e seus significados:

- 200 OK: A solicitação foi bem-sucedida.
- 400 Bad Request: A solicitação estava malformada ou inválida.
- 401 Unauthorized: A chave da API está ausente ou inválida.
- 404 Not Found: O recurso solicitado não foi encontrado.
- 500 Internal Server Error: Ocorreu um erro inesperado no servidor.

---

Boa exploração do cosmos! 🚀🌌
```
