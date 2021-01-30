using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewColumSortDLL
{
    public class ItemComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 정렬할 칼럼의 index
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 정렬 방식
        /// ASC, DESC
        /// </summary>
        public SortOrder Order { get; set; }

        /// <summary>
        /// 숫자형 정렬 여부
        /// </summary>
        public bool IsNumber { get; set; }

        public ItemComparer(int colIndex)
        {
            Column = colIndex;
            Order = SortOrder.None;
            IsNumber = false;
        }

        public int Compare(object a, object b)
        {
            int result;

            var itemA = a as ListViewItem;
            var itemB = b as ListViewItem;

            if (IsNumber)
            {
                result = int.Parse(itemA.SubItems[Column].Text) - int.Parse(itemB.SubItems[Column].Text);
            }
            else
            {
                result = string.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            }

            if (Order == SortOrder.Descending)
            {
                result *= -1;
            }
            return result;
        }
    }
}