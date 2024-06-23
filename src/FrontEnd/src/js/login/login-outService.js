$('#idLoginOut').click(function() {
    localStorage.removeItem("token")
    $(location).attr('href', 'http://127.0.0.1:5500/login.html')
})