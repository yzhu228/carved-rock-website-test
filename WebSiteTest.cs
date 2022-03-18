using System.Net;
using NUnit.Framework;

namespace carved_rock_website_test;

[TestFixture]
public class WebSiteTest
{
    private HttpClient? _httpClient { get; set; } = null;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }

    [TestCase("")]
    [TestCase("contact")]
    [TestCase("about")]
    [TestCase("carabiners")]
    public async Task Homepage_Ok_Response_Code(string relativePath)
    {
        HttpResponseMessage? response = null;
        if (_httpClient is not null)
        {
            response = await _httpClient.GetAsync($"http://3.86.39.26/{relativePath}");
        }
        Assert.That(response, Is.Not.Null);
        Assert.That(response?.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
