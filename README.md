# Nu

Este projeto foi desenvolvido utilizando a arquitetura Clean Architecture.  
Apesar de ser uma aplicação pequena, essa escolha visa permitir escalabilidade futura.  
Caso não fosse necessário escalar, poderia ter sido implementado como um monolito simples.

## Características

- Arquitetura Clean Architecture  
- Nenhuma biblioteca externa utilizada  
- Containerizado com Docker para facilitar compilação, execução e testes

## Como executar

### Executar a aplicação no container Docker

A partir da pasta `devops` do projeto, execute a aplicação dentro do container Docker.

#### Opção 1: Usando PowerShell

```powershell
Get-Content "C:\caminho\para\seu\arquivo.txt" | docker exec -i capital-gains ./CapitalGain.CLI
```

> **Observação:** O nome do container e da imagem são pré-definidos como `capital-gains`.

#### Opção 2: Modo interativo

```bash
docker exec -i -t capital-gains ./CapitalGain.CLI
```

### Executar os testes

Para rodar os testes, execute:

```bash
docker run -it --rm -v ${PWD}:/app -w /app mcr.microsoft.com/dotnet/sdk:9.0 bash
```

Isso abrirá um terminal bash dentro do container.  
Dentro dele, execute:

```bash
dotnet test
```
