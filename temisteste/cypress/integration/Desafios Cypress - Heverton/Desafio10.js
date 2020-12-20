describe('Desafio 10 - Jogando Sudoku',() => {

    function randShot() {
        return parseInt(Math.random() * (9) + 1)
    }

    it('Preenchendo Campos', () => {
        
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio10.html')
        
        cy.get('input[id="cell-2"]')
        .type(`${randShot()}`)
        .invoke('val')
        .then(val => {
            if(val == 4){
                cy.get('input[id="cell-2"]')
                .invoke('css','background-color','rgb(7, 252, 3)')
            } else {
                cy.get('input[id="cell-2"]')
                .invoke('css','background-color','rgb(252, 3, 11)')
            }
        })

        cy.get('input[id="cell-10"]')
        .type(`${randShot()}`)
        .invoke('val')
        .then(val => {
            if(val == 7){
                cy.get('input[id="cell-10"]')
                .invoke('css','background-color','rgb(7, 252, 3)')
            } else {
                cy.get('input[id="cell-10"]')
                .invoke('css','background-color','rgb(252, 3, 11)')
            }
        })

        cy.get('input[id="cell-11"]')
        .type(`${randShot()}`)
        .invoke('val')
        .then(val => {
            if(val == 2){
                cy.get('input[id="cell-11"]')
                .invoke('css','background-color','rgb(7, 252, 3)')
            } else {
                cy.get('input[id="cell-11"]')
                .invoke('css','background-color','rgb(252, 3, 11)')
            }
        })

        cy.get('input[id="cell-18"]')
        .type(`${randShot()}`)
        .invoke('val')
        .then(val => {
            if(val == 1){
                cy.get('input[id="cell-18"]')
                .invoke('css','background-color','rgb(7, 252, 3)')
            } else {
                cy.get('input[id="cell-18"]')
                .invoke('css','background-color','rgb(252, 3, 11)')
            }
        })

    })
})