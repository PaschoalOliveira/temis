#language: pt
#language: xx

#1 - Mal exemplo Elementos tela
Funcionalidade: Como usuário desejo acessar o sistema

Cenário: Usuário informa apenas usuario no sistema

Dado que eu preencho o campo login
Quando clico no Botão entrar
Então vejo um alert com o texto "Senha não informada"

#1 - Como seria
Given usuário informa o login
When faço o login
Then vejo a mensagem "Senha não informada"


#2 - Mal exemplo condições repetidas

Feature: Controle de estoque

Scenario: Decrementa 2 itens do estoque

Given que há 3 itens no estoque  
And usuário é adminsitrador do sistema
When o usuário retira 2 item do estoque
Then  restará no estoque 1 item

Scenario: Decrementa 3 itens do estoque
Given que há 5 item no estoque  
E usuário é adminsitrador do sistema
When  o usuário retira 3 item do estoque
Then restará no estoque 2 item 

#2 - Como seria
Scenario: Decrementa itens do estoque

Background: Dado que usuário é administrador do sistema

Given que há <Numero Estoque> itens no estoque
When  o usuário decrementa <itens retirados>
Then restará <resultado estoque>

Examples:
    | Numero Estoque | itens retirados | resultado estoque |
    | 3  | 2  | 1  |
    | 5  | 4  | 1  |



