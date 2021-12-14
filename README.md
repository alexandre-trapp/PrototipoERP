# PrototipoERP
PrototipoERP apis em dotnet 6

- necessário download do git em: https://git-scm.com/downloads
- Visual Studio 2022 (Comunitty se pra uso pessoal): https://visualstudio.microsoft.com/pt-br/downloads/ ou Visual Studio Code: https://code.visualstudio.com/download
- Na instalação do Visual Studio 2022 deve ser baixado o sdk do .Net 6, se usar o Visual Studio Code, necessário baixar o sdk em https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Após clonar o projeto com `git clone https://github.com/alexandre-trapp/PrototipoERP.git` 
- Abrir PrototipoERP.sln
- Executar (F5)
- Abrirá no navegador a documentação das APIs com Swagger, necessário criar um usuário na api POST/api/usuarios e efetuar a autenticação com o usuário e senha 
em api/auth, retornando o token bearer jwt, passando esse token com o bearer + espaço + token no botão **Authentication** 
