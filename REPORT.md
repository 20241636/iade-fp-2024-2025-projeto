# Relatório de Projeto <!-- omit in toc -->

- Licenciatura em Engenheira Informática 2024/2025 [IADE](https://www.iade.europeia.pt/)   <!-- omit in toc -->
- Projeto 1º ano, 1º semestre
- Prática pedagógica: PBL
- Unidades curriculares: Fundamentos da Programação & Estruturação do Pensamento Lógico

## Índice <!-- omit in toc -->

- [Equipa](#equipa)
- [Distribuição de Tarefas](#distribuição-de-tarefas)
- [Arquitetura da Solução](#arquitetura-da-solução)
- [Observações](#observações)
  - [Funcionalidades implementadas](#funcionalidades-implementadas)
  - [Funcionalidades não implementadas](#funcionalidades-não-implementadas)
  - [Limitações](#limitações)

<!-- Alterar a partir daqui -->

## Equipa

Rafael da Rocha Lima | 20241636

Francisco Pascoal Matos da Silva | 20241293

Daniel Alexandre Mbeya Paulo | 20240992

Carlos Alexandre Avelino Lima | 20240470


## Distribuição de Tarefas

•	Daniel Paulo e Francisco da Silva: Construção do Fluxograma;

•	Rafael Lima, Carlos Lima, Daniel Paulo, Francisco Silva: Construção do Código;

•	Carlos Lima e Rafael Lima: Relatório.


## Arquitetura da Solução

A solução construída é composta por uma classe "Program" onde se corre o "main". Neste main é criada uma instância da classe Xadrez (explicada mais à frente) e é executado o método "executaJogo()", que vai processar todos os comandos introduzidos pelo utilizador.
Em termos de estrutura de classes, existe a classe Xadrez, que contém as variáveis "lista de jogadores" e "jogo em curso". Cada jogador é mapeado numa classe "Jogador", e o jogo em curso é mapeado numa classe Jogo, que é a classe mais importante e complexa do programa.
A classe Jogador apresenta o nome do jogador e o seu palmarés (número de jogos, vitórias, empates e derrotas).
Relativamente à classe Jogo, esta representa um jogo entre 2 jogadores (jogador A e jogador B), um tabuleiro de xadrez (matriz 8x8 de entradas do tipo "Peca"), turno do jogador que deve jogar de seguida, posição dos reis e se os mesmos estão em check (para validar ações de validação de check e checkmate) e último movimento efetuado no jogo (para se analisar a operação de enpassant). 

Principais algoritmos efetuados:
  - Método ExecutaJogo - onde se lê as opções do utilizador e se dá ordem de execução, ou erro, mediante a boa estrutura das instruções. Este é o método principal que vai chamar todas as operações de registo de jogadores, listagem, movimento de peças, operações especiais, gravar ficheiro, ler ficheiro e sair do programa.
  - Método RegistarJogador - Verifica se jogador já existe, e em caso negativo regista novo jogador, acrescentando-o à lista de jogadores.
  - Método ListarJogador - Lista todos os jogadores existentes
  - Método IniciarJogo - Cria novo jogo, onde carrega os 2 jogadores definidos pelo utilizador e carrega o tabuleiro com os valores default ou um tabuleiro já existente
  - Método MovimentarPeca - Verifica se a jogada pode ser efetuada pelo jogador em questão, e se é possível movimentar a peça da posição inicial para a final. Se conseguir fazer a movimentação, faz ações de validação após movimento, tais como o checkmate, check, atualização do próximo jogador a jogar e apresentação de mensagens.
  - Método operacaoEspecial - Executa as operações especiais listada no enunciado do projeto. De notar que após a execução das movimentações especiais, decidimos verificar se o rei está em check ou em checkmate. Esta validação pode originar a apresentação de duas mensagens no ecrã. Apesar de não ter sido solicitado no enunciado, consideramos que seria importante fazer estas verificações, dado que as operações especiais podem levar a uma ação de check ou chekmate.
  - Método DesistirJogo - Desiste do jogo e atribui vitória ao adversário
  - Outros métodos importantes: validaMovimento e caminhoLivre: verifica se o movimento é válido e se o caminho entre o ponto A e B está livre (para evitar passar por cima de peças quando não é permitido) 
  - Método validaCheckMate - Método mais complexo do projeto. Iteramos sobre toda a matriz para simular a movimentação de todas as peças para outra posição, e fazemos uma segunda iteração sobre a matriz para determinar todos os possíveis movimentos. Se em algum caso o rei não estiver em check, então não é checkmate. Se no fim de todas as iterações, se não se encontrou nenhum movimento em que o rei não está em check, então é checkmate.
  - Método validaCheck - Verifica se existem movimentos válidos que possam chegar à posição de cada rei (branco ou preto), caso exista o rei está em check. Este método é utilizado no método validaCheckMate.

## Observações

- A solução encontra requer muitas iterações sobre a matriz. Para facilitar as iterações definimos 2 variáveis que representam as posições dos reis, para se evitar estar sempre à procura dos reis na matriz quando se quer verificar o check. A centralização destas posições faz com que seja necessário estar sempre a atualizar estas variáveis quando os reis mudam de posição.
- Assumiu que as peças pretas começam a norte do tabuleiro (parte superior) e que as peças brancas estão na parte inferior. O Jogador A joga com as peças pretas e o jogador B com as brancas. Como é pretendido que as peças brancas arranquem o jogo, é sempre o jogador B que começa o jogo.

### Funcionalidades implementadas

 - Registar jogador (RJ)
 - Listar jogadores (LJ)
 - Iniciar jogo (IJ)
 - Mover Peça (MP)
    - Tudo exceto movimento especial roque
 - Operação especial (OS)
    - Recuo peão
    - Operação Cavalo
    - Operação mudança rainha pelo rei

 - Detalhes de jogo (DJ)
 - Desistir de jogo (D)
 - Gravar (G)
 - Ler (L)

### Funcionalidades não implementadas

- Movimento especial roque
- Operação especial (OS)
    - Torre
    - Bispo
- Lista dos jogos já finalizados (não foram gravados em ficheiro)

### Limitações
Validações mais detalhadas de certas operações não foram realizadas. Assumiu-se as limitações ou as regras listadas no enunciado.