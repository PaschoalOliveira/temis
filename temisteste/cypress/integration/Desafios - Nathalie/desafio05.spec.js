///<reference types="cypress"/>

describe("Verifique se o segundo check está marcado", ()=>{ 
    it("GET Item Marcado",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio05.html')
        .get('input[type="checkbox"]')
        .check('Car')
        .should('exist', 'checked')
    })
})