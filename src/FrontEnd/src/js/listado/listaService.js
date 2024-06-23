$(document).ready(function() {
    listarCursos();
})

const url1 = 'https://localhost:44317/alumnosXcursos/GetAll'
const url2 = 'https://localhost:44317/docenteXcurso/GetAll'
const token = localStorage.getItem("token")


function listarCursos() {
    const request1 = fetch(url1, {headers: {Authorization: `Bearer ${token}`}}).then(response => response.json())
    const request2 = fetch(url2, {headers: {Authorization: `Bearer ${token}`}}).then(response => response.json())
    
    Promise.all([request1, request2])
        .then(([data1, data2]) => {
            console.log('Datos de la primera solicitud:', data1);
            console.log('Datos de la segunda solicitud:', data2);
            
            const body = document.querySelector("tbody")
            
            data1.data.forEach(curso => {
                let cantidadAlumnos = curso.alumnos.length
                let idCurso = curso.id
                let cursoDocente = data2.data.find(c => c.name === curso.name);
                let nombreDocente = cursoDocente && cursoDocente.docentes.length > 0 ? cursoDocente.docentes[0].name + ' ' + cursoDocente.docentes[0].lastName : 'Sin docente';
                
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${curso.name}</td>`
                fila.innerHTML += `<td>${cantidadAlumnos}</td>`
                fila.innerHTML += `<td>${nombreDocente}</td>`;
                fila.innerHTML += ` <td>    
                                        <a type="button" class="btn btn-warning m-2" href="verAlumnos.html?id=${idCurso}">Ver Alumnos</a>
                                        <a type="button" class="btn btn-success m-2" href="agregar.html">Agregar</a>
                                    </td>`
                body.append(fila)
            });
        })
        .catch(error => {
            console.error('Error al realizar las solicitudes:', error);
        });
}
