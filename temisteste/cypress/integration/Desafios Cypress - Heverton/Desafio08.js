describe('Desafio 08 - Contando elementos Parte 2',() => {

    it('Somando Divs', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio08.html')
        .get('div[id^="id_a"]')
        .then( res => {

            var itens = res.length
            var goal = 28

            for(var i = 0; i < itens; i++ ){
                var sum = 0
                var con = 0
                cy.get(res[i])
                .invoke('text')
                .then( res => {
                    sum = sum + parseInt(res)
                    con++
                    if(con == itens) {
                        expect(sum).to.equal(goal)
                    }
                })
            }
        })
    })
})