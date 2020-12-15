Feature: Logando no Sistema

    COMO Técnico de um Time de Futebol
    PRECISO realizar login no sistema
    PARA poder ter acesso as funconalidades do sistema

    #Regra: no primeiro acesso não deve haver usuários logados
    Scenario: Primeiro Acesso
        Given o acesso ao sistema
        When o sistema for carregado
        Then não deve haver nenhum usuário logado
    #Regra: para logar é preciso fornecer credenciasi válidas
    Scenario Outline: Inserindo Credenciais
        Given o acesso à seção de Login
        When inserir "<Login>" e "<Senha>"
        And confirmar a submissão das credenciais
        Then o usuário "<Login>" está logado
        Examples:
            | Login     | Senha    |
            | titi_br   | hexa2022 |
            | rogerceni | gol10000 |
    #Regra: se as credenciais estiverem incorretas o login não é permitido
    Scenario Outline: Inserindo Credenciais Erradas
        Given o acesso à seção de Login
        When inserir "<Login>" e "<Senha>"
        And confirmar a submissão das credenciais
        Then o acesso do usuário "<Login>" não é permitido
        Examples:
            | Login     | Senha    |
            | titi_br   | gol10000 |
            | rogerceni | hexa2022 |