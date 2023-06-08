//$('.boleta-notas').click(async function (e) {
const Guardar = async () => {
    var datos = []

    $("#notas-boletas tr").each(function () {
        var informacion = {};
        //informacion.codigo = $($(this).find('td:eq(0) input')).val();
        informacion.id = $($(this).find('td:eq(0) input')).val();
        informacion.nota1 = $($(this).find('td:eq(2) input')).val();
        informacion.nota2 = $($(this).find('td:eq(3) input')).val();
        informacion.nota3 = $($(this).find('td:eq(4) input')).val();
        informacion.nota4 = $($(this).find('td:eq(5) input')).val();

        datos.push(informacion);
    });

    console.log(datos)
    /*
    $.ajax({
        type: "post",
        url: "/BoletaNotas/Registrar",
        data: datos,
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },
        dataType: 'JSON',
        success: function (response) {
        }
    });
    */
    try {
        const response = await fetch("/BoletaNotas/Registrar",
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json;charset=UTF-8' },
                body: JSON.stringify(datos)
            })
        const data = await response.json()

        console.log(data)
    } catch (err) {
        console.log(err)
    }
    

}
