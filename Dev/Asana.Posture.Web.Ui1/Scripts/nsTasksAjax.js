$.nsAjax = function (options) {
	var defaults = {
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json"
	};

	$.extend(defaults, options);

	return $.ajax(defaults);
}