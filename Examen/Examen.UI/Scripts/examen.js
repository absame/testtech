Examen = {};

Examen.CreaEventos = function () {
    $(".form-horizontal").validate({
        rules: {
            "Nombre": {
                required: true
            },
            "Paterno": {
                required: true
            },
            "Materno": {
                required: true
            },
            "Telefono": {
                required: true,
                digits: true
            },
            "Email": {
                required: true,
                email: true
            }


        },

        messages: {
            Nombre: "El Nombre es requerido",
            Paterno: "El Apellido Paterno es requerido",
            Materno: "El Apellido Materno es requerido",
            Telefono: "El telefono es requerido y solo se aceptan números",
            Email: "El email es requerido y debe de ser tipo email@dominio"
        },

        // Called when the element is invalid:
        highlight: function (element) {
            $(element).css('border-color', '#e74c3c');
        },

        // Called when the element is valid:
        unhighlight: function (element) {
            $(element).css('border-color', '#2980b9');
        }
    });
    $("#btnGuardar").on("click", function () {
        var validator = $(".form-horizontal");
        if (validator.valid()) {
            Examen.GuardarCliente($("#txtNombre").val(), $("#txtApellidoPaterno").val(), $("#txtApellidoMaterno").val(), $("#txtTelefono").val(), $("#txtEmail").val())
        }
    });
}

Examen.ObtenerCliente = function () {
    $.ajax({
        type: 'GET',
        url: '../Home/ObtenerCliente',
        async: true,
        contentType: 'application/json; charset=utf-8',
        dataType: "JSON",
        cache: false,
        success: function (result) {

            $("#tblCliente > tbody ").html("");
            $.each(result, function (i, r) {
                $("#tblCliente > tbody ").append("<tr><td>" + r.ClienteId + "</td><td>" + r.Nombre + "</td><td>" + r.ApellidoPaterno + "</td><td>" + r.ApellidoMaterno + "</td><td>" + r.Telefono + "</td><td>" + r.Email + "</td><td><button onclick='Examen.BorrarCliente("+r.ClienteId+")' class='delBtn' >Eliminar</button></td></tr>");
            });
        },
        error: function (error) {
            alert("Error al obtener cliente..");
        }
    });
}

Examen.GuardarCliente = function (nombre, apellidoPaterno, apellidoMaterno, telefono, email) {
    var cliente = {};

    cliente.Nombre = nombre;
    cliente.ApellidoPaterno = apellidoPaterno;
    cliente.ApellidoMaterno = apellidoMaterno;
    cliente.Telefono = telefono;
    cliente.Email = email;

    $.ajax({
        type: 'POST',
        url: '../Home/GuardarCliente',
        async: true,
        contentType: 'application/json; charset=utf-8',
        dataType: "JSON",
        data:JSON.stringify(cliente),
        success: function (result) {
            alert("Cliente guardado correctamente..");
            Examen.ObtenerCliente();
            $('.form-horizontal').trigger("reset");
        },
        error: function (error) {
            alert("Error al guardar cliente..");
        }
    });
}

Examen.BorrarCliente = function (id){
    $.ajax({
        type: 'POST',
        url: '../Home/EliminarCliente',
        async: true,
        contentType: 'application/json; charset=utf-8',
        dataType: "JSON",
        data: JSON.stringify({ ClienteId: id }),
        success: function (result) {
            alert("Se ha eliminado el Cliente");
            Examen.ObtenerCliente();
        },
        error: function (error) {
            alert("Error al guardar cliente..");
        }
    });
}

Examen.Init = function () {
    Examen.CreaEventos();
    Examen.ObtenerCliente();
};