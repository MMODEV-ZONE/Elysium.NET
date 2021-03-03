.. _client_cmd:

Comandos de Cliente
==========================

Esta página visa ilustrar todos os comandos que o lado do cliente possui para uso dos desenvolvedores e dos jogadores.

Estrutura Administrativa
#########################################
A Elysium possui uma estrutura administrativa embutida a fim de dar diferentes poderes para quem contribui na construção do jogo, de alguma forma. Idealmente, tal estrutura deve seguir um formato de pirâmide, onde as pessoas com maior nível de acesso ficam no topo e em menor quantidade, enquanto os usuarios e as pessoas de menor acesso, na base maior.

A estrutura é separada em:

* Usuário (Nível de acesso: 0)
* Monitor (Nível de acesso: 1)
* Mapeador (Nível de acesso: 2)
* Desenvolvedor (Nível de acesso: 3)
* Administrador (Nível de acesso: 4)


Lista de Comandos
#################################

Usuário (0)
*******************
Os comandos são mostrados em lista:

* **/emote <INTEIRO>**: Manda o emote número <INTEIRO> para o mapa.
* **/ajuda**: Mostra uma mensagem com todos os comandos disponíveis.
* **/convidarmoradia <NOME-DO-JOGADOR>**: Convida <NOME-DO-JOGADOR> para a moradia do jogador que está executando o comando.  
* **/vendermoradia**: Vende a moradia do jogador que está executando o comando.
* **/info <NOME-DO-JOGADOR>**: Recebe informações do <NOME-DO-JOGADOR>.
* **/quem**: Recebe lista de quem está online. 
* **/fps**: Mostra o FPS atual do jogo. 
* **/lps**: Mostra o LPS atual do jogo. 
* **/atributos**: Mostra os atributos do jogador que está executando o comando. 
* **/equipe <NOME-DO-JOGADOR>**: Cria um convite de equipe com o jogador executor e o jogador <NOME-DO-JOGADOR>. 
* **/entrar**: Aceita o convite para criar a equipe. 
* **/sair**: Sai da equipe atual. 
* **/soltarpet**: Solta o pet em posse do jogador executor do comando. 



Monitor (1)
*******************
Além de todos os comandos do nível de usuário, os Monitores tem acesso aos seguintes comandos:

* **/admin**: Mostra a ajuda da administração.
* **/resetartarefa <INTEIRO>**: Reseta os atributos da tarefa de número <INTEIRO>.
* **/chutar**: Retira temporariamente o jogador. Este pode refazer o login e entrar novamente.


Mapeador (2)
*******************
Além de todos os comandos do nível de Monitor, os Mapeadores tem acesso aos seguintes comandos:

* **/loc**: Retorna a localização em coordenadas X,Y.
* **/melevarpara <NOME-DO-JOGADOR>**: Leva o jogador executor para a coordenada de <NOME-DO-JOGADOR>.
* **/metraga <NOME-DO-JOGADOR>**: Traz <NOME-DO-JOGADOR> para o jogador executor.
* **/irpara <INTEIRO>**: Transporta para o mapa de número <INTEIRO>.
* **/sprite <INTEIRO>**: Altera o número da sprite para o de <INTEIRO>.
* **/mapreport**: Retorna o MapReport.
* **/boasvindas <STRING>**: Seta a mensagem de boas-vindas para <STRING>.
* **/respawn**: Refaz a geração do mapa em que o Monitor está.
* **/banlist**: Retorna a lista de jogadores banidos.
* **/banir <NOME-DO-JOGADOR>**: Remove permanentemente o jogador.

No painel de administração, os mapeadores podem acessar os editores de mapas, moradia e o gerador procedural de mapas.

Desenvolvedor (3)
********************
Além de todas as funções englobadas pelo nível de mapeador, os desenvolvedores podem acessar os editores de animações, classes, habilidades, itens, lojas, NPCs, pets, projéteis, receitas, recursos e de tarefas.

Criador (4)
********************
Além de todas as funções englobadas pelo nível de desenvolvedor, os criadores podem acessar a função de gerar item e usar o seguinte comando:

* **/acesso <NOME-DO-JOGADOR> <INTEIRO>**: Seta o acesso para o valor <INTEIRO>, variando de 0 a 4, ao <NOME-DO-JOGADOR>.
