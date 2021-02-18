SELECT RequestNumber
      ,DetailName
      ,Qty
      ,UoMID
  FROM InvoiceDetail
  WHERE RequestNumber = @RequestNumber