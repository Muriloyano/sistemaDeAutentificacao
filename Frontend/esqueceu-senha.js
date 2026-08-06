window.onload = function (e){

    var btnEsqueceu = document.getElementById("btnEsqueceu");
    
    var txtemail = document.getElementById("txtemail");
    txtemail.focus();

    btnEsqueceu.onclick = function(e){

        e.preventDefault();
        
        var email = txtemail.value;

        if (email == ""){
            mensagemerro("E-mail Obrigatorio.");
        }
        else {
            recuperarsenha(email);
        }
    };

    function mensagemerro(mensagem){
        var spnErro = document.getElementById("spnErro");

        spnErro.innerText = mensagem;

        spnErro.style.display = "block";

        setTimeout(function() {
            spnErro.style.display = "none";
        }, 5000);
    };

    function recuperarsenha(email){
        var data = JSON.stringify({
            "Email": email
          });
          
          var xhr = new XMLHttpRequest();
          xhr.withCredentials = true;
          
          xhr.addEventListener("readystatechange", function() {
            if(this.readyState === 4) {
                var esqueceuSenhaResult = JSON.parse(this.responseText);

                if (esqueceuSenhaResult.suceso){
                    alert("Verifique seu E-mail para recuperar sua senha.")
                }
                else {
                    mensagemerro(esqueceuSenhaResult.mensagem);
                }
            }
          });
          
          xhr.open("POST", "http://localhost:5167/api/usuario/esqueceuSenha");
          xhr.setRequestHeader("Content-Type", "application/json");
          
          xhr.send(data);
    }
}