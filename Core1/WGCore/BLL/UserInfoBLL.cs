using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using EFMYSQL;
using EntityExtensions;

namespace BLL
{
    public class UserInfoBLL : IUserInfoBLL, IServiceSupportExten
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IBooksService _booksService;

        public UserInfoBLL(IUserInfoService userInfoService,
                           IBooksService booksService) 
        {
            this._userInfoService = userInfoService;
            this._booksService = booksService;
        }

        public int GetBookCount()
        {
            return _booksService.GetBooksCount();
        }

        public int GetUserCount()
        {
            return _userInfoService.GetUserCount();
        }

        public List<UserInfo> GetUserInfoList()
        {
            return _userInfoService.GetUserInfoList();
        }
    }
}
