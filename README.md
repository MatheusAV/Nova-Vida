# Sistema de Gerenciamento Escolar

# Descrição

Este projeto é um sistema de gerenciamento escolar projetado para facilitar a administração de informações relacionadas a professores e alunos. O sistema oferece uma interface intuitiva para o gerenciamento de cadastros, permitindo operações como criação, listagem, edição e exclusão de registros de professores e alunos. Com recursos de paginação integrados, o sistema garante uma navegação fluida e eficiente, tornando o acesso aos dados organizado e escalável.

# Funcionalidades

# Cadastro de Professores: 
Permite adicionar novos professores ao sistema, especificando detalhes como nome, departamento e matéria lecionada.
# Listagem de Professores: 
Exibe todos os professores registrados, com suporte a paginação para fácil visualização.
# Edição de Professores: 
Proporciona a modificação de informações de professores existentes.
# Exclusão de Professores: 
Oferece a opção de remover professores do sistema.

# Listagem de Alunos: 
Mostra uma lista dos alunos cadastrados com informações como mensalidade e data de vencimento, também com suporte a paginação.
# Exclusão de Alunos: 
Habilita a remoção de alunos do sistema.

# Tecnologias Utilizadas
Front-end: Angular CLI: 16.1.8 Node: 18.13.0
Back-end: ASP.NET Core Web API 6.0
Banco de dados: MySQL
# Como Executar back-end

# 1-Configuração da String de Conexão:
Abra o arquivo appsettings.json localizado na raiz do projeto API. Modifique a propriedade ConnectionStrings com os detalhes de conexão ao seu banco de dados MySQL.
"ConnectionStrings": {
  "App": "Server=localhost;Port=3306;Database=Cadastros;Uid=root;Pwd=Root;pooling=false;Convert Zero DateTime=True;"
},

# 2-Geração das Migrações:
Geração das Migrações:
Utilize o Package Manager Console do Visual Studio para criar a migração inicial do banco de dados. Certifique-se de que o console está configurado para usar o projeto NovaVidaRepository como o projeto padrão e NovaVidaAPI como o projeto de inicialização. Execute o seguinte comando para criar a migração:

Add-Migration Init-Project -Project NovaVidaRepository -StartupProject NovaVidaAPI -Context DbContextApplication

# 3-Aplicação das Migrações e Criação do Banco de Dados:
Após a criação da migração, você deve aplicá-la para efetivamente criar o banco de dados e suas tabelas correspondentes. Ainda no Package Manager Console, execute o comando:

Update-Database -Context DbContextApplication -Project NovaVidaRepository -StartupProject NovaVidaAPI 

Certifique-se de que, após a execução dos scripts fornecidos, o banco de dados e as tabelas necessárias estejam devidamente criados. Em seguida, você pode proceder com a construção (build) do backend. Uma vez que o backend esteja em execução, o Swagger estará disponível, permitindo que você visualize e teste as rotas da API de maneira interativa.

# Como Executar Front-end

1- Instale as dependências do projeto com npm install para o front-end.
2- Execute a aplicação de front-end com ng serve.
3- Acesse a aplicação pelo navegador em http://localhost:4200.
