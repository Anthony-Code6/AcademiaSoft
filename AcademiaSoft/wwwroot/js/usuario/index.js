$(function () {
	$("#informacion_usuario").DataTable({
		"responsive": true, "lengthChange": false, "autoWidth": false,
		"buttons": ["copy", "csv", "excel", "pdf", "print"]
	}).buttons().container().appendTo('#informacion_usuario_wrapper .col-md-6:eq(0)');

	
	$('.eliminar_usuario').submit(function (e) {
		e.preventDefault()
		var confirmacion = confirm('Deseas Eliminar el Usuario ?')
		if (confirmacion == true) {
			this.submit()
		}
	})
	
})