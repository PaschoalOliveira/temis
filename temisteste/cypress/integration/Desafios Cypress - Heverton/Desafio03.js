describe('Desafio 03 - Contando elementos',() => {

    const rowSize = 3
    const colSize = 4

    it('Somando Colunas', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio03.html')
        for(var i = 1; i <= colSize; i++) {
            var sum = 0
            var val = 0
            for(var j = 1; j <= rowSize; j++) {
                cy.get(`#sampleTable > tbody > tr:nth-child(${j}) > td:nth-child(${i})`)
                .invoke('text')
                .then( text => {
                    val = parseInt(text)
                    console.log(val)
                })
                console.log(val)
            }
        }
    })
})