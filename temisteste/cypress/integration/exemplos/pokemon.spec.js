///<reference types="cypress"/>

describe("Teste Dogs", ()=>{ 
    it("GET Membros",()=>{
        cy.request('GET', 'https://pokeapi.co/api/v2/pokemon/ditto/')
        .then((response) => {
            response.body.abilities.forEach(element => {
                expect(element.name).to.have.property('name', 'teste') 
            }) 
        });
    })
})