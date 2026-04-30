// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using UI.Template.Models;

namespace UI.Template.Data;

public static class TestData
{
    public static TestProduct ParametersTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Wireless Mouse",
        ProductUrl = "/product/2"
    };

    public static TestProduct CardTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Gaming Keyboard RGB"
    };

    public static TestProduct ProductToBuy { get; } = new TestProduct
    {
        ProductCategory = "Monitors",
        ProductName = "4K LED Monitor"
    };

    public static UserData CustomerData { get; } = new UserData
    {
        FirstName = "Ivana",
        LastName = "Brecherova",
        Street = "Hornopolni",
        City = "Ostrava",
        ZIPCode = "70200",
        Email = "hello@test.cz",
        PhoneNumber = "123456789",
        PaymentMethod = "PayPal"
    };
}
