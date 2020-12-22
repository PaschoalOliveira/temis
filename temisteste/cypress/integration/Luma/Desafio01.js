describe('Desafio 01, Primeiro e último nome', () =>{
    
    it('Verificando Primeiro nome', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham')
        cy.get('form')
        //cy.request(Cypress.env('Firstname'))
        //cy.request(Cypress.env('Last name'))
        //var firstName = Cypress.env('Firstname')
        //debugger
        //cy.contains(String(firstName))      
        cy.get('input[value=' + Cypress.env('Firstname') + ']').should('be.visible')
    })

    it('Verificando último nome', () =>{   
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham')
        cy.get('input[value=' + Cypress.env('Lastname') + ']').should('be.visible')

    })
})

//$ export CYPRESS_Firstname = David
//Ok