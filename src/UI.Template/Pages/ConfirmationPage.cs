using OpenQA.Selenium;
using UI.Template.Components;

namespace UI.Template.Pages;

public class ConfirmationPage() : BaseComponent
{
    static IWebDriver Driver => Globals.WebDriver;

    private readonly IWebElement SummaryPrice = Driver.FindElement(By.XPath("//span[@ko-id='order-total-value']"));
    private readonly IWebElement SummaryPaymentMethod = Driver.FindElement(By.XPath("//p[@ko-id='order-paymentMethod']"));

    /// <summary>
    /// Gets payment method.
    /// </summary>
    /// <returns>The payment method</returns>
    public string GetPaymentMethod()
    {
        return SummaryPaymentMethod.Text;
    }
    /// <summary>
    /// Gets total price
    /// </summary>
    /// <returns>Total price</returns>
    public string GetSummaryPrice()
    {
        return SummaryPrice.Text;
    }
}
