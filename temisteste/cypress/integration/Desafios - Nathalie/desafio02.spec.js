///<reference types="cypress"/>

describe("Verificar número de colunas e linhas da tabela", ()=>{ 
    it("GET Colunas",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')

        cy.get('tr')
        .first()
        .children()
        .its('length')
        .then((qtdColuna) => {
            cy.log(`São ${qtdColuna} colunas`)
        })
    })
    it("GET Linhas",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')

        cy.get('tr')
        .its('length')
        .then((qtdlinha) => {
            cy.log(`São ${qtdlinha} linhas`)
        })
    })
})