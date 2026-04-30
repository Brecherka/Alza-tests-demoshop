
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UI.Template.Components;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;

namespace UI.Template.Pages;

public class CheckoutPage() : BaseComponent
{
    static IWebDriver Driver => Globals.WebDriver;
    private readonly IWebElement FirstNameField = Driver.FindElement(By.CssSelector("#firstName"));
    private readonly IWebElement LastNameField = Driver.FindElement(By.CssSelector("#lastName"));
    private readonly IWebElement StreetField = Driver.FindElement(By.CssSelector("#street"));
    private readonly IWebElement CityField = Driver.FindElement(By.CssSelector("#city"));
    private readonly IWebElement ZIPCodeField = Driver.FindElement(By.CssSelector("#zipCode"));
    private readonly IWebElement Email = Driver.FindElement(By.CssSelector("#email"));
    private readonly IWebElement PhoneNumberField = Driver.FindElement(By.CssSelector("#phoneNumber"));
    private readonly SelectElement PaymentMethod = new(Driver.FindElement(By.CssSelector("#paymentMethod")));
    private readonly Button PayButton = new(By.ClassName("pay-button"));

    /// <summary>
    /// Fill all reguirement fields to create the order.
    /// </summary>
    /// <param name="firstName">The first name of the customer.</param>
    /// <param name="lastName">The last name of the customer.</param>
    /// <param name="street">The street address.</param>
    /// <param name="city">The city address.</param>
    /// <param name="zip">The zipcode of address.</param>
    /// <param name="email">The customer email.</param>
    /// <param name="phone">The customer phone number.</param>
    /// <param name="method">Payment method selected by the customer.</param>
    /// <returns></returns>
    public void FillRequieredFileds(string firstName, string lastName, string street, string city,
     string zip, string email, string phone, string method)
    {
        FirstNameField.SendKeys(firstName);
        LastNameField.SendKeys(lastName);
        StreetField.SendKeys(street);
        CityField.SendKeys(city);
        ZIPCodeField.SendKeys(zip);
        Email.SendKeys(email);
        PhoneNumberField.SendKeys(phone);
        SelectPaymentMethod(method);
        PayButton.ScrollToAndClick();
    }

    /// <summary>
    /// Waits for loading the confirmation page.
    /// </summary>
    /// <returns>The Confirmation page</returns>

    public static ConfirmationPage WaitForConfirmationPage()
    {
        Driver.WaitForUrlContains("/checkout");
        return new ConfirmationPage();
    }
    /// <summary>
    /// Select payment method from the select dropdown.
    /// </summary>
    /// <returns></returns>
    public void SelectPaymentMethod(string method)
    {
        PaymentMethod.SelectByText(method);
    }
}
