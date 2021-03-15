CREATE TABLE [dbo].[tblPayment] (
    [PaymentId]     INT            IDENTITY (1, 1) NOT NULL,
    [PayeeName]     VARCHAR (40)   NULL,
    [Method]        VARCHAR (20)   NULL,
    [Amount]        DECIMAL (8, 2) NULL,
    [DatePurchased] DATE           NULL,
    [OrderId]       INT            NULL,
    [CardNumber]    NCHAR (15)     NULL,
    PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [FK_tblPayment_ToTable] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[tblOrder] ([OrderId])
);

