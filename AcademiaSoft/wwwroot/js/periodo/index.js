$(function () {
	$("#informacion_periodo").DataTable({
		"responsive": true, "lengthChange": false, "autoWidth": false,
		"buttons": ["copy", "csv", "excel", "pdf", "print"]
	}).buttons().container().appendTo('#informacion_periodo_wrapper .col-md-6:eq(0)');

	$('.eliminar_periodo').submit(function (e) {
		e.preventDefault()

		var confirmacion = confirm('Deseas Eliminar el Periodo ?')
		if (confirmacion == true) {
			this.submit()
		}
	})
})
