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
<p>* Separa as patas de Application, Infra, Controllers... em projetos diferentes
para evitar maior acoplamento e facilitando os teste
</p>
<p>
    * adicionar adicionar um redis ou qualquer outro sistema de cache nas consultar de task, pois como abordagem 
escolhida puxa todas as formas que a task teve ao longo de sua vida pode ficar um pouco pesado na primeiro carregamento
</p>
<p>
 * adicionar em objetos k8s de deployment para gerenciar a subida como quantidade de cpu, memoria, e a quantidade de replicas
Services para gerencias as chamada as pods
e secrets para guarda dados sensiveis como por exemplo TokenSecret, ConnectionString do banco de dados dentre outros
</p>


