using EFMYSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserInfoService
    {
        int GetUserCount();

        List<UserInfo> GetUserInfoList();
    }
}
