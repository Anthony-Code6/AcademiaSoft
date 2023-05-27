$(function () {
	$("#informacion_alumno").DataTable({
		"responsive": true, "lengthChange": false, "autoWidth": false,
		"buttons": ["copy", "csv", "excel", "pdf", "print"]
	}).buttons().container().appendTo('#informacion_alumno_wrapper .col-md-6:eq(0)');

	$('.eliminar_alumno').submit(function (e) {
		e.preventDefault()
		var confirmacion = confirm('Deseas Eliminar el Alumno ?')
		if(confirmacion == true) {
			this.submit()
		}
	})
})
