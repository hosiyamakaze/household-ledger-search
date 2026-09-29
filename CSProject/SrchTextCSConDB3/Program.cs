using System;
using System.Configuration;
using System.Data.SQLite;

namespace SrchTextCSConDB3
{
    class Program
    {
        static void Main(string[] args)
        {
            string srchText;
            SQLiteConnection DB3con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

var sql = @"
SELECT DISTINCT 大分類 ,中分類 , 小分類 , 項目
FROM 支出
WHERE ((小分類 Like @keyword) OR (項目 Like @keyword))
ORDER BY 大分類 ,中分類 , 小分類 , 項目
";


            DB3con.Open();
            while (true)
            {
                Console.Write("検索文字列(Enter:終了)=");
                srchText = Console.ReadLine();

                if (srchText.Length == 0) break;

                var DB3cmd = new SQLiteCommand(sql, DB3con);
                DB3cmd.Parameters.Clear();
                DB3cmd.Parameters.AddWithValue("@keyword", $"%{srchText}%");

                SQLiteDataReader DB3rcs = DB3cmd.ExecuteReader();
                if (DB3rcs.HasRows)
                {
                    while (DB3rcs.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", DB3rcs["大分類"], DB3rcs["中分類"], DB3rcs["小分類"], DB3rcs["項目"]);
                    }
                }
            }

            if (DB3con.State != System.Data.ConnectionState.Closed)
            {
                DB3con.Close();
            }
        }
    }
}
