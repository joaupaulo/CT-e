# Nome do Projeto

![Badge de Status do Projeto](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow)

## Descrição do Projeto

Este projeto é uma aplicação .NET que implementa diversas APIs para gerenciamento de transportadoras, motoristas, CTes (Conhecimento de Transporte Eletrônico) e alíquotas de ICMS. Cada API foi desenvolvida para atender a funcionalidades específicas, conforme descrito abaixo.

## Índice

- [APIs Implementadas](#apis-implementadas)
  - [ObterCtePorId](#obtercteporid)
  - [ObterIcmsAliquota](#obtericmsaliquota)
  - [ObterMotoristaPorId](#obtermotoristaporid)
  - [ObterTransportadoraPorId](#obtertransportadoraporid)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Como Contribuir](#como-contribuir)
- [Licença](#licença)

## APIs Implementadas

### ObterCtePorId

**Descrição:** Recupera um Conhecimento de Transporte Eletrônico (CTe) específico com base no ID fornecido.

**Endpoint:** `GET /api/cte/{id}`

**Parâmetros:**
- `id` (int): Identificador único do CTe.

**Resposta:**
- `200 OK`: Retorna os detalhes do CTe no formato `CteDto`.
- `404 Not Found`: Caso o CTe não seja encontrado.

### ObterIcmsAliquota

**Descrição:** Obtém a alíquota do ICMS com base nas UF de origem e destino.

**Endpoint:** `GET /api/icms?ufOrigem={ufOrigem}&ufDestino={ufDestino}`

**Parâmetros:**
- `ufOrigem` (string): Sigla da Unidade Federativa de origem.
- `ufDestino` (string): Sigla da Unidade Federativa de destino.

**Resposta:**
- `200 OK`: Retorna a alíquota do ICMS como um valor decimal.
- `404 Not Found`: Caso a alíquota não seja encontrada.

### ObterMotoristaPorId

**Descrição:** Recupera as informações de um motorista específico com base no ID fornecido.

**Endpoint:** `GET /api/motorista/{id}`

**Parâmetros:**
- `id` (int): Identificador único do motorista.

**Resposta:**
- `200 OK`: Retorna os detalhes do motorista.
- `404 Not Found`: Caso o motorista não seja encontrado.

### ObterTransportadoraPorId

**Descrição:** Recupera as informações de uma transportadora específica com base no ID fornecido.

**Endpoint:** `GET /api/transportadora/{id}`

**Parâmetros:**
- `id` (int): Identificador único da transportadora.

**Resposta:**
- `200 OK`: Retorna os detalhes da transportadora.
- `404 Not Found`: Caso a transportadora não seja encontrada.

## Tecnologias Utilizadas

- .NET 5
- ASP.NET Core
- MediatR
- Entity Framework Core
- Moq (para testes unitários)

## Como Executar o Projeto

1. **Pré-requisitos:**
   - [Docker](https://docs.docker.com/get-docker/)
   - [Docker Compose](https://docs.docker.com/compose/install/)
   - [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

2. **Clonar o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio

