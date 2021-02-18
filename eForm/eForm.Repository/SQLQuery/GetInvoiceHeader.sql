SELECT RequestNumber
      ,LanguageID
      ,CurrencyID
      ,InvoiceFrom
      ,VendorID
      ,InvoiceDate
      ,Status
      ,PoNumber
      ,Discount
      ,CreatedDate
      ,CreatedBy
  FROM InvoiceHeader
  WHERE RequestNumber = @RequestNumber