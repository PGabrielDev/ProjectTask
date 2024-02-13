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


<h2>Futuros refinamentos</h2>
<p>* Seria interessante no futuro realizar   BI completo indo alem da media das tarefaz completas no ultimos 30 dias
    como verificar o tempo de conclusão de uma terefa com isso podemos também ter o tempo medio de resolução de um task por usuario
</p>
<p>* Neste mesmo sentido podemos tira essa media das tarefas baixa, media e alta prioride para ver quais delas tem a maior tempo de completudo</p>
<p>* Adicionar atribuição de um colaborador nas tarefaz para as tarefaz que não foram realizadas por um unico usuario ]
assim podendo metrificar também a velocidade de completudo de uma tarefa feito em pair programimg assim atribuindo melhor as tarefaz entre os colaboradores</p>
<p>* Adicionar notificações para notificar todos os envolvidos na task que houve uma alteração</p>
<p>* Adicionar Marcações de usuarios </p>


<h2>OQUE EU MELHORIA</h2>
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


