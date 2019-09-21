using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace LearningAppium
{
    class Program
    {
        private static AppiumOptions caps = null;
        private static Uri _serverUri = null;
        private static AndroidDriver<AppiumWebElement> _driver = null;
        private static Size _screenSize = Size.Empty;
        private static int _x = 0;
        private static int _fromY = 0;
        private static int _toY = 0;

        static void Main(string[] args)
        {
            caps = new AppiumOptions();
            caps.AddAdditionalCapability("platformName", "Android");
            // caps.AddAdditionalCapability("platformVersion", "7.0");
            caps.AddAdditionalCapability("deviceName", "Android Emulator");
            caps.AddAdditionalCapability("automationName", "UIAutomator2");
            caps.AddAdditionalCapability("noReset", true);
            caps.AddAdditionalCapability("appPackage", Const.AppPackage);
            caps.AddAdditionalCapability("appActivity", Const.LauncherUi);

            try
            {
                _serverUri = new Uri("http://127.0.0.1:4723/wd/hub");
                _driver = new AndroidDriver<AppiumWebElement>(_serverUri, caps, TimeSpan.FromSeconds(180));
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _screenSize = _driver.Manage().Window.Size;

                var isFlashPage = IsFlashPage();

                while (isFlashPage)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    isFlashPage = IsFlashPage();
                }

                _driver.FindElements(Const.TabAddressBookId)[1].Click();

                ClickElement(Const.PublicId);

                var previousBottom = 0;

                var publicList = _driver.FindElement(Const.PublicLvId);

                _x = (int)(_screenSize.Width * 0.5);
                _fromY = (int)(_screenSize.Height * 0.9);
                _toY = (int)(_screenSize.Height * 0.1);

                var scrollDistance = _fromY - _toY;
                var isLastTime = false;

                while (true)
                {
                    var elements = FetchPublicItems(publicList);

                    foreach (var element in elements)
                    {
                        if (element.Rect.Top > previousBottom - scrollDistance)
                            OperatePublicItem(element);
                    }

                    previousBottom = elements.Last().Rect.Bottom;
                    Swipe(new Point(_x, _fromY), new Point(_x, _toY), TimeSpan.FromSeconds(1));

                    if (!IsPublicBottom()) continue;

                    if (isLastTime)
                        break;

                    isLastTime = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _driver?.Quit();
            }
        }

        static bool IsFlashPage()
        {
            try
            {
                var ele = _driver.FindElement(By.XPath(
                    "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ImageView"));

                return ele != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void ClickElement(By by, TimeSpan? wait = null)
        {
            try
            {
                _driver.FindElement(by).Click();

                wait ??= TimeSpan.FromSeconds(1);
                Thread.Sleep(wait.Value);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        static void ScrollDown(Size screenSize, By targetBy = null)
        {
            var touch = new TouchAction(_driver);

            if (targetBy == null)
            {
                touch.Press(50, screenSize.Height * 0.9)
                    .Wait(300)
                    .MoveTo(50, screenSize.Height * 0.1)
                    .Wait(500)
                    .Release()
                    .Perform();
            }
            else
            {
                var targetEle = _driver.FindElements(targetBy).Last();

                touch.Press(targetEle, 50, screenSize.Height * 0.9)
                    .Wait(300)
                    .MoveTo(targetEle, 50, screenSize.Height * 0.1)
                    .Wait(500)
                    .Release()
                    .Perform();
            }
        }

        static void ScrollToBottom(Size screenSize, By refBy, By targetBy = null)
        {
            var isNotBottom = true;

            while (isNotBottom)
            {
                try
                {
                    ScrollDown(screenSize, targetBy);

                    var current = _driver.FindElements(refBy).Last();
                    isNotBottom = current == null;
                }
                catch (Exception)
                {
                    isNotBottom = true;
                }
            }
        }

        static IReadOnlyCollection<AppiumWebElement> FetchPublicItems(AppiumWebElement ele)
        {
            var locator = new ByAndroidUIAutomator($"new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().resourceId(\"{Const.PublicLvItemId}\"));");
            return ele.FindElements(locator);
        }

        static bool IsPublicBottom()
        {
            try
            {
                _driver.FindElement(Const.PublicLvBottomId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void OperatePublicItem(AppiumWebElement element)
        {
            // 公众号列表项
            element.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // 详细信息
            ClickElement(Const.PublicDetailsId);

            // 滚动至全部消息按钮可见状态
            var screenSize = _driver.Manage().Window.Size;
            ScrollToBottom(screenSize, Const.PublicDetailsBottomId);

            // 点击全部消息
            ClickElement(Const.PublicDetailsBottomId, TimeSpan.FromSeconds(5));

            while (HasProgressBar())
                Thread.Sleep(TimeSpan.FromSeconds(1));

            OperateHistoryMsgItem();

            _driver.PressKeyCode(AndroidKeyCode.Back);
            Thread.Sleep(TimeSpan.FromSeconds(1));

            _driver.PressKeyCode(AndroidKeyCode.Back);
            Thread.Sleep(TimeSpan.FromSeconds(1));

            _driver.PressKeyCode(AndroidKeyCode.Back);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        static void OperateHistoryMsgItem()
        {
            var isLastTime = false;

            while (true)
            {
                var locator = new ByAndroidUIAutomator(Const.HistoryMsgsLocator);
                var elements = _driver.FindElements(locator);


                foreach (var element in elements)
                {
                    var rectangle = element.Rect;

                    var needScroll = rectangle.Bottom > _screenSize.Height - 50;
                    Console.WriteLine($"rectangle.Bottom -> {rectangle.Bottom}");
                    if (needScroll)
                    {
                        Console.WriteLine("Scroll");
                        Swipe(new Point(_x, rectangle.Top), new Point(_x, 180), TimeSpan.FromSeconds(1));
                    }

                    element.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    // 可能需要更久

                    // 返回至消息列表
                    _driver.PressKeyCode(AndroidKeyCode.Back);
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }

                while (!IsLoadingMsg())
                {
                    if (!HasMoreMsg())
                    {
                        if (isLastTime)
                            return;

                        isLastTime = true;
                    }
                    else
                        Swipe(new Point(_x, _fromY), new Point(_x, _toY), TimeSpan.FromSeconds(1));
                }
            }
        }

        static void Swipe(Point f, Point t, TimeSpan delay)
        {
            var args = new Dictionary<string, object>();
            args["command"] = "input swipe";
            args["args"] = $"{f.X} {f.Y} {t.X} {t.Y} {delay.TotalMilliseconds}";
            args["includeStderr"] = true;
            args["timeout"] = 10000;
            _driver.ExecuteScript("mobile: shell", args);
        }

        static bool HasMoreMsg()
        {
            try
            {
                var locator = new ByAndroidUIAutomator(Const.NoMoreMsgLocator);
                return _driver.FindElement(locator) == null;
            }
            catch (Exception)
            {
                return true;
            }
        }

        static bool IsLoadingMsg()
        {
            try
            {
                var locator = new ByAndroidUIAutomator(Const.MsgLoadingLocator);
                return _driver.FindElement(locator) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void ScrollMsgToTop(int bottom)
        {
            Swipe(new Point(_x, bottom), new Point(_x, 180), TimeSpan.FromSeconds(1));
        }

        static bool HasProgressBar()
        {
            try
            {
                var locator = new ByAndroidUIAutomator(Const.ProgressBarLocator);
                return _driver.FindElement(locator) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void SafeClick(AppiumWebElement element)
        {
            try
            {
                while (true)
                {
                    element.Click();

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
