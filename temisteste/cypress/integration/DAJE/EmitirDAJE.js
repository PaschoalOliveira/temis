And('preencher dados do {string},{string},{string},{string}', (contribuinte, endereço, cidade, doc) => {
	cy.get('#contribuinte').type(contribuinte)
	cy.get('#endereco_completo').type(endereço)
	cy.get('#cidade').type(cidade)
	cy.get('#maskcpf').type(doc)
});

When('tento emitir DAJE', () => {
	cy.get('input[id="commandButtonEmitirDaj"]').click();
});

Then('a DAJE é emitida', () => {
    cy.get('div[id=img_print]').should('exist')
});
