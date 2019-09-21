using OpenQA.Selenium;

namespace LearningAppium
{
    static class Const
    {
        public const string AppPackage = "com.tencent.mm";
        public const string LauncherUi = "ui.LauncherUI";

        /// <summary>
        /// 通讯录
        /// </summary>
        public static readonly By TabAddressBookId = By.Id($"{AppPackage}:id/op");
        
        /// <summary>
        /// 公众号
        /// </summary>
        public static readonly By PublicId = By.Id($"{AppPackage}:id/a01");

        /// <summary>
        /// 公众号 ListView
        /// </summary>
        public static readonly By PublicLvId = By.Id($"{AppPackage}:id/xh");

        /// <summary>
        /// 公众号  ListView Item
        /// </summary>
        public static readonly string PublicLvItemId = $"{AppPackage}:id/a3e";

        /// <summary>
        /// 公众号 ListView 底部
        /// </summary>
        public static readonly By PublicLvBottomId = By.Id($"{AppPackage}:id/a1i");

        /// <summary>
        /// 公众号详情
        /// </summary>
        public static readonly By PublicDetailsId = By.Id($"{AppPackage}:id/iw");

        /// <summary>
        /// 公众号详情底部
        /// </summary>
        public static readonly By PublicDetailsBottomId = By.Id($"{AppPackage}:id/ar3");

        /// <summary>
        /// 历史消息列表
        /// </summary>
        public const string HistoryMsgsLocator = "new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().resourceIdMatches(\"WXAPPMSG.*\"))";

        /// <summary>
        /// 正在加载
        /// </summary>
        public const string MsgLoadingLocator = "new UiSelector().textContains(\"正在加载\")";

        /// <summary>
        /// 历史消息 已无更多
        /// </summary>
        public const string NoMoreMsgLocator = "new UiSelector().textContains(\"已无更多\")";

        /// <summary>
        /// 正在加载
        /// </summary>
        public const string ProgressBarLocator = "new UiSelector().resourceId(\"com.tencent.mm:id/b38\")";

        public const string MsgDetailActivity = ".plugin.webview.ui.tools.WebviewMpUI";
    }
}
