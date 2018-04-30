



var address;

function geoCode(address) {
    var location = address;
    //http request using axios
    axios.get('https://maps.googleapis.com/maps/api/geocode/json',
        {
            params: {
                address: location,
                key: 'AIzaSyCj7HEZcGIUWHwc6wb3_ZyJ5fN23VxqW0Q'
            }
        }).then(function (response) {
        //log full response
        console.log(response);

        //log formatted adress
        console.log(response.data.results[0].formatted_address);



    }).catch(function (error) {
        console.log(error);
    });

}