# Avaliação de Materiais

Sistema para avaliação de qualidade.

Voltado para lotes de materiais que possuem visões de qualidade. O sistema possui cadastros de materiais, características de qualidade, visões de qualidade e lotes de materiais. A partir disso é calculado se cada lote está dentro da faixa, ou seja, atende todos os critérios.

## Iniciar o Projeto

O projeto foi desenvolvido utilizando Docker. Suba o docker-compose e o projeto estará rodando no endereço: `http://localhost:4200`.

Comando para iniciar o Docker:

`docker compose -f "docker-compose.yml" up -d --build`

## Disclaimer

Foi a primeira vez que programei pra valer em .NET e Angular. Por conta disso, podem ter erros de estilo por não estar acostumado com C# (ainda), e provavelmente há jeitos mais fáceis de fazer certas conversões, por exemplo nos DTOs. Por conta disso, acabaram faltando alguns itens necessários para a total conclusão do projeto. Agora que entendi como funciona o .NET, provavelmente o tempo seria cortado pela metade (muito do tempo foi gasto entendendo configuração de framework e etc). No entanto o saldo é positivo, consegui um bom conhecimento inicial em C# e Angular e estou pronto para aprender mais a fundo tais ferramentas.

### Tarefas Concluídas

- [x] ~Modelagem do domínio com Event Storming~
- [x] ~Adicionar Docker ao Angular + .Net
- [x] ~Adicionar Lint ao .NET e Angular (CI/CD)~
- [x] ~Adicionar CQRS e Arquitetura Hexagonal usando injeção de dependencias (AutoFac)
- [x] ~Adicionar migrations com Entity Framework~
- [x] ~Adicionar SQL Server + conexão Entity Framework ao projeto~
- [x] ~CRUD de Materiais~
- [x] ~CRUD de Características de Qualidade~
- [x] ~CRUD de Visões de Qualidade~
- [x] ~CRUD de Lotes~
- [x] ~CRUD de Ensaios de qualidade - com form obedecendo a visão~
- [x] ~Criar templante em Angular com Angular Material~
- [x] ~Adicionar validação de Inputs com FluentValidation~

### Tarefas Futuras

- [ ] Adicionar .env ao Angular e .NET
- [ ] Adicionar Flexbox aos formulários e organizar corretamente os inputs
- [ ] Adicionar EventBus
- [ ] Calcular Resultado de Qualidade do Lote && Enviar Email(MailKit) como Notificação
- [ ] Corrigir CI do NodeJS
- [ ] Migrar "Materiais" E "Características" para Arquitetura Hexagonal (Atualmente tudo está no controller)
- [ ] Adicionar Codeclimate ao Projeto
- [ ] Adicionar Testes + Codecov para verificar cobertura (coverage)
- [ ] Adicionar Badges (Passou no CI, )
- [ ] Editar Visão de Qualidade
- [ ] Editar Lote
- [ ] Editar/Exclui Ensaios Adicionados ao Lote
- [ ] Adicionar RabbitMQ para consumir Eventos (EventConsumer em docker separado)
- [ ] Refatorar arquitetura do front-end para arquitetura hexagonal
- [ ] Corrigir todos os FIXMEs e TODOs presentes no código
- [ ] Adicionar mais validações para todos os forms (back e front)
- [ ] Adicionar tratamento de erro de API (front)
- [ ] Adicionar central de notificações

## Introdução

## Modelagem

## Arquitetura

## Bibliotecas Utilizadas

## Cheatsheet

### Rodar Front-end Localmente

`cd materials-evaluation-spa`

`ng serve`

### C# Scaffolds

`dotnet aspnet-codegenerator controller -name MaterialsController -async -api -m Material -dc DatabaseContext -outDir API/Controllers`

### Migrations

`dotnet ef migrations add NomeDaMigration`

`dotnet ef database update`

` dotnet ef migrations remove --force`
