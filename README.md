# Desafio AeC Automação

## Descrição do projeto

O projeto consiste em realizar a abertura automática do site da [AeC](https://aec.com.br/), 
enviar através do campo de busca o termo *“Automação”* e efetuar a gravação do retorno obtido no banco de dados.

#### Dados armazenados:
 
- Título;
- Área;
- Autor;
- Descrição;
- Data de Publicação;

## Pré-requisitos

- [ ] Que o código seja feito em C#;
- [ ] Utilização do *framework* Selenium;
- [ ] Utilização da abordagem DDD com injeção de dependência;
- [ ] Utilização de métodos assíncronos

## Decisões técnicas

### SQL Server Express LocalDB

O banco de dados utilizado foi o [*SQL Server Express LocalDB*](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16). É possível habilitá-lo na instalação do Visual Studio ou através do Visual Studio Installer, ou ainda, através do download da mídia de instalação.

É um recurso voltado para desenvolvedores para facilitar a criação e a utilização de banco de dados no próprio computador e que facilita a execução da aplicação sem a necessidade de alguma instância mais robusta e/ou que exija licença ou assinatura.

É possível facilmente alterar a conexão de string para outro banco de dados SQL Server onpremisse ou cloud como Microsoft Azure SQL Database.

# Fluxo da aplicação

## Get started

## Git Flow

