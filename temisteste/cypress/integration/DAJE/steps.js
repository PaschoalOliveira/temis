import {Given, When, Then} from "cypress-cucumber-preprocessor/steps"
 
<<<<<<< HEAD
/*Given('Desejo emitir um DAJE', () => {
	return true;
});*/
=======
Given('Desejo emitir um DAJE', () => {
    console.log("cinco");
    return true;
});
>>>>>>> 25742f32ed83548a7df6445e35d88d8611393428

And('preencher dados do "([^"]*)"$', (args1) => {
	console.log(args1);
	return true;
});

When('tento emitir DAJE', () => {
	return true;
});

Then('a DAJE é emitida', () => {
	return true;
});





