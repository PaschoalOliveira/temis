
Feature: Solicitar DAJE de Registro Civil

    COMO usuário
    DESEJO solicitar a emissão de um DAJE de Registro Civil
    PARA que possa avançar nos tramites do casamento

Background: 
    Given o acesso ao sistema do TJ
    And ao selecionar DAJE
    And que "<atribuicao>", "<ato>", "<comarca>" e "<cartorio>" estejam preenchidos
        | atribuição     | tipo de ato       | comarca    | cartório |
        | REGISTRO CIVIL | CERTIDAO EM GERAL | ALAGOINHAS | 1 OFICIO | 

#RN01: É possível emitir DAJE
Scenario: Emitindo DAJE
    Given preencher dados do "<contribuinte>","<endereço>","<cidade>","<tipo de documento>", "<documento>"
        | contribuinte    | endereço      | cidade     | tipo de documento  | documento      |
        | Maria das Dores | Rua Genário   | Salvador   | CPF                | 253.502.910-33 |
    When tento emitir DAJE
    Then a DAJE é emitida

#RN02: É necessário preencher os dados obrigatórios
Scenario: Tentando emitir um DAJE sem os dados do solicitante
    When tento emitir um DAJE
    And os dados obrigatórios não foram preenchidos
    Then uma mensagem é exibida  

#RN03: Checar validade do CPF
Scenario Outline: Checar validade do CPF
    When preencher dados do "<contribuinte>"
        | contribuinte   | endereço    | cidade     | tipo de documento  | CPF            | validacao |
        | Pedro          | Av. Paralela| Alagoinhas | CPF                | 000.000.000-00 | invalido  |
        | José           | Av. Imbui   | Salvador   | CPF                | 750.752.240-75 | valido    |  
    And tentar emitir daje
    Then é exibida mensagem de "<validacao>"

#RN04: Checar validade do CNPJ
Scenario Outline: Checar validade do CNPJ
    When preencher dados do "<contribuinte>"
        | contribuinte | endereço    | cidade     | tipo de documento | CPF                | validacao |
        | Pedro        | Av. Paralela| Alagoinhas | CNPJ              | 00.000.000/0000-00 | invalido  |
        | José         | Av. Imbui   | Salvador   | CNPJ              | 01.010.511/0001-57 | valido    |  
        | Maria        | Rua C       | Alagoinhas | CNPJ              |                    | ERRO 500  |
    And tentar emitir daje
    Then é exibida mensagem de "<validacao>"

#RN05: A natureza do ato deve ser igual ao que foi selecionado
Scenario: Checar natureza do ato
    Then a natureza do ato é exibida corretamente 

#RN06: O valor deve corresponder ao que foi selecionado
Scenario: Checar valor do ato
    Then o valor do ato é exibido corretamente

#RN07: É possível emitir DAJE complementar
Scenario Outline: Emitir DAJE complementar
And seleciono DAJE complementar
And preeencho "<Código do Emissor>", "<Série>", "<Nº DAJE>"
And pesquiso
Then seleciono o tipo de ato
And verifico se o valor do ato selecionado é superior ao valor do DAJE principal
And concluo a operação
And verifico pela mensagem de sucesso "<Mensagem de sucesso>"
Then procuro por registro civil na lista de decretos
Examples:
   | Código do Emissor | Série | Nº DAJE | Mensagem de sucesso        |
   | 12345884689942751 | 15487 | 5484699 | Registro Salvo com sucesso |

#RN08: É necessário aparecer lista de decretos