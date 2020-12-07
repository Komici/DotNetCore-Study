//using Microsoft.Extensions.Localization;
//using OrchardCore.Environment.Navigation;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CVMDesktop
//{
//    public class AdminMenu: INavigationProvider
//    {
//        public AdminMenu(IStringLocalizer<AdminMenu> localizer) 
//        {
//            T = localizer;
//        }

//        public IStringLocalizer T { get; set; }

//        public void BuildNavigation(string name, NavigationBuilder builder)
//        {
//            if(!string.Equals(name,"admin",StringComparison.OrdinalIgnoreCase))
//            {
//                return;
//            }
//            builder.Add(T["WebCat"],configuration=> configuration
//            .Add(T["Settings"],"1",setting=> setting
//            .Action("Index","Admin",new { area = "Weyhd.Wechat"})
//            .Permission(Permissions.WeChatSettings)
//            .LocalNav()
//            ));
//        }
//    }
//}
