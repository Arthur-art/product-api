🚀 Scalable Product API – .NET 8 + Redis Cache
💡 Sobre o projeto

O Scalable Product API é uma demonstração prática de como construir uma API verdadeiramente escalável com .NET 8, aplicando Clean Architecture, injeção de dependência e cache distribuído com Redis.

O foco principal é mostrar como otimizar performance e reduzir carga no banco de dados, armazenando respostas frequentemente acessadas na memória do Redis.

Essa abordagem é amplamente usada em sistemas de alta performance, como e-commerces, CRMs e ERPs, garantindo tempos de resposta baixos e excelente escalabilidade horizontal.

⚙️ Principais Tecnologias

.NET 8 (C#)

Redis (StackExchange.Redis)

Microsoft.Extensions.Caching.StackExchangeRedis

Clean Architecture

Dependency Injection (DI)

Swagger/OpenAPI

Docker (Redis container)

🧠 Por que usar cache em APIs escaláveis

Quando um usuário solicita um recurso (ex: /api/product/1), a API normalmente acessa o banco de dados para recuperar essas informações.
Essa operação, embora simples, é cara e lenta quando repetida milhares de vezes por segundo.

Com o Redis, a aplicação guarda em memória os resultados dessas consultas:

A primeira requisição faz a busca no banco e grava o resultado no cache.

As próximas requisições retornam diretamente do Redis, em milissegundos.

💥 Resultado:

Menos carga no banco.

Respostas até 100x mais rápidas.

Melhor escalabilidade horizontal (várias instâncias da API acessam o mesmo cache).

🧩 Arquitetura do Projeto
ProductApi/
│
├── Api/               → Controllers e endpoints HTTP
├── Application/       → Services e regras de negócio
├── Domain/            → Entidades e contratos
├── Infrastructure/    → Repositórios, cache e integrações
└── Program.cs         → Configuração e DI

🧪 Fluxo da Requisição com Cache
USER → API → Redis Cache → (miss?) → Repository → Banco de Dados
          ↑                     ↓
          └────── Cache Hit ────┘


📘 Explicação:

O usuário solicita o produto /api/product/1.

A API verifica se já existe no Redis (product:1).

Se existir → resposta instantânea (CACHE HIT).

Se não existir → consulta o banco, salva no Redis, e retorna (CACHE MISS).

🔁 Expiração e Invalidação

Os dados armazenados no Redis expiram automaticamente após 5 minutos (AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)).
Se o produto for atualizado, o cache é removido para evitar informações desatualizadas:

await _cache.RemoveAsync($"product:{id}");

🐳 Rodando o projeto com Docker
# Subir o Redis localmente
docker run -d --name redis -p 6379:6379 redis

# Executar a API
dotnet run --project ProductApi


Acesse:
👉 https://localhost:5001/swagger

📊 Performance esperada
Situação	Fonte de dados	Tempo médio	Observação
1ª requisição	Banco de dados	150–300 ms	CACHE MISS
2ª requisição	Redis Cache	1–3 ms	CACHE HIT
1000 requisições	Redis Cache	~1 ms cada	🟢 Altamente escalável
🧑‍💻 Autor

Arthur Teixeira Santos Silva
Desenvolvedor Backend | .NET • NestJS • TypeScript • Arquitetura de Software

Projeto desenvolvido como parte de uma mentoria prática focada em performance e escalabilidade backend.
