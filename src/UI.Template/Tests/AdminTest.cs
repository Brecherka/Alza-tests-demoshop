using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class AdminTest : BaseTest
{
    [Test]
    public void CreateProducktAndCheckParametersTest()
    {
        // TC description:
        // 1. Go to the admin page.
        // 2. Open create new product and fill parameters.
        //        Name = "Camera M25"
        //        Category = "Cameras"
        //        Price = "50.5"
        //        Stock = "5"
        //        Image = "Camera 2"
        //        Description = "Camera"
        // 3. Save new product.
        // 4. Go to the demoshop page
        // 5. Go to the Cameras category
        // 6. Open detail of newly created product "Camera M25"
        // 7. Check that Name, Price and Stock are equal to inserted values from step 2.


        TestProduct _newProduct = TestData.NewProduct;

        /*** STEP 1 ***/
        AdminPage adminPage = new();
        adminPage.Open();
        adminPage.WaitForReady();

        /*** STEPS 2-3 ***/
        adminPage.FillProductDetailAndSave(_newProduct.ProductName, _newProduct.ProductCategory,
        _newProduct.ProductPrice, _newProduct.ProductStock, _newProduct.ProductImage, _newProduct.ProductDescription);

        /*** STEP 4 ***/
        HomePage homePage = adminPage.GoToEshopHome();

        /*** STEPS 5-6 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(_newProduct.ProductCategory,
                                                                                 _newProduct.ProductName);
        /*** STEP 7 ***/
        productDetail.WaitForReady();
        Product productModelFromDetail = productDetail.ProductInfoForm.ToProductModel();

        Assert.Multiple(() =>
        {
            Assert.That(productModelFromDetail.Name, Is.EqualTo(_newProduct.ProductName), "Failed to find product name");
            Assert.That(productModelFromDetail.Price, Is.EqualTo(_newProduct.ProductPrice), "Failed to find product price");
            Assert.That(productModelFromDetail.Stock, Is.EqualTo(_newProduct.ProductStock), "Failed to find product availability");
        });

    }
}
