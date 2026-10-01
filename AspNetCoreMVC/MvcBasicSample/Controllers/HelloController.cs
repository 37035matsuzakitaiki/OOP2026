using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;

namespace MvcBasicSample.Controllers; 

//URLのHelloに対応する要求を受け取るController    
public class HelloController :Controller{

    // ../Hello/IndexでよびだされるＡｃｔｉｏｎ
    public IActionResult Index() {
        var product = new List<Product>
        {
        new Product
         {
        //商品１件のオブジェクト
        Name = "ハンバーガー",
        Price = 500
    },
        new Product
    {
        //商品2件のオブジェクト
        Name = "紅茶",
        Price = 450
    },
        new Product
    {
        //商品2件のオブジェクト
        Name = "ONITYA",
        Price = 180
    },
        new Product
    {
        //商品2件のオブジェクト
        Name = "辛みそきん",
        Price = 350
    }
    };
        //Viewを使用せずHTTPとして応答する
        //return Content("はじめてのASP.NEET Core");
        return View(product);
    }
}

