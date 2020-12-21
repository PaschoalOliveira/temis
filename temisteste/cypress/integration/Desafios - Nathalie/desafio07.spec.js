///<reference types="cypress"/>

describe("Verifique se o segundo elemento é Chá. Faça o translate da página", ()=>{ 
    it("GET Elemento dois é Chá",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio07.html')
        .get('button[type="button"]')
        .click()
        //traduzir e mudar Tea para chá
        cy.get('li')
        .first()
        .next()
        .contains('Chá')
    })
})