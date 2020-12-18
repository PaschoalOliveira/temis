describe("Realizando Nono Desafio", ()=>{ 
    it("Desafio09-HTML",() => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio09.html')
        .get('input[value="Clique"]')
        .click();
        
        cy.on('window:alert', (mensagem) => {
            expect(mensagem).to.equal('Você consegue verificar essa mensagem?');
          })
    })
})