#①家計簿支出検索(家計簿入力補助)(家計簿.CSVから検索)の準備
#①1.家計簿.xlsxの支出をCSV(tab区切り)出力する(テーブルレイアウトのマクロを実行する)
#　※範囲「支出」としたいところだが家計簿シート全体を出力する
$tarpath = "G:\CMD\家計簿DB3data\"
Write-Host -ForegroundColor Yellow $tarpath"家計簿.csvを更新中..."
$Appxl = New-Object -ComObject Excel.Application
$Appxl.Visible = $false
$Appxl.DisplayAlerts = $false
$xlbk = $Appxl.Workbooks.Open("G:\CMD\家計簿DB3def\家計簿DB3テーブルレイアウト.xlsm")
$Appxl.RUN("シートをCSV出力する",$tarpath+"家計簿.xlsx","家計簿",$tarpath+"家計簿.CSV")
$Appxl.Quit()
$Appxl = $null
Write-Host -ForegroundColor Yellow $tarpath"家計簿.csvを更新しました。"

#①2.UTF-8版CSVを更新する
Write-Host -ForegroundColor Yellow $tarpath"支出.csv(TAB区切り,UTF8)を更新中..."
$itemCSV = get-content -encoding Default -path ($tarpath + "家計簿.csv") 
$itemCSV | out-file ($tarpath + "支出.csv") -Encoding UTF8 #SQLite3
Write-Host -ForegroundColor Yellow $tarpath"支出.csvを更新しました。"
