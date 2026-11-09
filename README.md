# household-ledger-search

    C# WinForms app to search household expenses stored in SQLite (migrated from Excel).
    With Powershell,Excel Macro Book.

    see. household-ledger-search.pdf
    “家計簿” is the kanji writing of “household ledger”.

# 家計簿検索(日本語説明)
- 既往歴のある商品の分類情報等を取得するために家計簿を検索する
- 家計簿.xlsxからcsvファイルを経由してSQLiteデータベースに移行する
- C# WinFom または console アプリで検索する
- これにより分類の重複や項目名のゆらぎを防止するとともに省入力に寄与することを目的とする

0. 使用するツール
- [SQLite管理ツールおよびDLL](https://www.sqlite.org/index.html)
- [DB Browser for SQLite](https://sqlitebrowser.org/dl/)
- [Visual Studio community](https://visualstudio.microsoft.com/ja/vs/community/)

1. PowerShellで家計簿.xlsxからcsvファイルに出力する
- 「家計簿.xlsxからCSVデータ準備.ps1」に埋め込みのファイルパスを確認する
- スクリプトを実行する
```PowerShell
./家計簿.xlsxからCSVデータ準備.ps1
```

2. 家計簿.db3データベースを構築する
- 家計簿DB3テーブルデータシート.xlsmから生成された支出.ctlファイルの内容を参照しcommandを実行する
- 家計簿.db3データベースを開き、集計行を削除し、プロジェクトを保存する
- 家計簿DB3テーブルデータシート.xlsmから生成された支出定義用のDDL,支出STRから支出へのデータ変換用SQLを、プロジェクトから実行する

3. C# WinForms appをビルドし、実行する
- 必要なパッケージはPDFを参照方
- App.configのデータソースのパスを調整する
- 検索結果を選択し、大分類～項目までを家計簿.xlsxに貼り付ける
- Winformアプリの方が使い勝手が良い。console appは参考まで
