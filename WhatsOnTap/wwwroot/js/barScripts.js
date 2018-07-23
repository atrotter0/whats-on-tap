
function initMap() {
  var options = {
    zoom: 8,
    center: (lat: xxxx, lng: xxxx)
  }

  var map = new google.maps.Map(document.getElementById('map'), options);


  marker.addListener("click", function() {
    infoWindow.open(map, marker);
  })

  
  foreach (var bar in model) {
    addMarker({
      coords: {lat: @bar.Lat, lng: @bar.Long},
      content: bar
    })
  };


  function addMarker(props) {
    var marker = new google.maps.Marker({
      position: props.coords,
      map: map;
    });

    var infoWindow = new google.maps.infoWindow({
      content: "<a href='/bars/" + bar.BarId + ">" + bar.BarName + "</a>"
    });

  }
}
