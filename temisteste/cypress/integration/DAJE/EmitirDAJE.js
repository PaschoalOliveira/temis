And('preencher dados do contribuinte', (dataTable) => {
	dataTable.hashes().forEach(element =>{
		cy.get('#contribuinte').type(element.contribuinte)
		cy.get('#endereco_completo').type(element.endereço)
		cy.get('#cidade').type(element.cidade)
		cy.get('#maskcpf').type(element.documento)
	})
});


When('tento emitir DAJE', () => {
	cy.get('input[id="commandButtonEmitirDaj"]').click();
});

Then('a DAJE é emitida', () => {
    cy.get('div[id=img_print]').should('exist')
});






























































































































































































