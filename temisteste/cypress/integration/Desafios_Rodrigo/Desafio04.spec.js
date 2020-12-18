describe("Realizando Quarto Desafio", ()=>{ 
    it("Desafio04-HTML",() => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio04.html')
        .get('select[id="colorSelect"]')
        .select('Red')
        .get('input[type="button"]')
        .click();
        
        cy.on('window:alert', (mensagem) => {
            expect(mensagem).to.equal('Parabéns! Desafio 4 Concluído');
          })
    })
})