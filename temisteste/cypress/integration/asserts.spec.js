it('Equality',()=>
{
    const a = 1;
    expect(a,'Deveria ser 1').equal(1);
    expect('a').not.to.be.equal('b');
})

it('Truthy', () => {
    const a = true;
    
    expect(a).to.be.true;
    expect(true).to.be.equal(true);
})

it('Object Quality', () =>
{
    const objeto = {
        a:1,
        b:2
    }

    expect(objeto).equals(objeto);
    expect(objeto).to.have.property('b',2);
    expect(objeto.b).to.be.a('number');
})

it('Numbers', ()=>{
    const number = 4;
    const floatNumber = 12.2345;
    
    expect(number).to.be.above(2);
    expect(number).to.be.below(6);
}
)













