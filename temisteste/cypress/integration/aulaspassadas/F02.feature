Feature: Buscando Jogador

    COMO Técnico de um Time de Futebol
    DESEJO realizar uma busca pelos jogadores do time
    PARA que possa acessar as informações de um jogador específico

    #Regra: é preciso estar logado para poder buscar por um jogador
    Background: Usuário Logado
        Given que o usuário "titi_br" esteja logado
        And que o sistema esteja na seção de busca

    #Regra: é possivel buscar por um jogador cadastrado
    Scenario Outline: Buscando Jogador
        When buscar por "<Jogador>"
        And que "<Jogador>" exista no sistema
        And ao selecionar jogador
        Then os dados de "<Jogador>" são exibidos
        Examples:
            | Jogador |
            | Messi   |
            | Mbappé  |

    #Regra: o sistema deve acusar caso um jogador não exista no sistema
    Scenario: Buscando por um Jogador que não existe
        When buscar por "MeninoNey"
        And o jogador não exista no sistema
        Then a mensagem "Jogador não encontrado" é exibida