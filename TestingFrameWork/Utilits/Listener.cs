using System;
using System.IO;
using OpenQA.Selenium;


namespace TestingFrameWork.Utilits
{
    class Listener
    {
        public static void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\Screens";
                Directory.CreateDirectory(screenFolder);
                Screenshot screen = ((ITakesScreenshot)Driver.DriverSingleton.SetDriver()).GetScreenshot();
                screen.SaveAsFile(screenFolder + @"\" + DateTime.Now.ToString("dd-MM-yy_hh-mm-ss") + ".png", ScreenshotImageFormat.Png);
                throw;
            }
        }
    }
}
