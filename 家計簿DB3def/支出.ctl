>cd G:\CMD\家計簿DB3data
>sqlite3 家計簿.db3
drop table 支出STR;
.mode csv
.separator "\t"
.import ./支出.CSV 支出STR
.exit
