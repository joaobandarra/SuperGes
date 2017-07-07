namespace SuperGes.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperGes.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SuperGes.Models.ApplicationDbContext context)
        {
            
            // Configuration --- SEED
            //=============================================================

            // ############################################################################################
            // adiciona CLIENTES
            var clientes = new List<Cliente> {
               new Cliente  {IDCliente=1, Nome = "Luís Gomes Freitas",Morada="Rua Srapitolas Nº30",Email="luisgomes_852@teste.com", InfoCartaoCredito="" , NIF ="813635582" },
               new Cliente  {IDCliente=2, Nome = "Ana Silva Rodrigues",Morada="Rua dos Exploradores Nº2",Email="ana.rodrigues_19@teste.com", InfoCartaoCredito="" , NIF ="885423159" },
               new Cliente  {IDCliente=3, Nome = "Mónica Isabel Estevão",Morada="Avenida dos Dentes Armados Lt 34 Rc/F",Email="monika_bot2foolya@teste.com", InfoCartaoCredito="" , NIF ="813685982" },
               new Cliente  {IDCliente=4, Nome = "Gabriel Rafael Silvério",Morada="Urbanização dos Ciclistas C6  1º Esq",Email="garafunola_852@teste.com", InfoCartaoCredito="" , NIF ="811342154" }
            };

            clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.IDCliente, cc));
            context.SaveChanges();
            
            
            // ############################################################################################
            // adiciona PRODUTOS
            var produtos = new List<Produto> {
               new Produto  {IDProduto=1, Nome = "Asas de Peru kg Lusiaves", Descricao="Carne Fresca, Origem Portugal", Categoria ="Talho", Preco=5.00 , IVA=0.06, Fotografia="/Imagens/Produtos/Asas_peru.jpg", Peso=1000, Stock=35},
               new Produto  {IDProduto=2, Nome = "Peluche Rato Mickey", Descricao="Peluche de 60Cm", Categoria ="Brinquedos", Preco=21.95 , IVA=0.23, Fotografia="/Imagens/Produtos/Rato_mickey.jpg",Peso=500, Stock=60 },
               new Produto  {IDProduto=3, Nome = "Dark souls", Descricao="Jogo Playstation 3", Categoria ="Jogos de Vídeo", Preco=59.99, IVA=0.23, Fotografia="/Imagens/Produtos/Dark_Souls.jpg", Peso=100, Stock=50},
               new Produto  {IDProduto=4, Nome = "Demons souls", Descricao="Jogo Playstation 3", Categoria ="Jogos de Vídeo", Preco=65.99, IVA=0.23, Fotografia="/Imagens/Produtos/Demons_Souls.jpg", Peso=100, Stock=50},
               new Produto  {IDProduto=5, Nome = "Salmão Lombo kg", Descricao="Peixe Fresco, Origem Canadá", Categoria ="Peixaria", Preco=11.99, IVA=0.12, Fotografia="/Imagens/Produtos/Salmao.jgp", Peso=1000, Stock=50},
               new Produto  {IDProduto=6, Nome = "Brócolos kg", Descricao="Origem Portugal", Categoria ="Legumes", Preco=1.29, IVA=0.12, Fotografia="/Imagens/Produtos/Brocolos.jgp", Peso=1000, Stock=70},
               new Produto  {IDProduto=7, Nome = "Physalis kg", Descricao="Origem Colômbia", Categoria ="Fruta", Preco=11.99, IVA=0.12, Fotografia="/Imagens/Produtos/Physalis.jgp", Peso=1000, Stock=10},
               new Produto  {IDProduto=8, Nome = "Feijão Preto ", Descricao="Origem Portugal", Categoria ="Feijão e Grão", Preco=0.89, IVA=0.12, Fotografia="/Imagens/Produtos/Feijao_Preto.jgp", Peso=500, Stock=100},
               new Produto  {IDProduto=9, Nome = "Atum Tenório", Descricao="Atum de conserva em Óleo", Categoria ="Conservas", Preco=1.39, IVA=0.12, Fotografia="/Imagens/Produtos/Atum.jgp", Peso=120, Stock=300},
               new Produto  {IDProduto=10, Nome = "Pringles Hot Spicy", Descricao="Snack de Batata", Categoria ="Snack", Preco=2.25, IVA=0.12, Fotografia="/Imagens/Produtos/Pringles.jgp", Peso=190, Stock=90},
               new Produto  {IDProduto=11, Nome = "Nestum arroz", Descricao="Sem Gluten", Categoria ="Cereais", Preco=1.78, IVA=0.12, Fotografia="/Imagens/Produtos/Nestum.png", Peso=300, Stock=40},
               new Produto  {IDProduto=12, Nome = "Pensal", Descricao="Farinha com Cacau", Categoria ="Cereais", Preco=1.29, IVA=0.12, Fotografia="/Imagens/Produtos/PEnsal.png", Peso=300, Stock=35},
               new Produto  {IDProduto=13, Nome = "Mimosa", Descricao="Leite Meio Gordo", Categoria ="Leite", Preco=0.64, IVA=0.12, Fotografia="/Imagens/Produtos/Mimosa.jgp", Peso=1000, Stock=500},
               new Produto  {IDProduto=14, Nome = "Gresso", Descricao="Leite Meio Gordo", Categoria ="Leite", Preco=0.52, IVA=0.12, Fotografia="/Imagens/Produtos/Gresso.png", Peso=1000, Stock=500}
            };

            produtos.ForEach(cc => context.Produtos.AddOrUpdate(c => c.IDProduto, cc));
            context.SaveChanges();

            
            // ############################################################################################
            // adiciona ENCOMENDAS
            var encomendas = new List<Encomenda> {
               new Encomenda  {IDEncomenda=1, DataCriacaoEncomenda = new DateTime(2015,2,8), DataEnvioEncomenda = new DateTime(2015,2,8), EstadoCompra="Concluido", CustoEnvio=3.99, MoradaFaturacao="Rua Srapitolas Nº30", CodPostalFaturacao="2200-799 Abrantes", MoradaEntrega="Rua Srapitolas Nº30", CodigoPostalEntrega="2200-799 Abrantes" },
               new Encomenda  {IDEncomenda=2, DataCriacaoEncomenda = new DateTime(2015,2,8), DataEnvioEncomenda = new DateTime(2015,2,9), EstadoCompra="Concluido", CustoEnvio=3.99, MoradaFaturacao="Rua dos Exploradores Nº2", CodPostalFaturacao="2300-023 Tomar", MoradaEntrega="Rua dos Exploradores Nº2", CodigoPostalEntrega="2300-023 Tomar"},
               new Encomenda  {IDEncomenda=3, DataCriacaoEncomenda = new DateTime(2015,2,10), DataEnvioEncomenda = new DateTime(2015,2,11), EstadoCompra="Concluido", CustoEnvio=3.99, MoradaFaturacao="Avenida dos Dentes Armados Lt 34 Rc/F", CodPostalFaturacao="2005-090 Santarem", MoradaEntrega="Avenida dos Dentes Armados Lt 34 Rc/F", CodigoPostalEntrega="2005-090 Santarem"},
               new Encomenda  {IDEncomenda=4, DataCriacaoEncomenda = new DateTime(2015,2,11), DataEnvioEncomenda = new DateTime(2015,2,11), EstadoCompra="Concluido", CustoEnvio=3.99, MoradaFaturacao="Urbanização dos Ciclistas C6  1º Esq", CodPostalFaturacao="4100-195 Porto", MoradaEntrega="Urbanização dos Ciclistas C6  1º Esq", CodigoPostalEntrega="4100-195 Porto" }

            };

            encomendas.ForEach(cc => context.Encomendas.AddOrUpdate(c => c.IDEncomenda, cc));
            context.SaveChanges();//commit


            
            // ############################################################################################
            // adiciona TIPOSENVIO
            var tiposenvio = new List<TiposEnvio> {
               new TiposEnvio  {ID = 1, TipoEnvio="cobrança"},
               new TiposEnvio  {ID = 2, TipoEnvio="correio normal"},
               new TiposEnvio  {ID = 3, TipoEnvio="correio azul"},
               new TiposEnvio  {ID = 4, TipoEnvio="correio registado"},
               new TiposEnvio  {ID = 5, TipoEnvio="correio expresso"}

            };

            tiposenvio.ForEach(cc => context.TiposEnvio.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();

            // ############################################################################################
            // adiciona REGIAOENVIO
            var regiaoenvio = new List<RegiaoEnvio> {
               new RegiaoEnvio  {IDRegiaoEnvio = 1, NomeRegiao="Santarem"},
               new RegiaoEnvio  {IDRegiaoEnvio = 2, NomeRegiao="Porto"}


            };

            regiaoenvio.ForEach(cc => context.RegiaoEnvio.AddOrUpdate(c => c.IDRegiaoEnvio, cc));
            context.SaveChanges();


            
            // ############################################################################################
            // adiciona CARRINHOCOMPRAS
            var carrinhocompras = new List<CarrinhoCompras> {
               new CarrinhoCompras  {IDCarrinhoCompras = 1, DataAdicaoProduto = new DateTime(2015,2,2)},
               new CarrinhoCompras  {IDCarrinhoCompras = 2, DataAdicaoProduto = new DateTime(2015,2,2)}


            };

            carrinhocompras.ForEach(cc => context.CarrinhoCompras.AddOrUpdate(c => c.IDCarrinhoCompras, cc));
            context.SaveChanges();



            
            // ############################################################################################
            // adiciona CARRINHOCOMPRASPRODUTOS
            var carrinhocomprasprodutos = new List<CarrinhoComprasProdutos> {
               new CarrinhoComprasProdutos  {IDcomprasProduto = 1, NomeProduto = "Saca Rolhas", Quantidade = 2, Preco = 5.00, IVA =0.23},
               new CarrinhoComprasProdutos {IDcomprasProduto = 2, NomeProduto = "Saca Rolhas", Quantidade = 2, Preco = 5.00, IVA =0.23}


            };

            carrinhocomprasprodutos.ForEach(cc => context.CarrinhoComprasProdutos.AddOrUpdate(c => c.IDcomprasProduto, cc));
            context.SaveChanges();



            
            // ############################################################################################
            // adiciona ENCOMENDAPRODUTO
            var encomendaproduto = new List<EncomendaProduto> {
               new EncomendaProduto { IDEncomendaProduto = 1, NomeProduto="Saca rolhas", Quantidade=1, Preco=5.00,IVA=0.23},
               new EncomendaProduto { IDEncomendaProduto = 2, NomeProduto="Rato Mickey", Quantidade=1, Preco=20.99,IVA=0.23},
               new EncomendaProduto { IDEncomendaProduto = 3, NomeProduto="Dark souls", Quantidade=1, Preco=59.99,IVA=0.23},
               new EncomendaProduto { IDEncomendaProduto = 4, NomeProduto="Demon souls", Quantidade=1, Preco=65.99,IVA=0.23}


            };

            encomendaproduto.ForEach(cc => context.EncomendaProdutos.AddOrUpdate(c => c.IDEncomendaProduto, cc));
            context.SaveChanges();
        }
    }
}
