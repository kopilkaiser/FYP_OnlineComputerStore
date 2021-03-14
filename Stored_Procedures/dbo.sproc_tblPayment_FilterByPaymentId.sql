CREATE PROCEDURE sproc_tblPayment_FilterByPaymentId
	@PaymentId int

AS

select * from tblPayment where PaymentId = @PaymentId

return 0