if (typeof Receita === 'undefined') { Receita = new Object(); }

Receita.Login = {
    inicializar: function () {
        $('#btnEntrar').on("click", function () {
            Receita.Login.logar();
        });
    },
    logar: function () {

        var user = $("#txtEmail").val();
        var password = $("#txtSenha").val();

        var _data = {
            "User": user,
            "Password": password
        };

        var _url = 'http://localhost:53749/api/SignIn';
        postData(_url, _data, function (result) {
            var retorno = result;
            if (retorno !== null) {
                localStorage.setItem("jwtToken", retorno.token);
            }
        });
    },
};
$(document).ready(Receita.Login.inicializar());