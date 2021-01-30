using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewColumSortDLL
{
    public class ItemSort
    {
        /// <summary>
        /// ListView ColumnClick 함수 내에서 클릭
        /// 최초 클릭시 오름차순(ASC) 정렬 됨
        /// </summary>
        /// <param name="listView">정렬할 ListView 객체</param>
        /// <param name="e">ColumnClick Event의 이벤트 객체</param>
        /// <param name="isNumber">숫자형 정렬 여부</param>
        public static void Sort(ListView listView, ColumnClickEventArgs e, bool isNumber)
        {
            var sorter = listView.ListViewItemSorter as ItemComparer;
            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                listView.ListViewItemSorter = sorter;
            }

            sorter.IsNumber = isNumber;
            if (e.Column == sorter.Column)
            {
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listView.Sort();
        }
    }
}