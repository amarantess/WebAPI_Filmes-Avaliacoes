<h2>Descrição</h2>
<p>Este projeto foi desenvolvido utilizando <strong>ASP.NET</strong>, <strong>Entity Framework</strong>, <strong>Swagger</strong>, <strong>SQL Server</strong> e com abordagem de <strong>Domain-Driven Design (DDD)</strong>. A API disponibiliza endpoints para gerenciar informações de <strong>Filmes</strong> e <strong>Avaliações</strong>, organizados em controllers específicos para cada entidade. Os controllers possuem as operações de CRUD, possibilitando a criação, leitura, atualização e exclusão de registros.</p>

<h2>Propósito</h2>
<p>Este projeto foi criado como um exercício de aprendizado para aplicar e aprimorar meus conhecimentos. Embora funcional, ainda existem diversas oportunidades para melhorias no código, especialmente na arquitetura. Essas melhorias serão implementadas futuramente, tanto neste projeto quanto em projetos similares.</p>

<h2>Operações CRUD</h2>
<p>Abaixo estão listadas as operações CRUD disponíveis na API, organizadas por tipo de método HTTP:</p>

<h3>GET</h3>
<ul>
  <li><strong>Listar Filmes</strong>: Retorna uma lista de todos os filmes.</li>
  <li><strong>Buscar Filme por Id</strong>: Retorna os detalhes de um filme específico pelo seu Id.</li>
  <li><strong>Avaliação Filme</strong>: Retorna todas as avaliações de um filme específico.</li>
</ul>

<h3>POST</h3>
<ul>
  <li><strong>Cadastrar Filme</strong>: Cadastra um novo filme no banco de dados.</li>
  <li><strong>Cadastrar Avaliação</strong>: Cadastra uma nova avaliação para um filme e retorna todas as avaliações.</li>
</ul>

<h3>PUT</h3>
<ul>
  <li><strong>Editar Avaliação</strong>: Atualiza as informações de uma avaliação existente no banco de dados.</li>
  <li><strong>Editar Filme</strong>: Atualiza as informações de um filme existente no banco de dados.</li>
</ul>

<h3>DELETE</h3>
<ul>
  <li><strong>Excluir Filme</strong>: Remove um filme do banco de dados pelo seu Id.</li>
  <li><strong>Excluir Avaliação</strong>: Remove uma avaliação do banco de dados pelo seu Id.</li>
</ul>

<h2>Imagens do Projeto</h2>
<p>Abaixo estão algumas capturas de tela para demonstrar a interface e funcionalidades do projeto:</p>

<p>
  <img src="https://github.com/user-attachments/assets/37ff05f6-d469-4308-a717-98a98c0f968a" alt="Imagem 1 - Interface Principal" width="1000">
  <br> <em>Imagem 1: Interface Principal</em>
</p>
<p>
  <img src="https://github.com/user-attachments/assets/20d3cc6b-87b8-41ca-a227-8f2828f938a4" alt="Imagem 2 - Exemplo de Endpoint" width="1000">
  <br> <em>Imagem 2: Exemplo de Endpoint</em>
</p>
<p>
  <img src="https://github.com/user-attachments/assets/3d7c33f1-3084-4773-854f-9823d93b3995" alt="Imagem 3 - Resultado de Busca" width="1000">
  <br> <em>Imagem 3: Resultado de Busca</em>
</p>

