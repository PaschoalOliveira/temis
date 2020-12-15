
Feature: Solicitar DAJE de Registro Civil

    COMO usuário
    DESEJO solicitar a emissão de um DAJE de Registro Civil
    PARA que possa avançar nos tramites do casamento


#RN01: É possível emitir DAJE
Scenario: Emitindo DAJE
    #TODO - Isto não seria um setup?
    Given Desejo emitir um DAJE 
    And preencher dados do "<contribuinte>" 
        | contribuinte    | endereço      | cidade     | tipo de documento  | documento      |
        | Maria das Dores | Rua Genário   | Salvador   | CPF                | 253.502.910-33 |
    When tento emitir DAJE
    Then a DAJE é emitida
