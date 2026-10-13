window.onload = function(e){
    var btnCadastrar = document.getElementById("btnCadastrar");

    var txtnome = document.getElementById("txtnome");
    var txtemail = document.getElementById("txtemail");
    var txtsobrenome = document.getElementById("txtsobrenome");
    var txttelefone = document.getElementById("txttelefone");
    var slcgenero = document.getElementById("slcgenero");
    var txtsenha = document.getElementById("txtsenha");
    
    var spnErro = document.getElementById("spnErro");

    txtnome.focus();

    btnCadastrar.onclick = function(e){
        e.preventDefault();

        var nome = txtnome.value;
        var email = txtemail.value;
        var sobrenome = txtsobrenome.value;
        var telefone = txttelefone.value;
        var genero = slcgenero.value;
        var senha = txtsenha.value;

        if (nome == ""){
            mensagemerro("O campo 'Nome' é obrigatório", txtnome);
        }
        else if(email == ""){
            mensagemerro("O campo 'E-mail' é obrigatório", txtemail);
        }
        else if(sobrenome == ""){
            mensagemerro("O campo 'Sobrenome' é obrigatório", txtsobrenome);
        }
        else if(genero == ""){
            mensagemerro("O campo 'Gênero' é obrigatório", slcgenero);
        }
        else if(senha == ""){
            mensagemerro("O campo 'Senha' é obrigatório", txtsenha);
        }
        else if(telefone == ""){
            mensagemerro("O campo 'Telefone' é obrigatório", txttelefone);
        }
        else {
            cadastrar(nome, email, sobrenome, telefone, genero, senha);
        }
    };

    function mensagemerro(mensagem, campoFocar){
        
        if (!spnErro) {
            console.error("Atenção: Elemento com id 'spnErro' não foi encontrado no HTML.");
            alert(mensagem); 
            return;
        }

        spnErro.innerText = mensagem;
        spnErro.style.display = "block";

        if (campoFocar) {
            campoFocar.focus();
        }

        setTimeout(function(){
            spnErro.style.display = "none";
        }, 5000);
    }

    function cadastrar(nome, email, sobrenome, telefone, genero, senha){
        
        var data = JSON.stringify({
            "nome": nome,
            "sobrenome": sobrenome,
            "email": email,
            "telefone": telefone,
            "genero": genero,
            "senha": senha
          });
          
          var xhr = new XMLHttpRequest();
          xhr.withCredentials = true;
          
          xhr.addEventListener("readystatechange", function() {
            if(this.readyState === 4) {

                console.log("Resposta crua do servidor:", this.responseText);
                try {
                    var result = JSON.parse(this.responseText);

                    if (result.sucesso){
                        localStorage.setItem("usuarioGuid", result.usuarioGuid);
                        window.location.href = "home.html";
                    }
                    else {
                        mensagemerro(result.mensagem || "Ocorreu um erro desconhecido.");
                    }
                } catch (err) {
                    console.error("Falha ao analisar JSON:", err);
                    mensagemerro("Não foi possível processar a resposta do servidor. Tente novamente.");
                }
            }
          });
          
          xhr.open("POST", "http://localhost:5167/api/usuario/cadastro");
          xhr.setRequestHeader("Content-Type", "application/json");
          
          xhr.send(data);
    }
}