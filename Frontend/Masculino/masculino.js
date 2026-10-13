const produtosMasculinos = [
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
    {
        nome: "Camiseta Manga Curta",
        preco: "R$ 109,99",
        imagem: ""
    },
]

const containerGrid = document.getElementById("grid-masculino");

function carregarProdutos() {
    produtosMasculinos.forEach(produto => {
        const cardHTML = `
            <div class="card-produto">
                <div class="imagem-produto">
                    <img src="${produto.imagem}">
                </div>
                <div class="info-profuto">
                    <h3>${produto.nome}</h3>
                    <p class="preco">${produto.preco}</p>
                    <button class="btn-comprar">Adicionar ao Carrinho</button>
                </div>
            </div>
        `;

        containerGrid.innerHTML += cardHTML;
    })
}

carregarProdutos();