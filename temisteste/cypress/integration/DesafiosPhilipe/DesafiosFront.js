describe('Fazendo desafios',() =>{
    it('Desafio 1',() => {
        cy.visit("http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html")
        cy.get('[name="fname"]')
            .invoke('attr', 'value')
            .then((value) =>{
                cy.log(value)
            })
        cy.get('[name="lname"]')
            .invoke('attr', 'value')
            .then((value) =>{
                cy.log(value)
            })
    })

    it('Desafio 1 pela Url', () => {
        cy.visit("http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio01.html")

        cy.get('[value="Submit"]')
            .click()
        cy.url()
            .should('contains', 'David')
            .then(() => {
                cy.url()
                .should('contains', 'Beckham')
            })
    })

    it('Desafio 2', () => {
        cy.visit("http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio02.html")

        cy.get('tr')
            .its('length')
            .then((colunas) => {
                cy.log(colunas)
            })
        cy.get('tr')
            .first()
            .children()
            .its('length')
            .then((linhas) => {
                cy.log(linhas)
            })
    })

    it('Desafio 3', () => {
        cy.visit("http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio03.html")
        cy.get('thead tr td')
            .its('length')
            .then((colunas) => {
                    cy.get('tbody tr')
                    .its('length')
                    .then((linhas)=>{
                        for(var i=0; i<colunas ; i++){
                            var resultado = 0
                            for(var j=0; j<linhas; j++){
                                cy.get('tbody')
                                    .children()
                                    .eq(j)
                                    .children()
                                    .eq(i)
                                    .invoke('text')
                                    .then((valor)=>{
                                        resultado+=parseInt(valor)
                                        console.log(resultado, valor)
                                    })
                                    cy.log(resultado)
                                
                            }
                            cy.log(resultado)
                            cy.get('tfoot tr td')
                                .eq(i)
                                .invoke('text')
                                .should('eq', resultado)
                        }
                    })
                    
                
            })
    })

    it("Desafio 4",() => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio04.html')
        const stub = cy.stub()
        cy.on('window:alert', stub)
        cy.get('#colorSelect')
            .select('Red')
        cy.get('[value="Clique"]')
            .click()
            .then(() =>{
                expect(stub.getCall(0)).to.be.calledWith('Parabéns! Desafio 4 Concluído')
            })
    })

    it("Desafio 5",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio05.html')
        cy.get('#vehicle2')
            .should('have.attr', 'checked')
    })

    it("Desafio 6",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio06.html')
        cy.get('[value="Clique"]')
            .click()
        cy.get('#meuTitulo2')
            .should('have.css', 'color', 'rgb(0, 0, 255)')
    })

    it("Desafio 7",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio07.html')

    })

    it("Desafio 8",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio08.html')
        var resultado=0,contador=0
        cy.get('div[id^="id_a"]')
            .then((divs)=>{
                for(var i=0; i<divs.length; i++){
                    console.log(divs)
                    cy.get(divs[i])
                        .invoke('text')
                        .then((value)=>{
                            resultado+=parseInt(value)
                            contador++
                            cy.log(resultado)
                            if(contador==3){
                                expect(resultado).to.be.eq(38)
                            }
                        })
                }
            })
    })

    it("Desafio 9",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio09.html')
        const stub = cy.stub()
        cy.on('window:alert', stub)
        cy.get('[value="Clique"]')
            .click()
            .then(() =>{
                expect(stub.getCall(0)).to.be.calledWith('Você consegue verificar essa mensagem?')
            })  
    })

    it("Desafio 10",() =>{
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio10.html')
    })
})
