#language: pt

Funcionalidade: Consultar informações de jogador

    Eu, como presidente da CBF, desejo ver as informações dos jogadores, para facilitar outras atividades

    #Resumo: Entrar na lista de ligas, entrar na lista de times, ver lista dos jogadores,
    # ver detalhes de um jogador e voltar para a lista

    Cenário: Ver informação do jogador
        Dado que estou na lista de jogadores de um time
        E a relação de jogadores do time já está disponível
        Quando eu tento ver as informações de um jogador
            | liga       | time      | jogador   |
        Então eu consigo ver as informações do jogador