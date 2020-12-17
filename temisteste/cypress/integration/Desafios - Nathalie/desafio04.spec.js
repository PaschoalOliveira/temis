///<reference types="cypress"/>

describe("Verifique se há o item Red do dropdown, selecione ele, clique no botão", ()=>{ 
    it("GET item Red",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio04.html')
        .get('select[id="colorSelect"]')
        .select('Red')
        .get('input[type="button"]')
        .click()
    })
})