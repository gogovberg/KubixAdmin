
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KubixAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            GlobalSettings.PreviousPageID = -1;
            GlobalSettings.CurrentPageID = 0;
            this.userLoginValidation = new MockUserLoginValidation();
            LoginSuccessful += LoginControl_LoginSuccessful;
            LoginFailed += LoginControl_LoginFailed;
            bdrError.Visibility = Visibility.Collapsed;
        }
        public event LoginSuccessfulHandler LoginSuccessful;

        public delegate void LoginSuccessfulHandler(object sender, string token);

        public event EventHandler LoginFailed;

        private IUserLoginValidation userLoginValidation;

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string token = await this.userLoginValidation.ValidateCredentials(this.tbUsername.Text.Trim(), this.tbPassword.Password.Trim());
            if (!string.IsNullOrEmpty(token))
            {
                this.ShowErrorMsg(false);
                if (LoginSuccessful != null)
                {
                    LoginSuccessful(this, token);
                }
            }
            else
            {

                if (LoginFailed != null)
                {
                    LoginFailed(this, new EventArgs());
                }
            }
        }
        public void ShowErrorMsg(bool show, string msg = null)
        {
            if (show)
            {
                bdrError.Visibility = Visibility.Visible;
            }
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            this.ShowErrorMsg(false);
        }
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            this.ShowErrorMsg(false);
        }
        private void LoginControl_LoginFailed(object sender, EventArgs e)
        {
            ShowErrorMsg(true, "Username or password is invalid!");
        }
        private void LoginControl_LoginSuccessful(object sender, string token)
        {

            //GlobalSettings.PreviousPageID = GlobalSettings.CurrentPageID;
            Application.Current.MainWindow.Content = new Customers();
        }

        private void tbCridentials_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            bdrError.Visibility = Visibility.Collapsed;
        }

    }
    public interface IUserLoginValidation
    {
        Task<string> ValidateCredentials(string username, string password);
    }
    public class MockUserLoginValidation : IUserLoginValidation
    {
        public Task<string> ValidateCredentials(string username, string password)
        {
            //// if (username == "admin" && password == "admin") return Task.FromResult("12345");

            //var client = new RestClient("http://data.meetpoint.si/rest/v1/DataAPI/Authenticate/json");
            //var request = new RestRequest(Method.POST);

            //request.AddHeader("content-type", "multipart/form-data;");
            ////request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\""+username+"\"\r\n\r\nrok\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"Password\"\r\n\r\nrok\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            //request.AddParameter("Username", username);
            //request.AddParameter("Password", password);

            //IRestResponse response = client.Execute(request);

            //var res = SimpleJson.DeserializeObject<ServiceResponse>(response.Content);
            //if (res.serviceStatus == "OK")
            //{
            //    if (res.data.authStatus == "OK")
            //        return Task.FromResult(res.data.authToken);
            //    else
            //        return Task.FromResult(default(string));
            //}
            //else

            //    return Task.FromResult(default(string));

            return Task.FromResult("SUCSESS");
        }
    }
}
