INSERT INTO InvoiceHeader
           (RequestNumber
           ,LanguageID
           ,CurrencyID
           ,InvoiceFrom
           ,VendorID
           ,InvoiceDate
           ,Status
           ,PoNumber
           ,Discount
           ,CreatedDate
           ,CreatedBy)
     VALUES
           (@RequestNumber
           ,@LanguageID
           ,@CurrencyID
           ,@InvoiceFrom
           ,@VendorID
           ,@InvoiceDate
           ,@Status
           ,@PoNumber
           ,@Discount
           ,@CreatedDate
           ,@CreatedBy)

