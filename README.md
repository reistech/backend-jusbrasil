# Jusbrasil - Desafio Backend Engineer | Data

- [Planejamento Desafio](#estrutura-do-projeto)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Requisitos](#requisitos)
- [Configurações](#configurações)
    - [Git](#git)
    - [Instalação via Docker](#instalação-via-docker)
- [Sobre](#sobre)


## Planejamento do Desafio

Para esse desafio foi utilizado metodólogia Scrum com sprint com duração de 5 dias, planejado a finalização em até 3 sprint's.

![planejamento](https://ibb.co/W0JrT4S)




## Estrutura do Projeto

O projeto tem uma estrutura composta pelo *backend* em [.NET Core](https://dotnet.microsoft.com/). 

Estrutura dos diretórios:    

* **.docker**: Contém os arquivos de configuração do Docker (Dockerfile) para construção dos containers usados no projeto;
* **backend**: Diretório com uma solução .NET contendo dois projetos: API para disponilização da infra-estrutura do backend; e Test com os testes unitários do projeto API;
* **scripts**: Contém arquivos de configuração para execução do projeto usando Docker;     


### Git

Gitflow Workflow é um design de fluxo de trabalho Git que foi publicado e popularizado pela primeira vez por Vincent Driessen no nvie. O Gitflow Workflow define um modelo de ramificação rigoroso projetado com base no lançamento do projeto. Isto oferece uma estrutura robusta para gerenciar projetos maiores.  

Configurar a integração contínua usando o GitHub Actions


## Requisitos

Para desenvolvimento e utilização do projeto são necessárias as seguintes dependências (algumas não são necessárias com a utilização do Docker, ver abaixo): 

- [.Net Core](https://dotnet.microsoft.com/): Utilitário do SDK .Net Core, com ferramentas necessárias para execução, build do *backend*
- [Docker](https://docs.docker.com/): Permite a utilização de *containers* para execução do projeto
- [Docker Compose](https://docs.docker.com/compose/): Utilitário do Docker para orquestrar o comportamento de execução dos *containers*

## Configurações

Essa seção detalha as configurações necessárias para criar um ambiente de desenvolvimento local.

### Instalação via Docker

Inicialmente, configure o arquivo .env usado no ambiente local, copiando o arquivo .env-example e renomeando-o para .env. Esse arquivo contém as variáveis de configuração utilizadas nos scripts do Docker. Altere conforme o seu ambiente local de desenvolvimento.

Para criar a rede Docker e inicializar o **container** execute o seguinte comando:

```sh
$ bash ./scripts/configure.sh
$ bash ./scripts/create-network.sh
$ bash ./scripts/start-container.sh
```

Para inicializar o servidor dotnet dentro do container utilize o comando abaixo:

```sh
$ bash ./scripts/start-server.sh
```

Para destruir o container e destruir a rede docker execute:

```sh
$ bash ./scripts/stop-container.sh
$ bash ./scripts/destroy-network.sh
```

### Configuração ambiente .NET

A execução do projeto .Net Core depende de arquivos com perfis de configuração, de acordo com o ambiente para reprodução do projeto (*appsettings.json*). Por padrão, o .Net Core utiliza sempre o perfil *Development*.

O perfil de execução do projeto é controlado pela variável de ambiente ASPNETCORE_ENVIRONMENT. Se essa variável não estiver presente na máquina do usuário, assume-se o perfil padrão (*Development*). Para utilizar o perfil *Local*, configure a variável de ambiente ASPNETCORE_ENVIRONMENT como Local. No Windows utilize as opções avançadas de sistema e cria a variável ou utilize o seguinte comando no Git Bash: 

```$ setx ASPNETCORE_ENVIRONMENT Local```

No Linux, utilize o seguinte comando: 

```$ export ASPNETCORE_ENVIRONMENT=Local```

*Obs*: Para que a variável seja reconhecida pela Bash/CMD, é necessária encerrar o terminal atual e iniciar outra sessão.


### Instalação Manual

Essa seção detalha como o projeto pode ser configurado manualmente, sem uso do Docker. Para instalação manual é necessário que as dependências básicas listadas na seção [Requisitos](#requisitos) estejam instaladas. 

#### Backend (API)

Se estiver usando a IDE do Visual Studio no Windows, simplesmente importe o projeto através do arquivo de solução (*backend.sln*) e crie uma configuração para executar a aplicação. 

No Linux é necessário utilizar o CLI do .Net Core. Após a instalação execute o comando: 

```$ dotnet run``` 

Esse comando irá instalar as dependências e colocar o projeto em execução, de acordo com o perfil de execução indicado. A API estará em execução no endereço [http://localhost:5000/api/Home](http://localhost:5000/api/Home)

## Sobre

Olá! Esse desafio técnico tem como propósito medir suas habilidades, ver como estuda, pensa e se organiza na prática. A stack tecnológica utilizada é de sua escolha e o tempo de término é livre.

Após finalizar o desafio, nos envie um link para repositório do projeto ou um zip com o código.

Existem diversas maneiras e profundidades de solucionar o problema que estamos propondo. Vamos listar algumas sub-tasks que podem guiá-lo(a) em relação a essas possibilidades.

## O desafio

A Jusbrasil coleta uma variedade de dados públicos que não são facilmente acessíveis e melhora seu acesso para todos. Um dos tipos de dados coletados são os dados sobre processos.

O desafio é fazer uma API que busque dados um processo em todos os graus dos Tribunais de Justiça de Alagoas (TJAL) e do Mato Grosso do Sul (TJMS). Geralmente o processo começa no primeiro grau e pode subir para o segundo. Você deve buscar o processo em todos os graus e retornar suas informações.

Será necessário desenvolver `crawlers` para coletar esses dados no tribunal e uma API para fazer input e buscar o resultado depois.

## Input

Você deve criar uma api para receber um json contendo o numero do processo. Para descobrir o tribunal você pode pedir no input ou usar o [padrão cnj de numeração de processos juridicos](https://www.cnj.jus.br/programas-e-acoes/numeracao-unica/).

## Output

O cliente tem que ser capaz de pegar o dado quando o processamento termina, então você deve criar um mecanismo que permita isso, retornando sempre um JSON para os processos encontrados em todas as esferas.

## Crawlers / Tribunais onde os dados serão coletados

Tanto o TJAL como o TJMS tem uma interface web para a consulta de processos. O endereço para essas consultas são:

* TJAL
  - 1º grau - https://www2.tjal.jus.br/cpopg/open.do
  - 2º grau - https://www2.tjal.jus.br/cposg5/open.do
* TJMS
  - 1º grau - https://esaj.tjms.jus.br/cpopg5/open.do
  - 2º grau - https://esaj.tjms.jus.br/cposg5/open.do

### Dados a serem coletados:

* classe
* área
* assunto
* data de distribuição
* juiz
* valor da ação
* partes do processo
* lista das movimentações (data e movimento)

### Exemplos de processos
* 0710802-55.2018.8.02.0001 - TJAL
  - para mais numeros de processo, busque no diario oficial de alagoas: https://www.jusbrasil.com.br/diarios/DJAL/
* 0821901-51.2018.8.12.0001  - TJMS
  - para mais numeros de processo, busque no diario oficial de mato grosso do sul: https://www.jusbrasil.com.br/diarios/DJMS/

## Alguns pontos que serão analisados:

* Organização do código 
* Testes
* Facilidade ao rodar o projeto
* Escalabilidade: o quao facil é escalar os crawlers.
* Performance: aqui avaliaremos o tempo para crawlear todo o processo juridico.


**Happy coding! :-)**