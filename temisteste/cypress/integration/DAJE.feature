
Feature: Solicitar DAJE de Registro Civil

    COMO usuário
    DESEJO solicitar a emissão de um DAJE de Registro Civil
    PARA que possa avançar nos tramites do casamento


Background: 
    Given o acesso ao sistema DAJE do TJ
    And que os dados estejam preenchidos
        | atribuição     | tipo_de_ato              | comarca    | cartório                             |
        | REGISTRO CIVIL | VIII - CERTIDAO EM GERAL | ALAGOINHAS | REGISTRO CIVIL 1 OFICIO - ALAGOINHAS | 
#RN01: É possível emitir DAJE

Scenario Outline: Emitindo DAJE
    And preencher dados do contribuinte
    When tento emitir DAJE
    Then a DAJE é emitida
    Examples: 
        | contribuinte    | endereço      | cidade     | documento      |
        | Maria das Dores | Rua Genário   | Salvador   | 253.502.910-33 |

#RN02: Checar validade do CPF
Scenario Outline: Checar validade do CPF
    And preencher dados do "<contribuinte>","<endereço>","<cidade>","<CPF>"
    When tentar emitir daje
    Then é exibida um mensagem de erro
    Examples:
        | contribuinte   | endereço    | cidade     | CPF            |
        | Pedro          | Av. Paralela| Alagoinhas | 000.000.000-00 |
#RN03: O CNPJ não deve estar vazio
Scenario Outline: Formulario com campos vazios
    And selecionar o tipo "<tipo>"
    When tentar emitir daje
    Then são exibidas mensagens de erro
    Examples: 
        | tipo |
        | CPF  |
        | CNPJ |

#RN04: A natureza do ato deve ser igual ao que foi selecionado
@focus
Scenario: Checar natureza do ato
    Then a natureza do ato é exibida corretamente 

