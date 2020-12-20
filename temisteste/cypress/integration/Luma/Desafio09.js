describe('Desafio 09, Verifique a mensagem no alert ao clicar no botão', () =>{
    
    it('Verificar mensagem do alert', () =>{
    cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio09.html')
    cy.get('input[type="button"]').click()
    cy.on('window:alert', str => {
        console.log(str)
        expect(str).to.equal('Você consegue verificar essa mensagem?')
        //console.log serve para a emissão de informações de registro em geral
        //ou seja vai verificar se no codigo possui este alert
    })
    //cy.on('window:alert', (mensagem) => {
        //expect(mensagem).to.equal('Você consegue verificar essa mensagem');
        //verificar o alert aparecendo
      //}) 
      // OBS: ESTE METODO NAO ESTA FUNCIONANDO
        
    })
})