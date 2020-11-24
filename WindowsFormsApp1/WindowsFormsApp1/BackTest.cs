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
        public Boolean Pababak(List<string[]> stock_che_list)
        {
            int criteriaNum = 10; 
            Boolean flag = false;
            if (stock_che_list.Count < 1) return false;
            List<Dictionary<string, List<string>>> pababakList = new List<Dictionary<string, List<string>>>();
            Dictionary<string, List<string>> pababakDict = new Dictionary<string, List<string>>();
            List<string[]> tempList = new List<string[]>(); // 체결량만 저장
            string che_time = stock_che_list[0][0];
            pababakDict.Add(che_time, new List<string>());
            // 1. 덩어리 만들기(시간 1초 동안 매수인 지점 찾기)
            for (int i = 1; i < stock_che_list.Count; i++)
            {
                if (stock_che_list[i][0] == che_time && int.Parse(stock_che_list[i][1]) > 10)
                {
                    pababakDict[che_time].Add(stock_che_list[i][1]);
                }
                else
                {
                    che_time = stock_che_list[i][0];
                    if (pababakDict.Count > 1) pababakList.Add(pababakDict);
                    pababakDict.Add(che_time, new List<string>());
                }
            }



            // 2. 덩어리들끼리 비교(해쉬)
            Dictionary<string, List<string[]>> dictResult = new Dictionary<string, List<string[]>>();

            for(int i=0; i<pababakDict.Count-1; i++)
            {
                Hashtable ht = new Hashtable();
                string dictKey = pababakDict.Keys.ToList()[i];
                if (pababakDict[dictKey].Count() < criteriaNum) continue;

                for(int j=0; j< pababakDict[dictKey].Count(); j++)
                {
                    if (ht.ContainsKey(int.Parse(pababakDict[dictKey][j]))) ht.Add(int.Parse(pababakDict[dictKey][j]), (int)ht[int.Parse(pababakDict[dictKey][j])] + 1);
                    else ht.Add(int.Parse(pababakDict[dictKey][j]), 1);
                }

                Hashtable copyHt = (Hashtable) ht.Clone();
                for (int k = i + 1; k < pababakDict.Count; k++)
                {
                    int countNum = 0;
                    string compareDictKey = pababakDict.Keys.ToList()[k];
                    for (int t = 0; t < pababakDict[compareDictKey].Count; t++)
                    {
                        if (copyHt.ContainsKey(int.Parse(pababakDict[compareDictKey][t])) && int.Parse(pababakDict[compareDictKey][t]) > 10 && (int)copyHt[int.Parse(pababakDict[compareDictKey][t])] > 0)
                        {
                            countNum++;
                            copyHt[int.Parse(pababakDict[compareDictKey][t])] = ((int)copyHt[int.Parse(pababakDict[compareDictKey][t])] - 1);
                        }

                    }
                    // 3. 파바박 의심
                    if (countNum >= criteriaNum)
                    {
                        flag = true;
                        if (!dictResult.ContainsKey(dictKey)) dictResult.Add(dictKey, new List<string[]>());
                        Console.WriteLine("============경계 =============");
                        Console.WriteLine("집합A");
                        for (int n = 0; n < pababakDict[dictKey].Count; n++)
                        {
                            Console.Write(pababakDict[dictKey][n] + " ");
                        }
                        Console.WriteLine("\n집합B");
                        for (int n = 0; n < pababakDict[compareDictKey].Count; n++)
                        {
                            Console.Write(pababakDict[compareDictKey][n] + " ");
                        }
                        int jaccard = countNum / (pababakDict[dictKey].Count + pababakDict[compareDictKey].Count - countNum);
                        dictResult[dictKey].Add(new string[] { compareDictKey, jaccard .ToString() });
                    }
                }
            }
            return flag;
        }

        /*
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
                    if (tempList.Count > 1) pababakList.Add(tempList);
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
                    if (!ht.ContainsKey(int.Parse(pababakList[i][j]))) ht.Add(int.Parse(pababakList[i][j]), false);
                }

                for (int k = i + 1; k < pababakList.Count; k++)
                {
                    int countNum = 0;
                    for (int t = 0; t < pababakList[k].Count; t++)
                    {
                        if (ht.ContainsKey(int.Parse(pababakList[k][t])))
                        {
                            if (int.Parse(pababakList[k][t]) > 10 && !(Boolean)ht[int.Parse(pababakList[k][t])])
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
                        if (!dict.ContainsKey(i)) dict.Add(i, new List<int>());
                        Console.WriteLine("============경계 =============");
                        for (int z = 0; z < pababakList[i].Count; z++)
                        {
                            if ((Boolean)ht[int.Parse(pababakList[i][z])])
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
        */
    }
}
