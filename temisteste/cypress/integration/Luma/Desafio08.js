describe('Desafio 08, Resgate as divs que começam com "id_a" e some para ver se é 28', () =>{
    
    it('Divs com id_a', () =>{
    var sum = 0, cont = 0
    //criar variavel e constante para a soma (sum=soma), valor 0 pois inicia com 0 
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio08.html')
        cy.get('div[id^="id_a_"]')
        //localizar as divs
        .then((div) =>{
            //então os divs 
            for(var i=0; i<div.length; i++){
                //as variaveis que criei + comando lenght que é percorrer
                cy.get(div[i])
                .invoke('text')
                //usamos quando o item anterio já foi citado, invoke texto que sao os numeros
                .then((text) => {
                    sum += parseInt(text)
                    cont++
                    cy.log(`${sum}`)
                    if(cont == 3){
                        expect(sum).not.to.be.equal(28)
                        expect(sum).to.be.equal(38)
                
                    }
                })
            }
        })
    })
})  