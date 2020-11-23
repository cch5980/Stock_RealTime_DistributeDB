using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class Backtracking
    {
        public Boolean Pababak(List<string[]> stock_che_list)
        {
            Boolean flag = false;
            // Console.WriteLine("체결 데이터 리스트 크기 : " + stock_che_list.Count);
            if (stock_che_list.Count < 1) return false;
            // 일단 한 종목에 대해서만 찾기
            List<List<string>> pababakList = new List<List<string>>();
            List<string> tempList = new List<string>(); // 체결량만 저장
            string che_time = stock_che_list[0][0];
            // 1. 덩어리 만들기(시간 1초 동안 매수인 지점 찾기)
            for (int i = 1; i < stock_che_list.Count; i++)
            {
                if (stock_che_list[i][0] == che_time)
                {
                    tempList.Add(stock_che_list[i][1]);
                }
                else
                {
                    che_time = stock_che_list[i][0];
                    if(tempList.Count > 1) pababakList.Add(tempList);
                    tempList = new List<string>();
                }
            }

            // Console.WriteLine("덩어리들의 리스트 크기 : " + pababakList.Count);
            // 2. 덩어리들끼리 비교(해쉬)
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < pababakList.Count; i++)
            {
                
                Hashtable ht = new Hashtable();
                // Console.WriteLine(i + "번째 덩어리의 크기 : " + pababakList[i].Count);
                for (int j = 0; j < pababakList[i].Count; j++)
                {
                    // Console.WriteLine("값 : " + int.Parse(pababakList[i][j]));
                    if(!ht.ContainsKey(int.Parse(pababakList[i][j]))) ht.Add(int.Parse(pababakList[i][j]), false);
                }

                for (int k = i + 1; k < pababakList.Count; k++)
                {
                    int countNum = 0;
                    for (int t = 0; t < pababakList[k].Count; t++)
                    {
                        if (ht.ContainsKey(int.Parse(pababakList[k][t])))
                        {
                            if(int.Parse(pababakList[k][t]) > 10 && !(Boolean) ht[int.Parse(pababakList[k][t])] )
                            {
                                countNum++;
                                ht[int.Parse(pababakList[k][t])] = true;
                            }
                        }

                    }
                    // 3. 해쉬의 크기가 덩어리의 절반 크기보다 크면 파바박 의심
                    if (countNum >= 4)
                    {
                        flag = true;
                        // Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@파바박 있다");
                        if(!dict.ContainsKey(i)) dict.Add(i, new List<int>());
                        Console.WriteLine("============경계 =============");
                        for (int z=0; z < pababakList[i].Count; z++)
                        {
                            if((Boolean) ht[int.Parse(pababakList[i][z])])
                            {
                                Console.WriteLine("파바박 데이터 : " + pababakList[i][z]);
                            }
                            
                        }
                        dict[i].Add(k);
                    }
                }
            }

            // Console.WriteLine("딕셔너리 크기 : " + dict.Count);
            return flag;
        }
    }
}
