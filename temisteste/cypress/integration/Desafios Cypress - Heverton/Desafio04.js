describe('Desafio 04 - Selecionando',() => {
    
    it('Selecionando item', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio04.html')
        .get('select[id="colorSelect"]')
        .select('Red')
        .get('input[value="Clique"]')
        .click()
        cy.on('window:alert',res => {
            expect(res).to.equal('Parabéns! Desafio 4 Concluído')
        })
    })
        
})