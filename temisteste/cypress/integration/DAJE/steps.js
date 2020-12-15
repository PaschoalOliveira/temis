import {Given, When, Then} from "cypress-cucumber-preprocessor/steps"
 
Given('Desejo emitir um DAJE', () => {
	return true;
});

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
