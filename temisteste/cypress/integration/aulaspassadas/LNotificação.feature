#language:pt
Funcionalidade: notificar o usuario e CEO sobre as etapas
Para notificar
Como por um softaware
Eu quero ter controle sobre as etapas da empresa

#RN01: receber notificações sobre os itens adicionados
Esquema do Cenário: receber notificação 

Background: Dado que o usuário é CEO da Empresa

    Dado que há "item" cadastrado
    E que há um "elemento" adicionado 
    Quando o usuário escolhe o "item"
    Então é exibida a notificação "elemento adicionado"
    
Exemplos:
| item               | elemento          | resultado          |
| Empresa x          | descolorantes     | É Aprovado         |
| Empresa B          | coagulantes       | É Reprovado        |


#RN02: receber notificação do processo final
    Cenário: receber notificações 
    Dado acesso ao software e que exista um item cadastrado
    Quando receber notificação do processo final
    Então é exibida a notificação do processo final 
