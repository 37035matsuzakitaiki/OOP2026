using Microsoft.AspNetCore.Mvc;         // MVCの機能を使用 
using Microsoft.EntityFrameworkCore;    // ToListAsyncを使用 
using MvcBasicSample.Data;              // AppDbContextを使用

namespace MvcBasicSample.Controllers;

public class ProductsController {
    private readonly AppDbContext _db;  // DBへ問い合わせるためのフィールド

    public ProductsController(AppDbContext db) {
        _db = db;                       // 受け取ったAppDbContextをフィールドに保存 
    }
}

