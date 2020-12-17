///<reference types="cypress"/>

describe("Verificar número de colunas e linhas da tabela", ()=>{ 
    it("GET Colunas",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')
        .get('table[id="sampleTable"]')
    })
})