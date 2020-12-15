Then('a natureza do ato é exibida corretamente', () => {
    cy.get('td[scope="row"]')
    .contains('Natureza do Ato')
    .next()
    .invoke('text')
    .should('eq', 'CERTIDÃO GERAL ')
});