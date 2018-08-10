using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taqc2018.UIMapping
{
    public sealed class LoginPageUIMap
    {
        public const string LOGIN_LABEL_XPATH = "//label[contains(@for,'inputEmail')]";
        public const string LOGIN_INPUT_ID = "login";
        public const string PASSWORD_LABEL_XPATH = "//label[contains(@for,'inputPassword')]";
        public const string PASSWORD_INPUT_ID = "password";
        public const string SIGNIN_BUTTON_CSSSELECTOR = "button.btn.btn-primary";
        public const string LOGO_PICTURE_CSSSELECTOR = "img.login_logo.col-md-8.col-xs-12";

        private LoginPageUIMap() { }
    }
}
