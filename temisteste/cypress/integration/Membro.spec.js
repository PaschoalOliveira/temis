///<reference types="cypress"/>

describe("Teste de Membros", ()=>{ 
    it("GET Membros",()=>{
        cy.request({
            method:'GET',
            url:"https://localhost:5001/Membro"
        }).then((response) =>{
            const body = response.body;
            var achou = false;
            console.log(body);
            body.forEach((elemento) =>{
                 if(elemento.nome == "joao"){
                    achou = true;
                 }
            })
            expect(achou).to.be.equal(true);
        })
    })
})