#language: pt
Funcionalidade: Solicitar lançamento de efluente 
   COMO Engenheiro Sanitarista da industria de tratamento de efluente
   DESEJO solicitar ou editar solicitação de lançamentos de efluentes
   PARA que não haja problema de contaminação no solo 

  Contexto: 
   Dado que o usuário foi autenticado 

   #Regra: É possível solicitar o lançamento de efluentes
   @lancarEfluente
   Esquema do Cenário: Solicitar lançamento de efluente
      Quando clico em Nova Solicitação de Lançamento
      E preencho os dados
      Então a solicitação é "<resposta>"    
      Exemplos:
        | nome do efluente | volume (em L) | local de lançamento    | resposta        | 
        | efluente X       | 250           | Rua do Não Faça Isso   | realizada       |
        | efluente Y       | 110           | Rua do Jogue no centro | não é realizada |
    #Regra: Apenas solicitações não autorizadas podem ser editadas 
    @editarSolicitacao
    Esquema do Cenário: Editar solicitação de lançamento de efluente
      Quando clico em Editar Solicitação
      E edito os dados
      Então a solicitação é "<resposta>"    
      Exemplos:
        | nome do efluente | volume (em L) | local de lançamento  | resposta | 
        | efluente X       | 195           | Rua do Não Faça Isso | editada  |

