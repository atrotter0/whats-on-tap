function addBeer(beerId) {
	$.ajax({
		type: "POST",
		data: { beerId: beerId },
		url: "/user/beers",
		success: function (result) {
			console.log("Success!");
			//add alert
		},
		error: function(error) {
			console.log("Error, not appending: " + JSON.stringify(error));
		}
	});
}

$(document).ready(function() {
	$(".add-beer").click(function() {
		console.log("clicked add beer");
		var beerId = $(this).attr("id");
		addBeer(beerId);
	});
});