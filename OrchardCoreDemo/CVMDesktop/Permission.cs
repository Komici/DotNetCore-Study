//using OrchardCore.Security.Permissions;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CVMDesktop
//{
//    public class Permissions: IPermissionProvider
//    {
//        public static readonly Permission WeChatSettings = new Permission("WeChatSettings", "WeChat settings");

//        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
//        {
//            return new[]
//            {
//                new PermissionStereotype
//                {
//                    Name = "Administrator",
//                    Permissions = new []{ WeChatSettings }
//                }
//            };
//        }

//        public IEnumerable<Permission> GetPermissions()
//        {
//            return new[] { WeChatSettings };
//        }
//    }
//}
