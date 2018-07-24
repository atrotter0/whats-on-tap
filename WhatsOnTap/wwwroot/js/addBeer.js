function addBeer(beerId) {
	$.ajax({
		type: "POST",
		data: { beerId: beerId },
		url: "/user/beers",
		success: function (result) {
			console.log("Success!");
			var text = "Beer added!";
			displayAlert(text);
		},
		error: function(error) {
			console.log("Error, not appending: " + JSON.stringify(error));
		}
	});
}

function displayAlert(text) {
	$(".alert").text(text).fadeIn(800).delay(3000).fadeOut(1200);
}

$(document).ready(function() {
	$(".add-beer").click(function() {
		console.log("clicked add beer");
		var beerId = $(this).attr("id");
		addBeer(beerId);
	});
});