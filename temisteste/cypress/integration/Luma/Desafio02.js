describe('Desafio 02, Verificar quantas colunas e linhas há na tabela', () =>{
    
    it('Verificando Quantas colunas', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')
    var elementos = document.getElementsByTagName('td');
    document.writeln('Existem ' + elementos.length);

    it('Verificando último nome', () =>{   
        //cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham')
        //cy.get('input[value="Beckham"]').should('be.visible')

    })
})
})