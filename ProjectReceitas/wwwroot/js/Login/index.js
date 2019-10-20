if (typeof Receita === 'undefined') { Receita = new Object(); }

Receita.Login = {
    inicializar: function () {
        $('#btnEntrar').on("click", function () {
            Receita.Login.logar();
        });
    },
    logar: function () {

        var user = $("#txtNome").val();
        var password = $("#txtSenha").val();

        var _data = {
            "User": user,
            "Password": password
        };

        var _url = 'http://localhost:53749/api/Login/SignIn';
        postData(_url, _data, function (result) {
            var retorno = result;
            if (retorno !== null) {
                localStorage.setItem("jwtToken", retorno);
            }
        }, false, function (err) {
            var e = JSON.parse(err.responseText);
           $.toast(e.message);
        });
    },
};
$(document).ready(Receita.Login.inicializar());