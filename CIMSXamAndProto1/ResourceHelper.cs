using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Reflection;

namespace CIMSXamAndProto1
{
    public static class ResourceHelper
    {
        static Dictionary<String, int> resourceDictionary = new Dictionary<string, int>();
        public static int TranslateDrawable(String drawbableName)
        {
            int resourceValue = -1;
            switch(drawbableName)
            {
                case "Foothills.jpg":
                    resourceValue = Resource.Drawable.Foothills;
                    break;
                case "SurveyModule.jpg":
                    resourceValue = Resource.Drawable.SurveyModule;
                    break;
                case "WQModule.jpg":
                    resourceValue = Resource.Drawable.WQModule;
                    break;
            }
            return resourceValue;
        }

        public static int TranslateDrawableWithReflection(String drawableName)
        {
            int resourceValue = -1;

            if (resourceDictionary.ContainsKey(drawableName))
            {
                resourceValue = resourceDictionary[drawableName];
            }
            else
            {
                Type DrawableType = typeof(Resource.Drawable);
                FieldInfo resourceFieldInfo = DrawableType.GetField(drawableName);

                resourceValue = (int)resourceFieldInfo.GetValue(null);
                resourceDictionary.Add(drawableName, resourceValue);
            }
            return resourceValue;
        }
    }
}