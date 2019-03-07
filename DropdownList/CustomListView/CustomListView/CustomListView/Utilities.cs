using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace CustomListView
{
    public class Utilities
    {
        public static string GetStringValueFromResources(string key)
        {
            object finalString = null;
            bool success = Application.Current.Resources.TryGetValue(key, out finalString);
            return (success) ? (string)finalString : "NotFounded";
        }

        public static ImageSource PlatformImageResource(string stringResource)
        {
            string pathImage = BaseResource + GetStringValueFromResources(stringResource);
            return ImageSource.FromResource(pathImage);
        }

        public static string PlatformFileResource(string stringResource)
        {
            string pathImage = BaseResource + GetStringValueFromResources(stringResource);
            return pathImage;
        }

        public static string BaseResource
        {
            get
            {
                string nameOfProject = Assembly.GetExecutingAssembly().FullName.Split(',').FirstOrDefault();
                return nameOfProject + ".Resources.Images.";
            }
        }
    }
}
