<h1>Projeto: GoodSong</h1>

<h2>Descrição</h2>
<p>GoodSong é um aplicativo que gerencia bandas, álbuns e músicas. Ele permite registrar bandas, adicionar álbuns e músicas às bandas e filtrar músicas por gênero. O projeto inclui funcionalidades para carregar músicas a partir de uma API JSON externa.</p>

<h2>Habilidades Demonstradas</h2>
<ul>
        <li><strong>Uso de APIs:</strong> Consumo de API externa para obter dados JSON.</li>
        <li><strong>Serialização/Deserialização:</strong> Utilização de <code>System.Text.Json</code> para deserializar dados JSON.</li>
        <li><strong>LINQ:</strong> Manipulação de coleções utilizando LINQ para filtrar e transformar dados.</li>
        <li><strong>Manipulação de Coleções:</strong> Uso de <code>Dictionary</code> para armazenar e gerenciar bandas.</li>
        <li><strong>Programação Assíncrona:</strong> Utilização de <code>async/await</code> para chamadas assíncronas de API.</li>
        <li><strong>Estruturação de Código:</strong> Organização do projeto em namespaces e classes bem definidas.</li>
    </ul>

<h2>Estrutura do Projeto</h2>
    
<h3>Namespaces</h3>
<ul>
        <li>GoodSong.Menus</li>
        <li>GoodSong.Models</li>
        <li>GoodSong.Filter</li>
</ul>

<h3>Dependências</h3>
<ul>
        <li>System.Net.Http</li>
        <li>System.Text.Json</li>
</ul>

<h2>Classes Principais</h2>
    
<h3>Banda</h3>
<p>Representa uma banda musical.</p>
<ul>
    <li><strong>Propriedades:</strong></li>
    <ul>
            <li>Nome: string</li>
        </ul>
        <li><strong>Métodos:</strong></li>
        <ul>
            <li>AdicionarAlbum(Album album): adiciona um álbum à banda.</li>
            <li>AdicionarMusica(Musica musica): adiciona uma música à banda.</li>
        </ul>
    </ul>

<h3>Album</h3>
<p>Representa um álbum musical.</p>
<ul>
    <li><strong>Propriedades:</strong></li>
    <ul>
        <li>Nome: string</li>
    </ul>
    <li><strong>Métodos:</strong></li>
    <ul>
        <li>Construtor que inicializa o nome do álbum.</li>
    </ul>
</ul>

<h3>Musica</h3>
<p>Representa uma música.</p>
<ul>
    <li><strong>Propriedades:</strong></li>
    <ul>
        <li>Titulo: string</li>
        <li>Artista: string</li>
        <li>Genero: string</li>
    </ul>
    <li><strong>Métodos:</strong></li>
    <ul>
        <li>Construtor que inicializa os detalhes da música.</li>
    </ul>
</ul>

<h3>MenuBoasVindas</h3>
<p>Classe que gerencia o menu de boas-vindas.</p>
<ul>
    <li><strong>Métodos:</strong></li>
    <ul>
        <li>Executar(): exibe o menu de boas-vindas.</li>
    </ul>
</ul>

<h3>MenuOpcoes</h3>
<p>Classe que gerencia o menu de opções.</p>
<ul>
    <li><strong>Métodos:</strong></li>
    <ul>
        <li>Executar(Dictionary&lt;string, Banda&gt; bandas): exibe o menu de opções e interage com as bandas registradas.</li>
    </ul>
</ul>

<h3>Filter</h3>
<p>Contém métodos para filtrar músicas por gênero.</p>
<ul>
    <li><strong>Métodos:</strong></li>
    <ul>
        <li>FiltrarGeneros(List&lt;Musica&gt; musicas): filtra os gêneros das músicas e exibe gêneros distintos.</li>
    </ul>
</ul>

<h2>Funcionalidade Principal</h2>
<h3>Registro de Bandas e Adição de Álbuns/Músicas</h3>
<p>Cria uma instância de uma banda e adiciona um álbum a ela. Utiliza um dicionário para registrar bandas.</p>

<h3>Carregamento de Músicas a partir de uma API JSON</h3>
<p>Utiliza <code>HttpClient</code> para obter uma lista de músicas de uma API JSON. Desserializa a resposta JSON em uma lista de objetos <code>Musica</code>.</p>

<h3>Início do Programa</h3>
<p>Adiciona as bandas e músicas carregadas do JSON ao dicionário <code>bandasRegistradas</code>. Executa o menu de boas-vindas e o menu de opções.</p>

<h2>Observações</h2>
<ul>
<li>Certifique-se de que as URLs da API estão corretas e acessíveis pois foram pegos da aula na Alura e podem estar inacessiveis pelo github.</li>
<li>Valide os dados recebidos da API antes de processá-los para evitar erros de execução.</li>
</ul>

