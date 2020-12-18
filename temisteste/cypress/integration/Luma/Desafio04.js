describe('Desafio 04, Verifique se há o item Red do dropdown, selecione ele, clique no botão', () =>{
    
    it('Verifique se há o item Red do dropdown', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio04.html')
    cy.get('#colorSelect')
    .contains('Red').should('be.visible')
    })
    it('Selecionar Red', () =>{
    cy.get('#colorSelect').select('Red')
    cy.get('input[type="button"]').click()
    //.contains('Parabéns! Desafio 4 Concluído').should('be.visible')
    })
})
//OK