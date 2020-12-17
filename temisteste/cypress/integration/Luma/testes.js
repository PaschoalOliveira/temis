/// <reference types="Cypress" />

describe('PoC Cypress', () => {

    it('Login', () => {

        cy.visit('https://maiconpinto.github.io/poc-cypress/')

        cy.get('#inputEmail').type('maiconsilva.pinto@gmail.com')

        cy.get('#inputPassword').type('123456')

        cy.get('button[type="submit"]').click()

        cy.url().should('contain', 'dashboard')

    })

})