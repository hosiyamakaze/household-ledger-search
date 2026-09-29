using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SrchTextCSWinDB3
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB3con;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private string sql = @"
SELECT DISTINCT 大分類 ,中分類 , 小分類 , 項目
FROM 支出
WHERE ((小分類 Like @keyword) OR (項目 Like @keyword))
ORDER BY 大分類 ,中分類 , 小分類 , 項目
";

        public Form1()
        {
            InitializeComponent();
            this.Text = "家計簿支出検索(家計簿.db3)";
            DB3con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }

        // loadData
        private void LoadData(string srchText)
        {
            SQLiteDataAdapter DB3da;

            DB3con.Open();
            var DB3cmd = new SQLiteCommand(sql, DB3con);
            DB3cmd.Parameters.AddWithValue("@keyword", $"%{srchText}%");
            DB3da = new SQLiteDataAdapter(DB3cmd);
            DS.Reset();
            DB3da.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DB3con.Close();
        }

        private void SrchBtn_Click(object sender, EventArgs e) => LoadData(SrchTextTB.Text);

        private void SrchTextTB_TextChanged(object sender, EventArgs e) => LoadData(SrchTextTB.Text);
    }

}
