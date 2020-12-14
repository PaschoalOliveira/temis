it('sem testes ainda', ()=> {})

const getSomething = () => {
    return new Promise((resolve,reject) =>
    {
        setTimeout(() => {
            resolve(13);
        },1000000)
    })
}

const system = () =>
{
    console.log('init');
    const prom = getSomething();
    prom.then(some => {
        console.log(some);
    });
    console.log('end');
}

const system2 = async () =>
{
    console.log('init');
    const prom = await getSomething();
    console.log(prom);
    console.log('end');
}

system2();