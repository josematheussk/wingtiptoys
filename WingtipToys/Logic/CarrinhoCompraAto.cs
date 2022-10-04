using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
    public class CarrinhoCompraAto : IDisposable
    {
        public string CarrinhoCompraId { get; set; }
        private ProdutoContexto _db = new ProdutoContexto();
        public const string CarrinhoSessionKey = "CarrinhoId";

        public void AddToCarrinho(int id)
        {
            CarrinhoCompraId = GetCarrinhoId();

            var carrinhoItem = _db.ItemCarrinhoCompras.SingleOrDefault(
                c => c.CarrinhoId == CarrinhoCompraId
                && c.ProdutoId == id);
            if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProdutoId = id,
                    CarrinhoId = CarrinhoCompraId,
                    Produto = _db.Produtos.SingleOrDefault(
                        p => p.ProdutoID == id),
                    Quantidade = 1,
                    DataCriado = DateTime.Now
                };

                _db.ItemCarrinhoCompras.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCarrinhoId()
        {
            if (HttpContext.Current.Session[CarrinhoSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CarrinhoSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCarrinhoId = Guid.NewGuid();
                    HttpContext.Current.Session[CarrinhoSessionKey] = tempCarrinhoId.ToString();
                }
            }
            return HttpContext.Current.Session[CarrinhoSessionKey].ToString();
        }

        public List<CarrinhoItem> GetCarrinhoContent()
        {
            CarrinhoCompraId = GetCarrinhoId();

            return _db.ItemCarrinhoCompras.Where(
                c => c.CarrinhoId == CarrinhoCompraId).ToList();
        }

        public decimal GetTotal()
        {
            CarrinhoCompraId = GetCarrinhoId();
            decimal? total = decimal.Zero;
            total = (decimal?)(from carrinhoItens in _db.ItemCarrinhoCompras
                               where carrinhoItens.CarrinhoId == CarrinhoCompraId
                               select (int?)carrinhoItens.Quantidade *
                               carrinhoItens.Produto.Preco).Sum();
            return total ?? decimal.Zero;
        }



        public CarrinhoCompraAto GetCart(HttpContext context)
        {
            using (var cart = new CarrinhoCompraAto())
            {
                cart.CarrinhoCompraId = cart.GetCarrinhoId();
                return cart;
            }
        }

        public void AttCarrinhoDB(String carrinhoId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new WingtipToys.Models.ProdutoContexto())   
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CarrinhoItem> myCart = GetCarrinhoContent();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Produto.ProdutoID == CartItemUpdates[i].ProdutoId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(carrinhoId, cartItem.ProdutoId);
                                }
                                else
                                {
                                    UpdateItem(carrinhoId, cartItem.ProdutoId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new WingtipToys.Models.ProdutoContexto())
            {
                try
                {
                    var myItem = (from c in _db.ItemCarrinhoCompras where c.CarrinhoId== removeCartID && c.Produto.ProdutoID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.ItemCarrinhoCompras.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            using (var _db = new WingtipToys.Models.ProdutoContexto())
            {
                try
                {
                    var myItem = (from c in _db.ItemCarrinhoCompras where c.CarrinhoId == updateCartID && c.Produto.ProdutoID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantidade = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            CarrinhoCompraId = GetCarrinhoId();
            var cartItems = _db.ItemCarrinhoCompras.Where(
                c => c.CarrinhoId == CarrinhoCompraId);
            foreach (var cartItem in cartItems)
            {
                _db.ItemCarrinhoCompras.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            CarrinhoCompraId = GetCarrinhoId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.ItemCarrinhoCompras
                          where cartItems.CarrinhoId == CarrinhoCompraId
                          select (int?)cartItems.Quantidade).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProdutoId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

    }
}
