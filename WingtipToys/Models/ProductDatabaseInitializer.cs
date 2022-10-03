using System.Collections.Generic;
using System.Data.Entity;

namespace WingtipToys.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProdutoContexto>
    {
        protected override void Seed(ProdutoContexto context)
        {
            GetCategorias().ForEach(c => context.Categorias.Add(c));
            GetProdutos().ForEach(p => context.Produtos.Add(p));
        }

        private static List<Categoria> GetCategorias()
        {
            var categorias = new List<Categoria>{   
                new Categoria {
                    CategoriaID = 1,
                    CategoriaNome = "Carros"
                },
                new Categoria {
                    CategoriaID = 2,
                    CategoriaNome = "Aviões"
                },
                new Categoria{
                    CategoriaID = 3,
                    CategoriaNome = "Caminhões"
                },
                new Categoria{
                    CategoriaID = 4,
                    CategoriaNome = "Barcos"
                },
                new Categoria{
                    CategoriaID = 5,
                    CategoriaNome = "Foguetes"
                }
            };
            return categorias;
        }

        private static List<Produto> GetProdutos() 
        {
            var produtos = new List<Produto>{
            new Produto
            {
                ProdutoID = 1,
                ProdutoNome = "Carro conversível",
                Descricao = "Este carro conversível é rápido! O motor é alimentado por uma bateria baseada em neutrinos (não incluída)." +
                                   "Ligue-o e deixe-o ir!",
                ImagePath = "carconvert.png",
                Preco = 22.50,
                CategoriaID = 1
            },
            new Produto
            {
                ProdutoID = 2,
                ProdutoNome = "Carro das antigas",
                Descricao = "Não há nada antigo sobre esse carro, exceto seu visual. Compatível com outros carros de brinquedo.",
                ImagePath = "carearly.png",
                Preco = 15.95,
                CategoriaID = 1
            },
            new Produto
            {
                ProdutoID = 3,
                ProdutoNome = "Carro veloz",
                Descricao = "Sim, este carro é rápido, mas também flutua na água.",
                ImagePath = "carfast.png",
                Preco = 32.99,
                CategoriaID = 1
            },
            new Produto
            {
                ProdutoID = 4,
                ProdutoNome = "Carro super veloz",
                Descricao = "Use este carro super rápido para entreter os convidados. Luzes e portas funcionam!",
                ImagePath = "carfaster.png",
                Preco = 8.95,
                CategoriaID = 1
            },
            new Produto
            {
                ProdutoID = 5,
                ProdutoNome = "Carro vintage",
                Descricao = "This old style racer can fly (with user assistance). Gravity controls flight duration." + 
                                  "No batteries required.",
                ImagePath = "carracer.png",
                Preco = 34.95,
                CategoriaID = 1
            },
            new Produto
            {
                ProdutoID = 6,
                ProdutoNome = "Avião Ace",
                Descricao = "Brinquedo de avião autêntico. Apresenta cores e detalhes realistas.",
                ImagePath = "planeace.png",
                Preco = 95.00,
                CategoriaID = 2
            },
            new Produto
            {
                ProdutoID = 7,
                ProdutoNome = "Glider ",
                Descricao = "Este divertido planador é feito de madeira de balsa verdadeira. Alguma montagem necessária.",
                ImagePath = "planeglider.png",
                Preco = 4.95,
                CategoriaID = 2
            },
            new Produto
            {
                ProdutoID = 8,
                ProdutoNome = "Avião de papel",
                Descricao = "Este avião de papel é como nenhum outro avião de papel. Alguma dobragem necessária.",
                ImagePath = "planepaper.png",
                Preco = 2.95,
                CategoriaID = 2
            },
            new Produto
            {
                ProdutoID = 9,
                ProdutoNome = "Avião de hélice",
                Descricao = "O avião movido a elástico possui duas rodas.",
                ImagePath = "planeprop.png",
                Preco = 32.95,
                CategoriaID = 2,
            },
            new Produto
            {
                ProdutoID = 10,
                ProdutoNome = "Caminhão adiantado",
                Descricao = "Este caminhão de brinquedo tem um motor a gás real. Requer ajustes regulares.",
                ImagePath = "truckearly.png",
                Preco = 15.00,
                CategoriaID = 3
            },
            new Produto
            {
                ProdutoID = 11,
                ProdutoNome = "Caminhão dos bombeiros",
                Descricao = "Você vai se divertir sem fim com este caminhão de bombeiros de um quarto de tamanho.",
                ImagePath = "truckfire.png",
                Preco = 26.00,
                CategoriaID = 3
            },
            new Produto
            {
                ProdutoID = 12,
                ProdutoNome = "Caminhão grande",
                Descricao = "Este divertido caminhão de brinquedo pode ser usado para rebocar outros caminhões que não são tão grandes.",
                ImagePath = "truckbig.png",
                Preco = 29.00,
                CategoriaID = 3
            },
            new Produto
            {
                ProdutoID = 13,
                ProdutoNome = "Navio grande",
                Descricao = "É um barco ou um navio. Deixe este veículo flutuante decidir usando seu " +
                                   "cérebro de computador artificialmente inteligente!",
                ImagePath = "boatbig.png",
                Preco = 95.00,
                CategoriaID = 4
            },
            new Produto
            {
                ProdutoID = 14,
                ProdutoNome = "Barco de papel",
                Descricao = "Diversão flutuante para todos! Este barco de brinquedo pode ser montado em segundos. Flutua por minutos!" +
                                   "Requer algumas dobras.",
                ImagePath = "boatpaper.png",
                Preco = 4.95,
                CategoriaID = 4
            },
            new Produto
            {   
                   ProdutoID = 15,
                   ProdutoNome = "Barco de navegação",
                Descricao = "Coloque este divertido veleiro de brinquedo na água e solte-o!",
                ImagePath = "boatsail.png",
                Preco = 42.95,
                CategoriaID = 4
            },
            new Produto
            {
                ProdutoID = 16,
                ProdutoNome = "Foguete",
                Descricao = "Este divertido foguete viajará até uma altura de 200 pés.",
                ImagePath = "rocket.png",
                Preco = 122.95,
                CategoriaID = 5
            }
        };
            return produtos;
        }
    }
}