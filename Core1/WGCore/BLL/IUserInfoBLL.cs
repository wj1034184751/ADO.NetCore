using EFMYSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserInfoBLL
    {
        int GetBookCount();

        int GetUserCount();

        List<UserInfo> GetUserInfoList();
    }
}
