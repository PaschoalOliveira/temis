#language:pt
Funcionalidade: aprovar ou reprovar etapas por um software
Para aprovar ou reprovar itens
Como por um softaware
Eu quero ter controle sobre as requisições e etapas da empresa

#RN01: autorizar ou reprovar itens
Esquema do Cenário: autorizar ou reprovar itens solicitados 

Background: Dado que o usuário é Líder de Processos

    Dado que há "item" para aprovar ou reprovar
    Quando o usuário escolhe a "opção"
    Então aparece o "resultado"
    
Exemplos:
| item               | opção             | resultado          |
| Empresa x          | Aprovar           | É Aprovado         |
| Empresa B          | Reprovar          | É Reprovado        |
