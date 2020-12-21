describe('Desafio 03 - Contando elementos',() => {

    const rowSize = 3
    const colSize = 4

    it('Somando Colunas', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio03.html')
        for(var i = 1; i <= colSize; i++) {
            var sum = 0
            var con = 0
            var fCell = 1
            for(var j = 1; j <= rowSize; j++) {
                cy.get(`#sampleTable > tbody > tr:nth-child(${j}) > td:nth-child(${i})`)
                .invoke('text')
                .then( text => {
                    sum = sum + parseInt(text)
                    con++
                    if(con == rowSize){
                        console.log(sum)
                        //var res = sum.toString()
                        cy.get(`#sampleTable > tfoot > tr > td:nth-child(${fCell})`)
                        .invoke('text')
                        .then( res => {
                            console.log(sum)
                            if(res == sum.toString()){
                                cy.log(`O valor da célula (${res}), é igual ao da soma (${sum})`)
                            } else {
                                cy.log(`O valor da célula (${res}), não é igual ao da soma (${sum})`)
                            }
                            fCell++
                            sum = 0
                            con = 0
                        })
                        
                    }
                })
            }
        }
    })
})