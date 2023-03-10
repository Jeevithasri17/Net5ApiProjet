CREATE FUNCTION [dbo.GetLast12DigitsFromGUID] (@guid UNIQUEIDENTIFIER)
RETURNS NVARCHAR(12)
AS
BEGIN
	DECLARE @inputguid NVARCHAR(36)
	SET @inputguid = CONVERT(NVARCHAR(36), @inputguid)
	DECLARE @last12char NVARCHAR(12)
	SET @last12char = SUBSTRING(@inputguid, LEN(@inputguid) - 11, 12)
	RETURN @last12char
END 