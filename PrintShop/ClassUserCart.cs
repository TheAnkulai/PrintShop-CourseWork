using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrintShop
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public decimal pricePerEach { get; set; }
        public string character { get; set; }
    }
    public class AdditionalProduct
    {
        public int additionalProductId { get; set; }
        public string additionalProductName { get; set; }
        public decimal additionalProductPrice { get; set; }

    }
    public class Material
    {
        public int materialId { get; set; }
        public string materialName { get; set; }
        public decimal materialPrice { get; set; }

    }
    public class CartItem
    {
        public Product Product { get; set; }
        public int quantity { get; set; }
        public int colorId { get; set; }
        public string colorName { get; set; }
        public AdditionalProduct AdditionalProduct { get; set; }
        public Material Material { get; set; }


        public decimal TotalPrice => quantity * (Product.pricePerEach + AdditionalProduct.additionalProductPrice + Material.materialPrice);
    }

    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public List<CartItem> Items => items;

        public void AddItem(Product product, int quantity, int colorId, string colorName, AdditionalProduct additionalProduct, Material material)
        {
            items.Add(new CartItem
            { 
                Product = product,
                quantity = quantity,
                colorId = colorId,
                colorName = colorName,
                AdditionalProduct = additionalProduct,
                Material = material
            });
        }

        public void RemoveItem(int index)
        {
            items.RemoveAt(index);
        }

        public decimal GetTotal()
        {
            return items.Sum(i => i.TotalPrice);
        }

        public void RefreshCart(DataGridView dgv, Cart cart)
        {
            dgv.Rows.Clear();
            foreach (var item in cart.Items)
            {
                dgv.Rows.Add(
                    item.Product.productName,
                    item.Material.materialName,
                    item.AdditionalProduct.additionalProductName,
                    item.colorName,
                    item.quantity,
                    item.TotalPrice
                );
            }
        }
    }

}
