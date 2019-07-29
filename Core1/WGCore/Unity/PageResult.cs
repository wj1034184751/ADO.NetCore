using System;
using System.Collections.Generic;
using System.Text;

namespace Unity
{
    public class BaseQueryParams
    {
        public BaseQueryParams()
        {
            this.pageNumber = 1;
            this.pageSize = 20;
            this.sort = "Id";
            this.order = "desc";
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int pageNumber { get; set; }

        /// <summary>
        /// 分页数
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort { get; set; }

        private string _order;
        /// <summary>
        /// 正序倒序
        /// </summary>
        public string order
        {
            get
            {
                return string.IsNullOrWhiteSpace(_order) ? "asc" : _order;
            }
            set
            {
                _order = value;
            }
        }

        private string _keyword;
        public string keyword
        {
            get
            {
                return string.IsNullOrWhiteSpace(_keyword) ? null : $"%{_keyword}%";
            }
            set
            {
                _keyword = value;
            }
        }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        public int skip
        {
            get
            {
                return (pageNumber - 1) * pageSize;
            }
        }
    }
}
