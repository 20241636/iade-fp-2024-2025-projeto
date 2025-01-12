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

Evidenciar principais algoritmos implementados e estruturas de dados utilizadas.

## Observações

Descrever eventuais problemas encontrados e soluções adotadas.

### Funcionalidades implementadas

Listar as funcionalidades implementadas no projeto.

### Funcionalidades não implementadas

Listar as funcionalidades que não foram implementadas no projeto.

### Limitações

Indicar implementações parciais, ou falhas identificadas no programa.
