using CarReportSystem;
using Microsoft.Data.Sqlite;
using System.Drawing.Imaging;
using System.Globalization;

namespace SQLiteProductSample;

// Productsテーブルに対するDB操作をまとめたクラス
// CRUD（Create / Read / Update / Delete）を担当する
public class CarReportRepository
{
    // 全商品を取得する。Read（SELECT）に相当する
    public List<CarReport> GetAll() {

        var carReports = new List<CarReport>();

        using var connection = Database.GetConnection();
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        // Productsテーブルを作るSQL
        command.CommandText =
            """
            SELECT Id, Date, Author, Maker, CarName, Report, Picture
            FROM CarReports
            ORDER BY Id;
            """;

        // SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()) {
            carReports.Add(new CarReport {
                Id = reader.GetInt32(0),    // 0列目: Id
                Date = DateTime.ParseExact(reader.GetString(1),
                "yyyy-MM-dd",CultureInfo.InvariantCulture), // 1列目: Name
                Author = reader.GetString(2),  // 2列目: Price
                Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                CarName = reader.GetString(4),
                Report = reader.GetString(5),
                //Picture = Image.FromStream(command)
            });
        }
        return carReports;

    }

    //商品を1件追加する。Create(INSERT)
    //戻り値として自動裁判されたIｄをかえす
    public int Add(string name,int price) {
        // 接続オブジェクトを生成する。
        using var connection = Database.GetConnection();

        //DBを開く
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        // Productsテーブルを作るSQL
        // IF NOT EXISTS により、既にテーブルがあってもエラーにならない
        command.CommandText =
            """
            INSERT INTO CarReports
            (Date,Author,Maker,CarName,Report,Picture)
            VALUES 
            ($date,$author,$maker,$carName,$report,$picture);
            SELECT last_insert_rowid();
            );
            """;

        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue($"price", price);

        //一つの値を返すSQLを実行する
      var result = command.ExecuteScalar();

        if (result is null) {
            throw new InvalidOperationException("登録した商品のＩＤを取得できませんでした。");
        }
        //SQLiteのINTEGERはlongとして帰るため、intへ変換する
        return Convert.ToInt32((long)result);



    }
    public void Update(CarReport carReport) {
        // 接続オブジェクトを生成する。
        using var connection = Database.GetConnection();
        connection.Open();
        using var command = connection.CreateCommand();

        command.CommandText =
            """
            UPDATE Products
            SET Name = $name,
                Price = $price
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$name", carReport.Id);
        command.Parameters.AddWithValue($"price", carReport.Date);
        command.Parameters.AddWithValue($"id", carReport.Author);

        command.ExecuteNonQuery();

        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("修正対象の商品が見つかりませんでした。");
    }



    public void Delete(int id) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            """
            DELETE FROM Products
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    // ImageをSQLiteへ保存できるbyte[]へ変換する
    private static byte[]? ImageToBytes(Image? image) {
        if (image is null) return null;

        using var stream = new MemoryStream();
        // DBへはPNG形式で保存
        image.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }

    // SQLiteのBLOB（byte[]）をImageへ変換する
    private static Image BytesToImage(byte[] data) {
        using var stream = new MemoryStream(data);
        using var image = Image.FromStream(stream);
        // MemoryStream破棄後も利用できるようBitmapとしてコピーする。
        return new Bitmap(image);
    }

}
