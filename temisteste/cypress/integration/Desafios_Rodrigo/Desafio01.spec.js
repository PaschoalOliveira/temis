describe("Realizando Primeiro Desafio", ()=>{ 
    it("Desafio01-HTML",() => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio01.html')
        .get('input[name="fname"]')
        .should('value', 'David');

        cy.get('input[name="lname"]')
        .should('value', 'Beckham');
    })
    
    it("Desafio01-URL", () => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio01.html');
        cy.get('input[type="submit"]').click();
        cy.url().should('eq', 'http://127.0.0.1:5500/temisFront/Desafios/Desafio01.html?fname=David&lname=Beckham');
    })
})