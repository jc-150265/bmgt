using System;
using System.Collections.Generic;
using SQLite;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206
//SQLメソッドの参考url https://www.tmp1024.com/programming/use-sqlite

namespace SamplePage
{
    /*
    //テーブル名を指定
    [Table("User")]
    public class UserModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey, AutoIncrement, Column("_id")]
        //idカラム
        public int Id { get; set; }
        //名前カラム
        public string Name { get; set; }

        public int id;

        //Userテーブルに行追加するメソッドです
            //------------------------Insert文的なの--------------------------
        public static void insertUser(string name)
        {
            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {

                    
                    //データベースにUserテーブルを作成します
                    db.CreateTable<UserModel>();
                    
                    //Userテーブルに行追加します
                    db.Insert(new UserModel() { Name = name });

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }
        
        //id name オーバーロード
        public static void insertUser(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel() { Id = id , Name = name  });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
        

        //Userテーブルのuserを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void deleteUser(int id)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<UserModel>();
                    db.DropTable<UserModel>();

                    db.Delete(id);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }


        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] desc limit 15");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

    }
    */

    //テーブル名を指定
    [Table("Book")]
    public class UserModel
    {
        //プライマリキー
        [PrimaryKey]
        //ISBN列 主キー
        public string ISBN { get; set; }

        //タイトル列
        public string Title { get; set; }

        //タイトルカナ列
        public string TitleKana { get; set; }

        //サブタイトル列
        public string SubTitle { get; set; }

        //サブタイトルカナ列
        public string SubTitleKana { get; set; }

        //著者列
        public string Author { get; set; }

        //著者カナ列
        public string AuthorKana { get; set; }

        //出版社列
        public string Publisher { get; set; }

        //種類列(コミック、文庫、etc..)
        public string Type { get; set; }

        //アイテム説明列
        public string ItemCaption { get; set; }

        //発売日列
        public string SalesDate { get; set; }

        //登録日列
        public DateTime Date { get; set; }

        //金額列
        public int Price { get; set; }

        //ImageUrl
        public string largeImageUrl { get; set; }

        //GenreId列
        public string booksGenreId { get; set; }
        //------------------------Insert文的なの--------------------------

        //id name オーバーロード
        public static void insertUser(string isbn, string title, string titleKana, string subTitle, string subTitleKana,
            string author, string authorKana, string publisher, string type, string itemCaption,
            string salesDate, int price, string image, string genreId)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにBookテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel()
                    {
                        ISBN = isbn,
                        Title = title,
                        TitleKana = titleKana,
                        SubTitle = subTitle,
                        SubTitleKana = subTitleKana,
                        Author = author,
                        AuthorKana = authorKana,
                        Publisher = publisher,
                        Type = type,
                        ItemCaption = itemCaption,
                        SalesDate = salesDate,
                        Date = DateTime.Now,
                        Price = price,
                        largeImageUrl = image,
                        booksGenreId = genreId
                    });

                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        //Userテーブルのuserを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void dropUser()
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {                                               
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<UserModel>();
                    db.DropTable<UserModel>();

                   // db.Delete(id);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }


        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [Book] order by [_id] desc limit 15");
                    return db.Query<UserModel>("SELECT * FROM [Book]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
        
       public static List<UserModel> isbnSelect(string isbn)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    return db.Query<UserModel>("SELECT * FROM[Book] where [ISBN] =" + isbn);
                }catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> sortDesc(string Foo)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [Book] order by [_id] desc limit 15");
                    return db.Query<UserModel>("SELECT * FROM [Book] order by" + Foo + "desc");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> sortAsc(string Fooo)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [Book] order by [_id] desc limit 15");
                    return db.Query<UserModel>("SELECT * FROM [Book] order by" + Fooo);

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

    }
}
