Feature: Carregando Lista de Jogadores

    COMO Dirigente de um Time de Futebol
    DESEJO submeter a relação de todos os jogadores do meu Time
    PARA poder utilzar todas as funconalidades do sistema

    #Regra: é preciso estar logado para poder carregar lista de jogadores
    Background: Usuário Logado
        Given que o usuário "titi_br" esteja logado
        And que o sistema esteja na seção de envio de planilha

    #Regra: é possivel enviar uma planilha com os dados dos jogadores
    Scenario: Submetendo Planilha
        Given que não haja jogadores no sistema
        When submeter planilha em "XML"
        Then a planilha foi carregada

    #Regra: só é possível enviar uma planilha em formato XML
    Scenario: Submetendo Planilha em Outro Formato
        Given que não haja jogadores no sistema
        When submeter planilha em "XLS"
        Then a mensagem "Formato não suportado" é exibida

    #Regra: o envio da planilha precisa ser confirmado
    Scenario: Confirmando envio
        Given que haja um arquivo para ser enviado
        When confirmar o envio
        And validar a operação
        Then os dados do time foram alterados