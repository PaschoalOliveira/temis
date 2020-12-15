#language: pt
Funcionalidade: Autorizar ou reprovar lançamento de efluentes
   COMO Líder de Processos da industria de tratamento de efluente
   DESEJO autorizar ou reprovar as requisições de lançamento de efluente
   PARA atender as diretrizes da empresa

   Contexto: 
   Dado que o usuário foi autenticado 
   Quando clico em Requisições
	
   #Regra: Consultar as requisições de tratamento
   @consultarRequisicao
   Cenário: Consultar as requisições feitas
   Então verifico a lista de requisições realizadas  
   #Regra: É possível aprovar as requisições de tratamento
   @aprovarRequisicao
   Esquema do Cenário: Aprovar lançamento de efluente
      E seleciono Aprovar
      Então a solicitação é "<resultado>"    
      Exemplos:
        | nome do efluente | volume (em L) | local de lançamento  | resultado | 
        | efluente X       | 250           | Rua do Não Faça Isso | aprovada  |
   #Regra: É possível reprovar as requisições de tratamento
   @reprovarRequisicao
   Esquema do Cenário: Reprovar lançamento de efluente
      E seleciono Reprovar
      Então a solicitação é "<resultado>"    
      Exemplos:
        | nome do efluente | volume (em L) | local de lançamento | resultado  | 
        | efluente 22      | 100           | Rua do Aqui Pode    | reprovada  |	
   #Regra: O cliente é notificado quando a requisição é aprovada 
   @notificacaoRequisicao
   Cenário: Cliente notificado quando a requisição é aprovada
      E aprovo uma requisição
      Então o cliente é notificado

   
