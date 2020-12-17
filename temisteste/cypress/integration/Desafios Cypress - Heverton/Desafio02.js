describe('Desafio 02 - Contando elementos',() => {
    var rowSize = 0
    var colSize = 0
    it('Contando Linhas', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')
        cy.get('tr')
        .its('length')
        .then( length => {
            rowSize = length
            cy.log(`A quantidade de LINHAS é igual a ${length}`)
        })
    })
    it('Contando Colunas', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')
        cy.get('td')
        .its('length')
        .then( length => {
            colSize = length/rowSize
            cy.log(`A quantidade de COLUNAS é igual a ${colSize}`)
        })
    })
})