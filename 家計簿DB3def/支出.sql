DROP TABLE 支出;

CREATE TABLE 支出 (
	No	INTEGER not NULL,
	日付	TEXT,
	口座	TEXT,
	大分類	TEXT,
	中分類	TEXT,
	小分類	TEXT,
	項目	TEXT,
	数量	numeric,
	金額	numeric,
	取引先	TEXT,
	備考	TEXT,
	周期	TEXT,
	Mark	TEXT,
	YY	INTEGER,
	YM	INTEGER
	,PRIMARY KEY(
		No
	)
);

