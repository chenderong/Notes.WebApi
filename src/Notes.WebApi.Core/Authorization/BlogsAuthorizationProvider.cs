using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Authorization
{

    /// <summary>
    /// blog 的权限
    /// </summary>
    public class BlogsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Page_Tag, L("Page_Tag"));
            context.CreatePermission(PermissionNames.Page_Tag_Add, L("Add"));
            context.CreatePermission(PermissionNames.Page_Tag_Update, L("Edit"));
            context.CreatePermission(PermissionNames.Page_Tag_Delete, L("Delete"));

            context.CreatePermission(PermissionNames.Page_Blog, L("Page_Blog"));
            context.CreatePermission(PermissionNames.Page_Blog_Add, L("Add"));
            context.CreatePermission(PermissionNames.Page_Blog_Update, L("Edit"));
            context.CreatePermission(PermissionNames.Page_Blog_Delete, L("Delete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WebApiConsts.LocalizationSourceName);
        }
    }
}
