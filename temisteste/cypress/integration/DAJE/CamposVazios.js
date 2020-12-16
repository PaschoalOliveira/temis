And('selecionar o tipo {string}',(tipo) => {
    cy.get(`input[value=${tipo}]`).click()
    //` SERVE PARA INTERPOLAR STRING
})

When("tentar emitir daje", () => {
	cy.get('input[id="commandButtonEmitirDaj"]').click();
})

Then("são exibidas mensagens de erro", () => {
    cy.wait(500)
    .screenshot()
})
