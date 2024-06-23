$(document).ready(function() {
    $('#btnBuscar').click(function() {
        buscarAlumnoById()
    })

    $('#btnAgregar').click(function() {
        ingresarAlumnoEnCurso()
    })
    
})

function buscarAlumnoById() {
    const idCurso = GetParameters("id")
    const idAlumno = $('#idAlumno').val()
    const token = localStorage.getItem("token")
    const url = `https://localhost:44317/alumnoXcursos/GetAlumnoEnCurso/${idCurso}/${idAlumno}`

    fetch(url, {headers: {Authorization: `Bearer ${token}`}})
    .then(response => response.json())
    .then((response) => {
        if(!response.success){
            Swal.fire({
                icon: "error",
                title: "El alumno ya esta en este curso",
                showConfirmButton: false,
                timer: 1500
            });
        }else {
            $('#idName').val(response.data.name)
            $('#idLastName').val(response.data.lastName)
            $('#idFile').val(response.data.file)
        }   
    })
    .catch(error => console.log(error))
}

function ingresarAlumnoEnCurso() {
    const idCurso = GetParameters("id")
    const idAlumno = $('#idAlumno').val()
    const token = localStorage.getItem("token")
    const url = `https://localhost:44317/alumnosXcursos/Post`

    fetch(url, {
        method: 'POST',
        headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            curso: idCurso,
            alumno: idAlumno
        })
    })
    .then(response => response.json())
    .then(response => {
        if(response.success){
            Swal.fire({
                icon: "success",
                title: "Alumno Ingresado",
                showConfirmButton: false,
                timer: 2500
            });
        }
        else {
            alert("Error al consumir la api")
            alert(respuesta.errorMessage)
        }
    })
    .catch(error => {
        console.log('Error:', error)
    })

}