using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DynamicSettings.EF.Model.Enum
{
    [Flags]
    public enum Permissions
    {
        [Description("未設定")]
        None = 0,

        [Description("建立")]
        Create = 1,

        [Description("讀取")]
        Read = 2,

        [Description("更新")]
        Update = 4,

        [Description("刪除")]
        Delete = 8,

        [Description("所有功能")]
        All = Create | Read | Update | Delete
    }
}
