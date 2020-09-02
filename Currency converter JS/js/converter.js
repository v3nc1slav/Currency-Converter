import {showSuccess, showError } from "./notifications.js";

export async function  converter(){

const input = document.getElementById('inputAmount');
const from = document.getElementById('dropDownListFrom');
const to = document.getElementById('dropDownListTo');
const divAlert = document.getElementById('alert')

    if ( validation()) {
        var requestOptions = {
            method: 'GET',
            redirect: 'follow'
        };

        const ulr = ` https://api.exchangeratesapi.io/latest?base=${from.value}`;

        fetch(ulr, requestOptions)
            .then(response => response.text())
            .then(result => calcoleyt(result))
            .catch(error => showError('error', error));
    }

function validation(){
    try{
    const number = Number(input.value);
    if (!(Number.isInteger(number)) || input.value<= 0) {
        input.className ="form-control is-unvalid";
        throw new Error("Please enter a valid value in the field Amount!");
    }
    input.className ="form-control is-valid";

    if (from.value === to.value) {
        from.className ="form-control is-unvalid";
        to.className ="form-control is-unvalid";
        throw new Error("Please select a different value for the TO field than in the FROM field!");
    }
    return true;
}catch (err) {
    showError(err.message);
}
}

async function calcoleyt(jsan) {
    let text = jsan.replace(/{"/gi, '');
    text = text.replace(/"/gi, '');
    text = text.replace(/rates:/gi, '');
    let arr = text.split(",");

    for (var i = 0; i < arr.length; i++) {
        const value = arr[i].split(":");
        if (value[0] === to.value) {
            const result = (value[1] * input.value);
            
            let alert = document.createElement("div");
            alert.textContent = `${input.value} ${from.value} to ${result.toFixed(2)} ${to.value}`;
            //const alert = el('div', `${input.value} ${from.value} to ${result.toFixed(2)} ${to.value}`, { class: "alert alert-secondary" });
            divAlert.appendChild(alert);
        }
    }
}
}

