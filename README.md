# Project Search Product

Este é um sistema de busca de produtos composto por um backend em .NET, um banco de dados e um frontend em Angular 18. O projeto está conteinerizado e pode ser iniciado facilmente com Docker Compose.

## Tecnologias Utilizadas

- **Backend:** .NET 7
- **Frontend:** Angular 18
- **Banco de Dados:** PostgreSQL
- **Containerização:** Docker e Docker Compose
- **Servidor Web:** Nginx

---

## Como Iniciar o Projeto com Docker Compose

Para rodar todo o projeto (backend, banco de dados e frontend), siga os passos abaixo.

1. **Certifique-se de ter o Docker e Docker Compose instalados.**
2. **Navegue até a raiz do projeto:**
   ```bash
   cd ~/project-search-product/
   ```
3. **Execute o Docker Compose:**
   ```bash
   docker-compose -f deploy/docker-compose.yml up --build
   ```
4. **Acesse o sistema:**
   - O frontend estará disponível em: `http://localhost:8080`
   - A API do backend poderá ser acessada em: `http://localhost:5000`

Para parar os containers, utilize:

```bash
docker-compose -f deploy/docker-compose.yml down
```

---

## Como Utilizar o Frontend

### Acessando a Interface

Após iniciar o projeto, abra um navegador e acesse `http://localhost:8080`.

### Funcionalidades Principais

- **Busca de Produtos:** Utilize a barra de pesquisa para encontrar produtos.
- **Filtragem:** Aplique filtros para refinar os resultados.
- **Detalhes do Produto:** Clique em um produto para visualizar mais informações.

Caso precise alterar a configuração do frontend, edite o arquivo `proxy.conf.json` para apontar a API correta.

---

## Estrutura do Projeto

```
project-search-product/
├── deploy/                    # Configurações de deploy e Docker
│   ├── docker-compose.yml      # Orquestração dos containers
│   ├── Dockerfile.backend      # Configuração do backend
│   ├── Dockerfile.database     # Configuração do banco de dados
│   ├── Dockerfile.frontend     # Configuração do frontend
│   └── nginx.conf              # Configuração do Nginx
├── src/
│   ├── backend/                # Código-fonte do backend
│   ├── database/               # Scripts SQL
│   └── frontend/               # Código-fonte do frontend
└── README.md                   # Este arquivo
```

Caso tenha dúvidas, entre em contato ou consulte a documentação de cada tecnologia utilizada. 🚀

