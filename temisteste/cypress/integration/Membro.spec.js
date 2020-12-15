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
    
    it("GET Membros por ID",() => {
        cy.request({
            method:'GET',
            url:"https://localhost:5001/Membro/1"
        }).its('body').its('membroId').then((membroId)=>{
            expect(membroId).to.be.eq(2);
        })
    })
})