Given('o acesso ao sistema DAJE do TJ', () => {
    cy.visit('https://eselo.tjba.jus.br/')
})

And('que os dados estejam preenchidos',(dataTable) => {
    console.log(dataTable.rawTable.slice(0))
    dataTable.hashes().forEach(element => {
        cy.get('#atribuicoes').select(element.atribuição)
        cy.get('#tiposatos').select(element.tipo_de_ato)
        cy.get('#comarcas').select(element.comarca)
        cy.get('#cartorios').select(element.cartório)
    })
})
