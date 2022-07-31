using GlobalQueryFilters.II.DAL;

using (var context = new AppDbContext(2)) // Tenan bilgimizi burdan gönderdik.
{

    #region AddDataIfNotExist
    if (context.Cards.FirstOrDefault() == null)
    {
        var card1 = new Card()
        { 
            Amount = 132, 
            AmountLimit = 1626, 
            CardNumber = "2234444443423", 
            CardReferenceNumber = "34213", 
            ShadowCardNumber = "4445654645", 
            TenantId = 3,
            TenantCode = "China"
        };

        var card2 = new Card()
        {
            Amount = 122, 
            AmountLimit = 1636,
            CardNumber = "223423111123",
            CardReferenceNumber = "13345",
            ShadowCardNumber = "4445654645",
            TenantId = 3,
            TenantCode = "TR"
        };

        var card3 = new Card()
        {
            Amount = 112,
            AmountLimit = 1466,
            CardNumber = "223999900003",
            CardReferenceNumber = "98467",
            ShadowCardNumber = "4445654645",
            TenantId = 3,
            TenantCode = "USA"
        };

        context.AddRange(card1,card2,card3);

        context.SaveChanges();
    }
    #endregion

    var cards = context.Cards.ToList();

    Console.WriteLine("");
}