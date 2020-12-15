And('preencher dados do {string},{string},{string},{string}', (contribuinte, endereço, cidade, CPF) => {
	cy.get('#contribuinte').type(contribuinte)
	cy.get('#endereco_completo').type(endereço)
	cy.get('#cidade').type(cidade)
	cy.get('#maskcpf').type(CPF)
})

When('tentar emitir daje',() => {
    cy.get('input[id="commandButtonEmitirDaj"]').click();
})

Then('é exibida um mensagem de erro', () => {
    cy.get('li[class=msg_red]').should('contain','CPF Inválido, digite novamente.')
});