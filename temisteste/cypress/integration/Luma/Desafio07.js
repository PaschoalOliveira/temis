describe('Desafio 07, Verifique se o segundo elemento é "Chá". Faça o translate da página', () =>{
    
    it('Verificar segundo elemento Chá', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio07.html')
    expect('Tea').not.to.be.equal('Chá')
    cy.get('li').eq(1)
        // eq = obter um elemento do li
    .rightclick('center', { force: true })
    })
   it('Traduzir')
})