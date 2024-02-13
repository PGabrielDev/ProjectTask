<h1>como rodar o projeto</h1>

<h2>Caso esteja em ambiente linux</h2>
<ol>
    <li>na raiz do projeto existe um arquivo chamado run.sh</li>
    <li>caso o arquivo não esteja executavel user o comando no terminal chmod +x run.sh</li>
    <li>agora o arquivo já pode ser executado rode ele dando 2 cliques ou pelo terminal usando o cmando ./run.sh</li>
    <li>Ao rodar esse arquivo ele irar build a imagem docker e logo apos ira rodar o docker-compose com o imagem do 
    app junto com a imagem do postgres para acesso a dados</li>
</ol>
<h2>Caso esteja em ambiente  Windows</h2>
<ol>
    <li>na raiz do projeto existe um arquivo chamado run.bat</li>
    <li>Basta dar 2 cliques no arquivo ou rodar pelo cmd com o comando ./run.bat</li>
    <li>Ao rodar esse arquivo ele irar build a imagem docker e logo apos ira rodar o docker-compose com o imagem do 
    app junto com a imagem do postgres para acesso a dados</li>
</ol>
<H3>1 VEZ RODANDO</H3>
<p>Ao rodar a primeira vez um usuario com roles de ADMIN para poder tirar usar o endpoin de relatorio sera criado</p>
<p>login: eclipse@teste.com</p>
<p>Senha: 123321</p>
<p>Na raiz do projeto tem o projeto DESAFIO ECLIPSE.postman_collection.json para import as collections no postman e testar o projeto</p>
<h3> endpoints</h3>
<ul>
    <li>Todas as alterações que necessitam de rastreio de modificação são autenticadas</li>
    entre eles são: 
    <ol>
        <li>
    host/api/v1/Project (POST) para criação de um novo projeto
        </li>
        <li>
    host/api/v1/Project/generateReport (GET) gera um relatorio da media de tarefaz feitas pro usuario em 30 dias (APENAS ADMIN PODEM ACESSAR ESSA ROTA)
        </li>
        <li>
    host/api/v1/Project (DELETE) gera um relatorio da media de tarefaz feitas pro usuario em 30 dias (APENAS ADMIN PODEM ACESSAR ESSA ROTA)
        </li>
        <li>
    host/api/v1/Project/{projectId}/task (POST) CRIA UMA NOVA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId}/addComment (POST) ADICIONA UM COMENTARIO A UMA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId}/changeStatus (POST) ALTERA O STATUS DA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId}/changeDescription (POST) ALTERA A DESCRIÇÃO DA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId}/addAssined (POST) ALTERA O RESPONSAVEL PELA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId}/changeName (POST) MUDA O NOME DE UMA TAREFA
        </li>
        <li>
    host/api/v1/Project/task/{taskId} (DELETE) DELETA UMA TAREFA
        </li>
 </ol>

<li>Os que não precisam de altenticação</li>
<ol>
    <li>host/api/v1/Project/task/{projectId} (GET) PEGA DETALHES DE UM TASK INCLUINDO SEU HISTORICO SIMPLES</li>
    <li>host/api/v1/Project/task/{projectId}/historicComplete (GET) PEGA DETALHES DE UM TASK INCLUINDO SEU HISTORICO COMPLETO</li>
    <li>host/api/v1/Project (GET) PEGA TODOS OS PROJETOS E SUaS TASK SEM HISTORICO</li>
    <li>host/api/v1/Project/{userId} (GET) PEGA TODOS OS PROJETOS DE UM USUARIO E SUaS TASK SEM HISTORICO</li>
    <li>host/api/v1/User/ (POST) CADASTRA UM NOVO USUARIO COM FUNÇÃO DE USUARIO</li>
    <li>host/api/v1/User/login (POST) FAZ O LOGIN PARA O OBETER O TOKEN DE ACESSO</li>
</ol>



</ul>



