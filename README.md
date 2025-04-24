# Revenda

## Tecnologias utilizadas
•	.NET 9: Core framework;
•	.NET Aspire: Adicionando observabilidade(métricas, etc), containers e substituindo o docker file/compose;
•	Entity Framework Core: ORM e utilização de migrations (criado um serviço console para rodar as migrações automaticamentes);
•	MediatR: Na Implementando CQRS pattern;
•	AutoMapper: Para simplificar mapeamento de objetos;
•	FluentValidation: para validação de requests (CQRS commands);
•	Utilizado Polly para adicionar resiliciencia na comunição com a Api do Fornecedor;
•	xUnit: Test framework;
•	Mocking Frameworks: Mock para mock de dependencias;
•	FluentAssertions: Para criar os asserts mais fluídos.

## Patterns
•	CQRS Pattern;
•	Repository Pattern;
•	Mediator Pattern;
•	Utilizado estrutura de Use Cases para sincronização entre o código e negócio (linguagem ubiqua);

## Próximos passos
•	Adicionar todos os testes de unidade voltado a negócio;
•	Adicionar testes de integração
•	Utilizar o outbox pattern para comunição com a Api de fornecedor.

## Rodar localmente
•	É necessário ter o docker rodando localmente;
•	Execute .NET Aspire Host aplicação.

