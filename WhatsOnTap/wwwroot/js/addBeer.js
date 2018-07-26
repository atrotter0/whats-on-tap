function addBeer(beerId) {
	$.ajax({
		type: "POST",
		data: { beerId: beerId },
		url: "/user/beers",
		success: function (result) {
			displayAlert(".beer-added");
		},
		error: function(error) {
			console.log("Error, not appending: " + JSON.stringify(error));
		}
	});
}

function displayAlert(element) {
	$(element).fadeIn(800).delay(3000).fadeOut(1200);
}

$(document).ready(function() {
	$(".add-beer").click(function() {
		var beerId = $(this).attr("id");
		addBeer(beerId);
	});
});