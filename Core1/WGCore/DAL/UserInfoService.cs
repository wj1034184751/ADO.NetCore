using System;
using System.Collections.Generic;
using System.Linq;
using EFMYSQL;
using EntityExtensions;

namespace DAL
{
    public class UserInfoService : IUserInfoService, IServiceSupportExten
    {
        public int GetUserCount()
        {
            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                var count = _context.UserInfo.Count();
                return count;
            }
        }

        public List<UserInfo> GetUserInfoList()
        {
            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                var count = _context.UserInfo.ToList();
                return count;
            }
        }
    }
}
