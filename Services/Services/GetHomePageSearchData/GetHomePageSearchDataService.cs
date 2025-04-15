using AeC.AutomationChallenge.Domain.HomePage.Dtos;
using AeC.AutomationChallenge.Domain.HomePage.Transport;
using AeC.AutomationChallenge.Domain.Interfaces.Repositories;
using AeC.AutomationChallenge.Domain.Interfaces.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AeC.AutomationChallenge.Services.Services.GetHomePageSearchData
{
    public partial class GetHomePageSearchDataService : IGetHomePageSearchDataService
    {
        private readonly Uri _aecSiteUrl = new("https://www.aec.com.br");
        private readonly IWebDriver _driver = new ChromeDriver();
        private readonly IRecordHomePageSearchDataRepository _repository;

        public GetHomePageSearchDataService(IRecordHomePageSearchDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<SaveTheHomePageResultInDatabaseResponse> GetHomePageSearchData(string searchTerm, CancellationToken cancellationToken)
        {
            CheckIfTheHomePageIsOkStep(_aecSiteUrl);

            NavigateToTheCompanyHomePageStep(_aecSiteUrl);

            ClickOnTheMagnifierOnTheLeftStep();

            InsertTheSearchTermInTheTextBox(searchTerm);

            ClickOnTheMagnifierOnTheRightOfTheText();

            var model = SelectTheFirstItemGroupOfTheHomePageDataBeforeSearch();

            _driver.Close();

            return await SaveTheHomePageResultInDatabase(model, cancellationToken);
        }

        public static async void CheckIfTheHomePageIsOkStep(Uri url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ElementNotInteractableException("A página da AeC está indisponível no momento.");
            }
        }

        public void NavigateToTheCompanyHomePageStep(Uri url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void ClickOnTheMagnifierOnTheLeftStep()
        {
            var element = By.ClassName("buscar");

            ElementExists(element);

            IWebElement aElement = _driver.FindElement(element);
            new Actions(_driver).Click(aElement).Perform();
        }

        public void InsertTheSearchTermInTheTextBox(string searchTerm)
        {
            var element = By.CssSelector("#form > input[type=search]");

            ElementExists(element);

            var inputElement = _driver.FindElement(By.CssSelector("#form > input[type=search]"));
            inputElement.SendKeys(searchTerm);
        }

        public void ClickOnTheMagnifierOnTheRightOfTheText()
        {
            var element = By.CssSelector(".me-3");

            ElementExists(element);

            IWebElement aElement = _driver.FindElement(element);
            new Actions(_driver).Click(aElement).Perform();
        }

        public SaveTheHomePageResultInDatabaseRequest SelectTheFirstItemGroupOfTheHomePageDataBeforeSearch()
        {
            var groupedElement = GetGroupedElement();

            var titleElement = GetTitle(groupedElement);

            var areaElement = GetArea(groupedElement);

            var descriptionElement = GetDescription(groupedElement);

            return new SaveTheHomePageResultInDatabaseRequest
            {
                Title = titleElement.Text,
                Area = areaElement.Text,
                Author = GetAuthorFromText(groupedElement),
                Description = descriptionElement.Text,
                PublishingDate = GetPublishingDateText(groupedElement)
            };
        }

        public IWebElement GetGroupedElement()
        {
            var element = By.CssSelector(".text.gray");
            ElementExists(element);
            IWebElement groupedElement = _driver.FindElement(element);
            return groupedElement;
        }

        public IWebElement GetTitle(IWebElement groupedElement)
        {
            var title = By.CssSelector(".tres-linhas");
            ElementExists(title);
            IWebElement titleElement = groupedElement.FindElement(title);
            return titleElement;
        }

        public IWebElement GetArea(IWebElement groupedElement)
        {
            var area = By.CssSelector(".hat");
            ElementExists(area);
            IWebElement areaElement = groupedElement.FindElement(area);
            return areaElement;
        }

        public IWebElement GetDescription(IWebElement groupedElement)
        {
            var description = By.CssSelector(".duas-linhas");
            ElementExists(description);
            IWebElement descriptionElement = groupedElement.FindElement(description);
            return descriptionElement;
        }

        public DateTime GetAuthor(IWebElement groupedElement)
        {
            var author = By.CssSelector("span > small");
            ElementExists(author);
            IWebElement authorElement = groupedElement.FindElement(author);

            var authorText = GetPublishingDate(authorElement);
            _ = DateTime.TryParse(authorText, out DateTime publishingDateTime);
            return publishingDateTime;
        }

        public static DateTime GetPublishingDateText(IWebElement groupedElement)
        {
            var publishingDateText = GetPublishingDate(groupedElement);
            _ = DateTime.TryParse(publishingDateText, out DateTime publishingDateTime);
            return publishingDateTime;
        }

        public static string GetPublishingDate(IWebElement groupedElement)
        {
            var match = PublishingDateRegex().Match(groupedElement.Text);
            string result = "";

            if (match.Success)
                result = match.Value;

            return result;
        }

        public static string GetAuthorFromText(IWebElement groupedElement)
        {
            var authorAndPublishingDate = By.CssSelector("span > small");
            IWebElement authorAndPublishingDateElement = groupedElement.FindElement(authorAndPublishingDate);

            var authorAndPublishingDateText = authorAndPublishingDateElement.Text;
            var publishingDate = GetPublishingDate(authorAndPublishingDateElement);

            authorAndPublishingDateText =
                authorAndPublishingDateText
                .Replace("Publicado por ", "")
                .Replace(string.Concat(" em ", publishingDate), "");

            return authorAndPublishingDateText;
        }

        public async Task<SaveTheHomePageResultInDatabaseResponse> SaveTheHomePageResultInDatabase
            (SaveTheHomePageResultInDatabaseRequest request, CancellationToken cancellationToken)
        {
            var homePageSearchDataDto = HomePageSearchDataDto.Create(request);
            var dto = await _repository.RecordHomePageSearchData(homePageSearchDataDto, cancellationToken);
            return HomePageSearchDataDto.Response(dto);
        }

        [GeneratedRegex("[0-9]{2}/[0-9]{2}/[0-9]{4}")]
        private static partial Regex PublishingDateRegex();

        public void ElementExists(By element)
        {
            var elementExists = _driver.FindElements(element).Any();

            if (!elementExists)
            {
                throw new NoSuchElementException($"O Elemento {element.Criteria} não existe na página.");
            }
        }
    }
}
