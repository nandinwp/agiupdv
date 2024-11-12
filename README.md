
# Documentação do Projeto Agiu_PDV

## Sumário

1. [Visão Geral do Projeto](#visão-geral-do-projeto)
2. [Estrutura do Projeto](#estrutura-do-projeto)
3. [Dependências](#dependências)
4. [Configuração e Instalação](#configuração-e-instalação)
5. [Instruções para Executar o Projeto](#instruções-para-executar-o-projeto)
6. [Detalhes Técnicos](#detalhes-técnicos)
7. [Referências e Links Úteis](#referências-e-links-úteis)

---

## Visão Geral do Projeto

O **Agiu_PDV** é uma aplicação de Ponto de Venda (PDV) desenvolvida em Windows Forms com .NET e C#. Ela usa o PostgreSQL, Npgsql para comunicação com o banco de dados e integra um visualizador de relatórios com o ReportViewer para relatórios de vendas e clientes.

A aplicação permite:
- Gerenciar clientes
- Gerenciar produtos
- Registrar vendas e itens de vendas
- Gerar relatórios de transações

---

## Estrutura do Projeto

A estrutura de pastas do projeto foi organizada para separar as funcionalidades principais, facilitando a manutenção e a expansão do projeto. 

```plaintext
Agui_PDV/
├── Agiu_PDV.Data/Database          # Script para criar o banco de dados
│   ├── DatabaseContext.cs
│
├── Agiu_PDV.Models/                # Modelos de dados (entidades)
│   ├── Cliente.cs
│   ├── Produto.cs
│   ├── Venda.cs
│   └── VendaItem.cs
│
├── Agiu_PDV.Repositories/          # Repositórios para acesso a dados
│   ├── ClienteRepository.cs
│   ├── ProdutoRepository.cs
│   └── VendaRepository.cs
│
├── Agiu_PDV.Services/              # Camada de serviços para regras de negócios
│   ├── ClienteService.cs
│   ├── ProdutoService.cs
│   └── VendaService.cs
│
├── Agiu_PDV.UI/                    # Interface do usuário (formulários)
│   ├── MainWindows.cs
│   
│
└── Program.cs                      # Classe principal que inicializa a aplicação e configura o banco
```

---

## Dependências

Aqui estão as bibliotecas e pacotes necessários para o funcionamento da aplicação, com as versões recomendadas:

1. **Npgsql** (v4.1.9)
   - Biblioteca de driver para comunicação com PostgreSQL em C#.
   - Permite a conexão e execução de comandos SQL diretamente no banco PostgreSQL.
   - Instalação:
     ```bash
     Install-Package Npgsql -Version 4.1.9
     ```

2. **Npgsql.EntityFrameworkCore.PostgreSQL** (v3.1.18)
   - Extensão do Entity Framework Core para trabalhar com PostgreSQL.
   - Necessária para o mapeamento de entidades para o banco de dados PostgreSQL usando ORM.
   - Instalação:
     ```bash
     Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 3.1.18
     ```

3. **System.Runtime.CompilerServices.Unsafe** (v4.7)
   - Biblioteca de suporte para operações avançadas de manipulação de memória.
   - Algumas dependências podem exigir este pacote.
   - Instalação:
     ```bash
     Install-Package System.Runtime.CompilerServices.Unsafe -Version 4.7
     ```

4. **Microsoft.ReportingServices.ReportViewerControl.Winforms** (v150.1652.0)
   - Componente para exibir relatórios no Windows Forms.
   - Utilizado para a visualização de relatórios de vendas, clientes, etc.
   - Instalação:
     ```bash
     Install-Package Microsoft.ReportingServices.ReportViewerControl.Winforms -Version 150.1652.0
     ```

---

## Configuração e Instalação

### Banco de Dados PostgreSQL

1. **Criar o Banco de Dados**:
   - Crie um banco de dados no PostgreSQL que será usado pela aplicação. O nome padrão utilizado na `connectionString` é `AgiuPDV`, mas você pode alterá-lo conforme necessário.

2. **Configurar a String de Conexão**:
   - Configure a string de conexão na classe `Program.cs` com as credenciais corretas do seu banco de dados.
   - Exemplo de string de conexão:
     ```csharp
     string connectionString = "Host=localhost;Port=5432;Database=AgiuPDV;Username=agiupdv;Password=agiupdv";
     ```

3. **Executar o Script SQL**:
   - Execute o script SQL de criação de tabelas, que define as tabelas `clientes`, `produtos`, `vendas`, e `venda_itens`, para inicializar o banco de dados com a estrutura correta.

### Configuração no Visual Studio

1. Abra o projeto no Visual Studio.
2. Instale todas as dependências mencionadas usando o NuGet Package Manager.
3. Compile a solução para garantir que todos os pacotes estejam corretamente referenciados.

---

## Instruções para Executar o Projeto

1. Abra o Visual Studio e selecione o projeto `Agui_PDV`.
2. Compile o projeto para verificar se não há erros de build.
3. Certifique-se de que o banco de dados PostgreSQL está em execução.
4. Execute o projeto pressionando `F5` ou selecionando **Start** no menu.

---

## Detalhes Técnicos

### Repositórios

Cada repositório foi desenvolvido para lidar com uma entidade específica, isolando as operações de banco de dados da lógica de negócios e facilitando a manutenção do código. Exemplo:
- `ClienteRepository`: Gerencia operações de clientes.
- `ProdutoRepository`: Gerencia operações de produtos.
- `VendaRepository`: Gerencia operações de vendas.

### Serviços

A camada de serviços (`Service`) é responsável por implementar a lógica de negócios para cada entidade:
- `ClienteService`: Controla o gerenciamento de clientes.
- `ProdutoService`: Implementa operações e validações para produtos.
- `VendaService`: Realiza o processamento de vendas, incluindo validação de estoque e cálculos.

---

## Referências e Links Úteis

- [Documentação do Npgsql](https://www.npgsql.org/doc/index.html)
- [Entity Framework Core com PostgreSQL](https://docs.microsoft.com/ef/core/)
- [Microsoft ReportViewer para Windows Forms](https://docs.microsoft.com/sql/reporting-services/)
- [System.Runtime.CompilerServices.Unsafe](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/)

---
