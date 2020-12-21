///<reference types="cypress"/>

describe("Verifique se a cor fica azul após clicar no botão", ()=>{ 
    it("GET Cor do texto",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio06.html')
        .get('input[type="button"]')
        .click()
        cy.get('h2[id="meuTitulo2"]')
        .should('have.css', 'color', 'rgb(0, 0, 255)')
    })
})