describe('Desafio 02, Verificar quantas colunas e linhas há na tabela', () =>{
    
    it('Verificar Quantas Colunas', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html')
        cy.get('tr')
        .its('length')
        .then((colunas) => {
            console.log(colunas)//.expect(colunas).to.equal('2')
        })
    })
    it('Verificar Quantas Linhas', () =>{
        cy.get('tr')
        .first()
        .next(1)
        .contains('2')
        .its('lenght')
        .then((linhas) => {
            console.log(linhas)//.expect(linhas).to.equal('2')
        })
    })

        //cy.get('tr.Row1 cell').parents()
})
//Não completo