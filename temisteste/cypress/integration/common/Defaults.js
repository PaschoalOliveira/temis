Given('o acesso ao sistema DAJE do TJ', () => {
    cy.visit('https://eselo.tjba.jus.br/')
})

And('que os dados estejam preenchidos',() => {
    //console.log(dataTable.rawTable.slice(1))
    cy.get('#atribuicoes').select('REGISTRO_CIVIL')
    cy.get('#tiposatos').select('VIII - CERTIDAO EM GERAL')
    cy.get('#comarcas').select('ALAGOINHAS')
    cy.get('#cartorios').select('REGISTRO CIVIL 1 OFICIO - ALAGOINHAS') 
})
