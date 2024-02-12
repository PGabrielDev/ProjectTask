#!/bin/bash

# Definir variáveis
DOCKER_IMAGE_NAME=eclipse/app-test
DOCKER_TAG=latest

# Construir a imagem Docker
docker build -t "$DOCKER_IMAGE_NAME:$DOCKER_TAG" -f ./ProjectsTasks/Dockerfile .

# Iniciar os contêineres usando docker-compose
docker-compose -f ProjectsTasks/docker-compose.yaml up -d




