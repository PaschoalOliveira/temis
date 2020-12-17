describe('Desafio 01, Primeiro e último nome', () =>{
    
    it('Verificando Primeiro nome', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham')
        //cy.get('form')
        //cy.request(Cypress.env('Firstname'))
        //cy.request(Cypress.env('Last name'))
        //cy.contains('David Beckham')    
        cy.get('input[value=David]').should('be.visible')
    })

    it('Verificando último nome', () =>{   
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham')
        cy.get('input[value="Beckham"]').should('be.visible')

    })
})

//$ export CYPRESS_Firstname = David