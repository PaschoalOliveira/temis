describe('Desafio 07 - Traduzindo a Página',() => {
    it('Verificando mudança de cor', () => {
        cy.visit('http://127.0.0.1:5500/temis/temisFront/Desafios/Desafio07.html',{
            onBeforeLoad (win) {
                Object.defineProperty(win.navigator, 'language', {
                value: 'pt-BR'
                })
            }
        })
    })
})