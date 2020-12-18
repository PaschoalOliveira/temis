describe('Desafio 05 - Checkbox',() => {
    it('Verificando item marcado', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio05.html')
        .get('input[id="vehicle2"]')
        .should('be.checked')
    })
})