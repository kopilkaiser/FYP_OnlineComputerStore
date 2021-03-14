CREATE PROCEDURE sproc_tblPayment_FilterByPayeeName
	@PayeeName varchar(40)
AS
	select * from tblPayment where PayeeName like @PayeeName + '%';