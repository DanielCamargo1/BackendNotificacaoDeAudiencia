# API de Gerenciamento de Audiências

Esta é uma API para gerenciar audiências, permitindo criar, visualizar, atualizar e excluir audiências. Além disso, fornece informações sobre o número total de audiências armazenadas.

## Funcionalidades

- **Criar Audiência**: Adiciona uma nova audiência ao sistema, fornecendo nome da audiência e quantidade de pessoas presentes.
- **Listar Audiências**: Retorna uma lista de todas as audiências armazenadas no sistema, incluindo detalhes como ID, nome e quantidade de pessoas.
- **Atualizar Audiência**: Permite atualizar os detalhes de uma audiência existente.
- **Excluir Audiência**: Remove uma audiência do sistema com base no seu ID.
- **Obter Total de Audiências**: Retorna o número total de audiências armazenadas no sistema.

  ## Peculiaridades

- **Horário** O projeto só executará as informações se estiver no horário programado, pois assim, evitando audiencias que estejam fora do horario do evento.

## Rotas da API

- `GET `: Retorna todas as audiências armazenadas.
- `POST `: Cria uma nova audiência.
- `GET {id}`: Retorna uma audiência específica com base no seu ID.
- `PUT {id}`: Atualiza os detalhes de uma audiência existente.
- `DELETE {id}`: Exclui uma audiência com base no seu ID.
- `DELETE `: Exclui todas as audiências que estão no banco de dados.

## Pré-requisitos

- .NET Core 3.1 ou superior
- Entity Framework Core
- Um banco de dados SQL Server configurado e acessível para armazenar as audiências.

## Configuração do Banco de Dados

1. Atualize a string de conexão no arquivo `appsettings.json` com os detalhes do seu banco de dados SQL Server.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "SuaStringDeConexaoAqui"
     }
   }
