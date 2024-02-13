@echo off

rem Definir variáveis
set DOCKER_IMAGE_NAME=eclipse/app-test
set DOCKER_TAG=latest

rem Construir a imagem Docker
echo Construindo a imagem Docker...
docker build -t "%DOCKER_IMAGE_NAME%:%DOCKER_TAG%" -f .\ProjectsTasks\Dockerfile .


rem Iniciar os contêineres usando docker-compose
echo Iniciando os contêineres com docker-compose...
docker-compose -f .\ProjectsTasks\docker-compose.yaml up -d


timeout /t 5

rem Script concluído com sucesso
echo Script concluído com sucesso.
exit /b 0