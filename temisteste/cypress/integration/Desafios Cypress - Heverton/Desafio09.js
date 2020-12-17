describe('Desafio 09 - Lidando com Alerts',() => {
    it('Testando Alert', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio09.html')
        cy.get('input[value="Clique"]')
        .click()
        cy.on('window:alert', str => {
            console.log(str)
            expect(str).to.equal('Você consegue verificar essa mensagem?')
        })
    })
})