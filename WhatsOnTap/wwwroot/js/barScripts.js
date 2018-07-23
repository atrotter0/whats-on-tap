$(document).ready(function() {

  function initMap() {
    var options = {
      zoom: 8,
      center: {lat: 45.524169, lng: -122.672927}
    };

    var map = new google.maps.Map(document.getElementById('map'), options);


    function addMarker(props) {
      var marker = new google.maps.Marker({
        position: props.coords,
        map: map;
      });

      var infoWindow = new google.maps.infoWindow({
        content: "<a href='/bars/" + props.id + ">" + props.content + "</a>"
      });

    };


    marker.addListener("click", function() {
      infoWindow.open(map, marker);
    });


    addMarker({
      coords: {lat: 45, lng: -122),
      content: "Name",
      id: 3
    }});



  };

});