<h2>Futuros refinamentos</h2>
<p>* Seria interessante no futuro realizar   BI completo indo alem da media das tarefaz completas no ultimos 30 dias
    como verificar o tempo de conclusão de uma terefa com isso podemos também ter o tempo medio de resolução de um task por usuario
</p>
<p>* Neste mesmo sentido podemos tira essa media das tarefas baixa, media e alta prioride para ver quais delas tem a maior tempo de completudo</p>
<p>* Adicionar atribuição de um colaborador nas tarefaz para as tarefaz que não foram realizadas por um unico usuario ]
assim podendo metrificar também a velocidade de completudo de uma tarefa feito em pair programimg assim atribuindo melhor as tarefaz entre os colaboradores</p>
<p>* Adicionar notificações para notificar todos os envolvidos na task que houve uma alteração</p>
<p>* Adicionar Marcações de usuarios </p>


<h2>O QUE EU MELHORIA</h2>
<p>* Criar a classe de dominio onde ficaria a regra de negocio pura para testar a aplicação independente de framework</p>
<p>* Separa as pastas de Application, Infra, Controllers... em projetos diferentes
para evitar acoplamento e facilitando os teste podendo testar cada parte isoladamente
</p>
<p>
    * adicionar adicionar um redis ou qualquer outro sistema de cache nas consultar de task, pois como abordagem 
escolhida puxa todas as formas que a task teve ao longo de sua vida pode ficar um pouco pesado na primeiro carregamento
</p>
<p>
 * adicionar em objetos k8s como: deployment para gerenciar a implantação da api como quantidade de cpu, memoria, e a quantidade de replicas,
Services para gerencias as chamada as pods,
e secrets para guarda dados sensiveis como por exemplo TokenSecret, ConnectionString do banco de dados dentre outros
</p>


<h2>
sobre a implementação
</h2>

Resumo sobre a solução

O projeto foi Batizado de ProjectTask. No ProjectTask, temos a entidade "projeto", que possui uma relação de 1 para N com as "tarefas". Ou seja, um projeto pode ter várias tarefas, e as tarefas têm uma relação de 1 para N com as "Definições de tarefa".

O que são as "Definições de tarefa"? Elas representam o espelho de uma tarefa. Tudo que é mutável em uma tarefa, como nome, descrição, alteração do status, está contido nas definições de tarefas. Sempre que uma tarefa é alterada, uma nova definição de tarefa é criada com base na anterior, modificando apenas o necessário. Dessa forma, mantemos a definição anterior e a nova definição que sera visível na hora de listar as tarefas, preservando um histórico completo.

O aplicativo foi desenvolvido utilizando casos de uso e uma camada de serviços para orquestrar a chamada aos casos de uso.

As tarefas possuem 3 prioridades: 0 (baixa), 1 (média), 3 (alta). Essas informações são associadas às tarefas, não às definições, portanto, não podem ser modificadas.
As tarefas também têm 3 status: 0 (backlog ou a fazer), 1 (em andamento/in progress), 2 (concluído/done).
É possível adicionar comentários às tarefas, sendo que cada comentário cria uma nova definição de tarefa.

Cada projeto pode ter no máximo 20 tarefas. Não é permitido exceder esse limite.
A exclusão de um projeto só é possível se todas as tarefas relacionadas a ele estiverem com o status = 2 (DONE).

É possível gerar um relatório da média de tarefas finalizadas, mas apenas ADMINS PODEM ACESSAR ESSA ROTA. Quando o aplicativo é iniciado pela primeira vez, ele cria o usuário Admin com login: eclipse@teste.com e senha: 123321.

É possível listar todas as todos os projetos e todos os projetos de um usuario

É possível verificar a tarefa é sua detalhes(definições de tarefaz) existem um endpoint para listar apenas a ultima defnição disponivel com um historico e um para listar a
com a historico mais todas as definções de tarefaz disponiveis

Todos os endpoints que modificam algo são autenticados para rastrear quem fez a modificação. Pode usar o usuário criado pelo próprio aplicativo com a função de Admin ou criar outro pelo endpoint de cadastro. Os endpoints autenticados são os seguintes:






