describe("Realizando Sexto Desafio", ()=>{ 
    it("Desafio06-HTML",() => {
        cy.visit('http://127.0.0.1:5500/temisFront/Desafios/Desafio06.html');
        cy.get('[id="meuTitulo2"]')
        .should('have.css', 'color', 'rgb(255, 0, 0)');

        cy.get('input[value="Clique"]').click()
        .get('[id="meuTitulo2"]')
        .should('have.css', 'color', 'rgb(0, 0, 255)');
    })
})