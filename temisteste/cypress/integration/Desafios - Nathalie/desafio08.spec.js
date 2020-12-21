///<reference types="cypress"/>

describe("Resgate as divs que começam com id_a e some para ver se é 28", ()=>{ 
    it("GET Soma das divs",() => {
        var sum = 0, cont = 0
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio08.html')
        cy.get('div[id^="id_a_"]')
        .then((div) =>{ 
            for(var i=0; i<div.length; i++){
                cy.get(div[i])
                .invoke('text')
                .then((text) => {
                    sum += parseInt(text)
                    cont++
                    cy.log(`${sum}`) 
                    if(cont == 3){ 
                        expect(sum).to.be.equal(38)
                    }
                })
            }
        })
    })
})