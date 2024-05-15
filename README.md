# ProjectTemplates

## Introduction 
Solução criada para a padronização de templates backend das Lojas Rede

## Instalação

Executar o comando abaixo na raiz deste projeto para a instalação ou atualização dos templates

```bash
dotnet new install ./ --force
```

## Listar templates instalados

Executar o comando abaixo para listagem de todos os templates instalados

```bash
dotnet new list
```

## Listar templates que podem ser desinstalados

Executar o comando abaixo para listagem de todos os templates que podem ser desinstalados e gerar comando para desinstalação

```bash
dotnet new uninstall
```

## Criação de solução Api

Executar o comando abaixo no diretório que a soluction deve ser criada. Ex: C:\Users\nomedousuario\Desktop\projetos

```bash
dotnet new rede.api -n nomedasolution
```

## Desinstalação

Executar o comando abaixo na raiz deste projeto para a desinstalação dos templates

```bash
dotnet new uninstall ./