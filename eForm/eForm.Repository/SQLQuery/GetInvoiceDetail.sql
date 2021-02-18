SELECT RequestNumber
      ,DetailName
      ,Qty
      ,Rate
      ,UoMID
  FROM InvoiceDetail
  WHERE RequestNumber = @RequestNumber