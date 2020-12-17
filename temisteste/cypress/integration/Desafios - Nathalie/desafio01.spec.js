///<reference types="cypress"/>

describe("Verifique o primeiro e o último nome", ()=>{ 
    it("GET Primeiro nome",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html')
        .get('input[name="fname"]')
        .should('value', 'David')
    })
    it("GET Último nome", () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html')
        .get('input[name="lname"]')
        .should('value', 'Beckham')
    })
})