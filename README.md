# Jusbrasil - Desafio Backend Engineer | Data

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