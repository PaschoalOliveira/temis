#language:pt
Funcionalidade: adicionar endereço no cadastro das empresas
Para solicitar aprovação final
Como por um softaware
Eu quero solicitar a autorização da empresa para lançamento final do efluente

#RN01: cadastrar endereço
Esquema do Cenário: adicionar informações 

Background: Dado que o usuário é Engenheiro Autorizado

    Dado que há uma "item" cadastrado no sistema
    Quando adicionar informações de "endereço" 
    Então o sistema deve exibir a mensagem "Endereço cadastrado" 
    
Exemplos:
| item               | endereço              |
| Empresa x          | Av. Paralela, 572     | 
| Empresa B          | Imbuí 003             | 


