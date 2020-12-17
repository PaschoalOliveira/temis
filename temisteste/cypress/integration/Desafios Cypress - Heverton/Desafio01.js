describe('Desafio 01 - Assert por nome',() => {

    const fname = 'David'
    const lname = 'Beckham'

    it('Testando correspondência no Campo Texto', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html')
        cy.get('input[name="fname"]')
        .invoke('val')
        .should('contain',fname)
        cy.get('input[name="lname"]')
        .invoke('val')
        .should('contain', lname)
    })
    it('Testando correspondência no URL', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html')
        cy.get('input[value="Submit"]')
        .click()
        .url()
        .should('contain',fname)
        .should('contain', lname)
    })
})