
alter PROCEDURE Get_Stock
(
	@pCode nvarchar(50),
	@pStartDate int,
	@pFinishDate int
)

AS
BEGIN

	select 

s.ID,
CASE
    WHEN s.IslemTur = 0 THEN 'Giriþ'
    WHEN s.IslemTur = 1 THEN 'Çýkýþ'
END AS ProcessType,
s.EvrakNo AS DocumentNo,
CONVERT(VARCHAR(15), CAST(s.Tarih - 2 AS datetime), 104) AS Date,
CASE
    WHEN s.IslemTur = 0 THEN s.Miktar
    ELSE 0
END AS EntryQuantity,
CASE
    WHEN s.IslemTur = 1 THEN s.Miktar
    ELSE 0
END AS OutputQuantity

from STI s

where
s.Tarih >= @pStartDate AND 
s.Tarih <= @pFinishDate AND
(@pCode = '*' OR s.EvrakNo LIKE CONCAT('%',@pCode,'%') OR s.MalKodu LIKE CONCAT('%',@pCode,'%'))

order by s.ID;
	
END
GO
