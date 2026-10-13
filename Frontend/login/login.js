window.onload = function(e){

    var btnEntrar = document.getElementById("btnEntrar");

    var txtemail = document.getElementById("txtemail");
    txtemail.focus();

    var txtsenha = document.getElementById("txtsenha");

    btnEntrar.onclick = function(e){

        e.preventDefault();

        var email = txtemail.value;

        var senha = txtsenha.value;

        if (email == ""){
            mensagemErro("Campo Obrigatorio")
        }
        else if (senha == ""){
            mensagemErro("Campo Obrigatorio")
        }
        else {
            realizarLogin(email, senha);
        }
    };

    function mensagemErro(mensagem){
        var spnErro = document.getElementById("spnErro");

        spnErro.innerText = mensagem;

        spnErro.style.display = "block";

        setTimeout(function() {
            spnErro.style.display = "none";
        }, 5000);
    }

    function realizarLogin(email, senha){

        var data = JSON.stringify({
            "email": email,
            "senha": senha,
          });
          
          var xhr = new XMLHttpRequest();
          xhr.withCredentials = true;
          
          xhr.addEventListener("readystatechange", function() {
            if(this.readyState === 4) {
                var loginresult = JSON.parse(this.responseText);

                if (loginresult.sucesso){
                    localStorage.setItem("usuarioGuid", loginresult.usuarioGuid);
                    window.location.href = "home.html";
                }
                else{
                    mensagemErro(loginresult.mensagem);
                }
            }
          });
          
          xhr.open("POST", "http://localhost:5167/api/usuario/login");
          xhr.setRequestHeader("Content-Type", "application/json");
          
          xhr.send(data);
    }
}