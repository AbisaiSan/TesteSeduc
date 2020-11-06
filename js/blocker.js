var inicio = function() {
	$.blockUI({
		message : 'Aguarde um instante <blink>...</blink>'
	});
};

var fim = function() {
	$.unblockUI();
};