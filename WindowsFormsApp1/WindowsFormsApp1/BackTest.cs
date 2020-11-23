using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BackTest
    {

        public void Pababak(List<string[]> stock_che_list)
        {
            // 일단 한 종목에 대해서만 찾기
            List<List<string>> pababakList = new List<List<string>>();
            List<string> tempList = new List<string>(); // 체결량만 저장
            string che_time = stock_che_list[0][2];
            // 1. 덩어리 만들기(시간 1초 동안 매수인 지점 찾기)
            for(int i=1; i<stock_che_list.Count; i++)
            {
                if(stock_che_list[i][2] == che_time && stock_che_list[i][6].StartsWith("+"))
                {
                    tempList.Add(stock_che_list[i][6]);
                } else
                {
                    che_time = stock_che_list[i][2];
                    pababakList.Add(tempList);
                    tempList = new List<string>();
                }
            }

            // 2. 덩어리들끼리 비교(해쉬)
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for(int i=0; i<pababakList.Count; i++)
            {
                Hashtable ht = new Hashtable();
                for(int j=0; j<pababakList[i].Count; j++)
                {
                    ht.Add(pababakList[i][j], pababakList[i][j]);
                }

                for(int k=i+1; k<pababakList.Count; k++)
                {
                    int countNum = 0;
                    for(int t=0; t<pababakList[k].Count; t++)
                    {
                        if (ht.Contains(pababakList[k][t])) countNum++;

                    }
                    // 3. 해쉬의 크기가 덩어리의 절반 크기보다 크면 파바박 의심
                    if (countNum >= (pababakList[k].Count)/2)
                    {
                        dict[i].Add(k);
                    }
                }
            }

            


        }


    }
}
