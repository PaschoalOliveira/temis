describe('Desafio 06, Verifique se a cor fica azul após clicar no botão', () =>{
    
    it('Verificando Cor Azul', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio06.html')
    cy.get('input[type="button"]').click()
    cy.get('#meuTitulo2')
    .contain('style', 'color: blue')
    })
})