namespace hemopet.UITest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage()
        {
        }

        public HomePage ValidarViews()
        {
            App.Repl();
            App.WaitForElement(query => query.Marked("welcomeMessage").Text("Welcome to hemopet!"));

            return this;
        }
    }
}
