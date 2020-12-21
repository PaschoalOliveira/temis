describe('Desafio 07 - Traduzindo a Página',() => {
    it('Verificando mudança de cor', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio07.html')
        cy.get('body > form > ul > li:nth-child(2)')
        .invoke('text')
        .should('not.equal','Chá')
        .get('button[type="button"]')
        .click()
        cy.get('body > form > ul > li:nth-child(2)')
        .invoke('text')
        .should('be.equal','Chá')
    })
})