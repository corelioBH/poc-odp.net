# Oracle OPD.NET
Um pequeno programa em console C# que realiza as funções básicas de um CRUD.

## Começando
Para começar, são necessários alguns passos:
- Instalar o driver Oracle ODP.NET disponível no site: http://www.oracle.com/technetwork/topics/dotnet/downloads/index.html
- Criar uma tabela simples no seu banco de dados através do comando SQL: 
```sh
CREATE TABLE "PEOPLE" 
   (	"ID" NUMBER, 
	    "NAME" VARCHAR2(200 BYTE),
	     CONSTRAINT people_pk PRIMARY KEY (ID)
   );
```
- Editar os parâmetros no arquivo Program.cs para atender à sua conexão

Pronto, agora é só executar e utilizar.
Obs.: Caso ocorra algum erro de referência, inclua a referência 'Oracle.ManagedDataAccess' clicando com botão direito no projeto e escolha o submenu 'Add'.
