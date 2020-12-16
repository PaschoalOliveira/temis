///<reference types="cypress"/>

describe("Teste Dogs", ()=>{ 
    it("GET Membros",()=>{
        cy.request({
            method:'GET',
            url:"https://pokeapi.co/api/v2/pokemon/ditto/"
        }).then((response) =>{
            var achou = false;
            debugger;
            response.body.abilities.forEach((abi) => {
                if(abi.name == "limber"){
                    achou = true;
                }
            })
            expect(achou).to.be.equal(true);
        })
    })
})