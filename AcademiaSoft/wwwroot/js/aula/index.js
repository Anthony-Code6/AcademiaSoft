$(function () {
	$("#informacion_aula").DataTable({
		"responsive": true, "lengthChange": false, "autoWidth": false,
		"buttons": ["copy", "csv", "excel", "pdf", "print"]
	}).buttons().container().appendTo('#informacion_aula_wrapper .col-md-6:eq(0)');

	$('.eliminar_alumno').submit(function (e) {
		e.preventDefault()
		var confirmacion = confirm('Deseas Eliminar el Aula ?')
		if(confirmacion == true) {
			this.submit()
		}
	})
})
