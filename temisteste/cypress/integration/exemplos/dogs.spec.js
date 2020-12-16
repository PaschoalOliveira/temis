///<reference types="cypress"/>

describe("Teste Dogs", ()=>{ 
    it("GET Membros",()=>{
        cy.request({
            method:'GET',
            url:"https://dog.ceo/api/breeds/list/all"
        }).then((response) =>{
            const body = response.body;
            debugger;
            var achou = false;
            console.log(body);

            var nomeRaca = "shepherd"
            for(var raca in body.message) {
                if(raca == nomeRaca){
                    achou = true;
                }else{
                    
                    body.message[raca].forEach((subRaca) =>{
                         cy.log(subRaca);
                         if(subRaca == nomeRaca){
                            achou = true;
                         }
                    }) 
                 }
            }
            expect(achou).to.be.equal(true);
        })
    })
})