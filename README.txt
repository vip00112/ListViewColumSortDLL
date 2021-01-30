ListView Colum 정렬 DLL
개발 툴 : Microsoft Visual Studio 15
대상 프레임워크 : .NET Framework 4.5

1. 사용 방법
 1) 사용자의 ListView객체에 ColumClick 이벤트 등록
 2) ColumClick 이벤트 안에서 함수 호출
	/// <summary>
	/// ListView ColumnClick 함수 내에서 클릭
	/// 최초 클릭시 오름차순(ASC) 정렬 됨
	/// </summary>
	/// <param name="listView">정렬할 ListView 객체</param>
	/// <param name="e">ColumnClick Event의 이벤트 객체</param>
	/// <param name="isNumber">숫자형 정렬 여부</param>
	ItemSort.Sort(System.Windows.Forms.ListView listView, ColumnClickEventArgs e, bool isNumber);
 

2. 사용 예제
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 0번 컬럼: 숫자 정렬
            if (e.Column == 0)
            {
                ItemSort.Sort(listView1, e, true);
            }

            // 1번 컬럼: 문자 정렬
            else if (e.Column == 1)
            {
                ItemSort.Sort(listView1, e, false);
            }

            // 그 외 컬럼: 문자 정렬
            else
            {
                ItemSort.Sort(listView1, e, false);
            }
        }
