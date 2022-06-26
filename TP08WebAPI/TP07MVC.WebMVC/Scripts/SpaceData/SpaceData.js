var map = L.map('map').setView([51.505, -0.09], 3);
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 5,
    attribution: '© OpenStreetMap',
}).addTo(map);

var iss_circle = L.circle([51.508, -0.11], {
    color: 'red',
    fillColor: '#f03',
    fillOpacity: 0.5,
    radius: 1000000,
}).addTo(map);

var iss_path = new Array();

var p_lat = $('#iss_lat');
var p_lon = $('#iss_lon');

getCrew();
moveISS();

function getCrew() {
    $.getJSON('http://api.open-notify.org/astros.json', function (data) {
        let number = data['number'];
        $('#humans_in_space').text(number);

        let issCrewList = $('#iss_crew');
        let tiangongCrewList = $('#tiangong_crew');

        let crew = Array.from(data['people']);

        for (member of crew) {
            if (member['craft'] === 'ISS') {
                issCrewList.append(`<li>${member['name']}</li>`);
            } else {
                tiangongCrewList.append(`<li>${member['name']}</li>`);
            }
        }
    });
}

function moveISS() {
    $.getJSON(
        'http://api.open-notify.org/iss-now.json?callback=?',
        function (data) {
            let lat = data['iss_position']['latitude'];
            let lon = data['iss_position']['longitude'];

            p_lat.text('Latitude: ' + lat);
            p_lon.text('Longitude: ' + lon);

            iss_path.push(
                L.circle([lat, lon], {
                    color: 'blue',
                    fillColor: '#f03',
                    fillOpacity: 0.5,
                    radius: 5000,
                }).addTo(map)
            );

            iss_circle.setLatLng([lat, lon]);
            if (iss_path.length < 50) {
                iss_path.shift();
            }

            map.panTo([lat, lon], (animate = true));
        }
    );
    setTimeout(moveISS, 6000);
}
