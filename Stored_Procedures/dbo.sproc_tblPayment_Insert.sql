CREATE PROCEDURE sproc_tblPayment_Insert

@PayeeName varchar (40),
@Amount decimal (8,2),
@Method varchar (20),
@DatePurchased date,
@OrderId int,
@CardNumber nchar (15)

AS

insert into tblPayment (PayeeName, Amount, Method, DatePurchased, OrderId, CardNumber)
	values (@PayeeName, @Amount, @Method, @DatePurchased, @OrderId, @CardNumber);

return @@Identity