$(document).ready(function(){
    $('#loginInput').validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true
            }
        },
        messages: {
            email: {
                required: '¡Ingresar email!',
                email: '¡Ingresar email!'
            },
            password: {
                required: '¡Ingresar Password!'
            }
        },
        errorClass: "text-danger my-1"
    })

    $('#btnLogin').click(function() {
        if($('#loginInput').valid()){
            const email = $('#idEmail').val()
            const password = $('#idPassword').val()
            
            
            login(email, password)
        }
    })
})

function login(email, password) {
    fetch('https://localhost:44317/usuarios/login', {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    })
    .then(response => response.json())
    .then(data => {
        if(data.success) {
            const token = data.data.token
            localStorage.setItem("token", token)
            $(location).attr('href', 'http://127.0.0.1:5500/index.html')
        } else {
            Swal.fire({
                position: "top",
                icon: "error",
                title: "Usuario no registrado",
                showConfirmButton: false,
                timer: 1500
            });

            $('#idEmail').val('')
            $('#idPassword').val('')
        }   
    })
    .catch(error => {
        console.log('Error:', error)
    })
}


