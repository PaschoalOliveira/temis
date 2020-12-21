///<reference types="cypress"/>

describe("Resgate as divs que começam com id_a e some para ver se é 28", ()=>{ 
    it("GET Soma das divs",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio09.html')
        .get('input[type="button"]')
        .click()
        .wait(8000)
        cy.on('window:alert', (msg) => {
            expect(msg).to.eq('Você consegue verificar essa mensagem?')
      })
    })
})