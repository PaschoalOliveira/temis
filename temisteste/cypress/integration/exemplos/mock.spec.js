///<reference types="cypress"/>

describe('Trabalhando com stubs',()=>{
    
    before(() =>{
        cy.visit('https://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_alert');
    })
    
    it('Alert com Mock', ()=>{
        expect(true);
    })


})
