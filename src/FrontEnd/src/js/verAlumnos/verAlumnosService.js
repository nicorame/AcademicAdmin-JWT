$(document).ready(function() {
    listarCursoById()
})

function listarCursoById() {
    var idCurso = GetParameters("id")
    console.log(idCurso)
    const url = `https://localhost:44317/alumnosXcursos/GetAlumnosPorCurso/${idCurso}`
    const token = localStorage.getItem("token")

    fetch(url, {headers: {Authorization: `Bearer ${token}`}})
    .then(response => response.json())
    .then((response) => {
        const body = document.querySelector("tbody")
        
        response.data.alumnos.forEach(alumno => {       
            const fila = document.createElement("tr")

            fila.innerHTML += `<td>${alumno.name}</td>`;
            fila.innerHTML += `<td>${alumno.lastName}</td>`;
            fila.innerHTML += `<td>${alumno.file}</td>`;
            fila.innerHTML += ` <td>    
                                    <button type="button" class="btn btn-danger m-2">Eliminar</button>
                                </td>`;

            body.append(fila)
        });

    })
    .catch(error => console.log(error))
}

function GetParameters(param){
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1)
.split('&')

for(var i = 0; i< url.length; i++){
    var urlParam = url[i].split('=')
    if(urlParam[0] == param){
        return urlParam[1]
    }
}
}
