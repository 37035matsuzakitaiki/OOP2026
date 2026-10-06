using System.ComponentModel.DataAnnotations;
namespace MvcBasicSample.Models;
//Productsテーブルの１行に対応する商品
    public class Product {
        public int Id { get; set; }//主キー
        
        [Required]//必須項目
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }//円単位の価格
    }
