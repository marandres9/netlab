var entries = 0;

const form = document.getElementById('form');

// ejemplo de event binding usando jQuery
$('#btn-scrollToForm').click(() => {
    form.scrollIntoView(true);
});


form.addEventListener('submit', function (event) {
    event.preventDefault();
    // obtiene los elementos del formulario
    const fname = form.elements['first-name'];
    const lname = form.elements['last-name'];
    const birthDate = form.elements['birth-date'];
    const age = { value: getAge(birthDate.value).toString() };
    const adress = form.elements['adress'];

    // valida los datos ingresados
    if (!fname.value || !lname.value) {
        document.getElementById('invalid-names').style.display = 'block';
        return;
    }
    if (
        !birthDate.value ||
        new Date() < new Date(birthDate.value + 'T00:00:00')
    ) {
        document.getElementById('invalid-date').style.display = 'block';
        return;
    }
    if (!adress.value) {
        document.getElementById('invalid-adress').style.display = 'block';
        return;
    }

    // busca la tabla en el DOM, crea una nueva fila y le agrega los datos validados
    const table = document.getElementById('table');
    const row = document.createElement('tr');
    const formEntry = [fname, lname, age, birthDate, adress];
    for (let item of formEntry) {
        let data = document.createElement('td');
        data.innerText = item.value;
        row.appendChild(data);
    }
    // agrega la fila a la tabla
    table.append(row);

    updateHeroText();
    form.reset();
    window.scroll(0, 0)
});

form.addEventListener('reset', function (event) {
    // al provocar un reset en el formulario elimina todas las alertas que se muestran si
    // el usuario ingresa datos invalidos
    const alerts = Array.from(document.querySelectorAll('.alert-danger'));
    for (let alert of alerts) {
        alert.style.display = 'none';
    }
});

function getAge(birthDateString) {
    // calcula la edad de la persona
    let today = new Date();
    let birthDate = new Date(birthDateString + 'T00:00:00');
    let years = today.getFullYear() - birthDate.getFullYear();
    let months = today.getMonth() - birthDate.getMonth();

    if (months < 0 || (months == 0 && today.getDate() < birthDate.getDate())) {
        years--;
    }
    return years;
}

function updateHeroText() {
    // muestra al usuario cuantos veces agrego datos a la tabla
    const heroText = document.getElementById('hero-text');
    heroText.innerHTML = `You\'ve added ${++entries} entries`;
}
