describe('Desafio 06 - Cores',() => {
    it('Verificando mudança de cor', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio06.html')
        .get('h2[id="meuTitulo2"]')
        .should('have.css','color','rgb(255, 0, 0)')
        cy.get('input[value="Clique"]')
        .click()
        .get('h2[id="meuTitulo2"]')
        .should('have.css','color','rgb(0, 0, 255)')
    })
})