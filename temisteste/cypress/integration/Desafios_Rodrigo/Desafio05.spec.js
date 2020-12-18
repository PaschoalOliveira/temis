describe("Realizando Quinto Desafio", ()=>{ 
    it("Desafio05-HTML",() => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio05.html')
        .get('#vehicle1').check()
        .get('#vehicle3').check()

        cy.get('#vehicle1').should('be.checked');
        cy.get('#vehicle2').should('be.checked');
        cy.get('#vehicle3').should('be.checked');
    })
})