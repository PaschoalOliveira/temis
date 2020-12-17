describe('Desafio 05, Verifique se o segundo check está marcado', () =>{
    
    it('Verifique se o segundo check está marcado', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio05.html')
    cy.get('#vehicle2')
    .check({ force: true }).should('be.checked')
    //checar se o item veiculo 2 esta marcado
    })
   
})