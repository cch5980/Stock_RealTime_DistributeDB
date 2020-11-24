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
            int criteriaNum = 10;   // 파바박 기준점
            int cheNum = 10;        // 체결량이 10 미만인거는 제외
            Boolean flag = false;
            if (stock_che_list.Count < 1) return false;
            Dictionary<string, List<int>> pababakDict = new Dictionary<string, List<int>>();
            List<string[]> tempList = new List<string[]>(); // 체결량만 저장
            string che_time = stock_che_list[0][0];
            pababakDict.Add(che_time, new List<int>());
            // 1. 덩어리 만들기(시간 1초 동안 매수인 지점 찾기)
            for (int i = 1; i < stock_che_list.Count; i++)
            {
                if (stock_che_list[i][0] == che_time)
                {
                    if(int.Parse(stock_che_list[i][1]) > cheNum) pababakDict[che_time].Add(int.Parse(stock_che_list[i][1]));
                }
                else
                {
                    if (pababakDict[che_time].Count < criteriaNum) pababakDict.Remove(che_time);
                    che_time = stock_che_list[i][0];
                    pababakDict.Add(che_time, new List<int>());
                }
            }

            // 2. 덩어리들끼리 비교(해쉬)
            Dictionary<string, List<string[]>> dictResult = new Dictionary<string, List<string[]>>();
            for (int i = 0; i < pababakDict.Count - 1; i++)
            {
                Hashtable ht = new Hashtable();
                string dictKey = pababakDict.Keys.ToList()[i];
                if (pababakDict[dictKey].Count() < criteriaNum) continue;

                for (int j = 0; j < pababakDict[dictKey].Count(); j++)
                {
                    if (ht.ContainsKey(pababakDict[dictKey][j])) ht[pababakDict[dictKey][j]] = ((int)ht[pababakDict[dictKey][j]] + 1);
                    else ht.Add(pababakDict[dictKey][j], 1);
                }

                Hashtable copyHt = (Hashtable)ht.Clone();
                for (int k = i + 1; k < pababakDict.Count; k++)
                {
                    int countNum = 0;
                    string compareDictKey = pababakDict.Keys.ToList()[k];
                    for (int t = 0; t < pababakDict[compareDictKey].Count; t++)
                    {
                        if (copyHt.ContainsKey((int)pababakDict[compareDictKey][t]) && pababakDict[compareDictKey][t] > 10 && (int)copyHt[pababakDict[compareDictKey][t]] > 0)
                        {
                            countNum++;
                            copyHt[pababakDict[compareDictKey][t]] = ((int)copyHt[pababakDict[compareDictKey][t]] - 1);
                        }

                    }
                    // 3. 파바박 의심
                    if (countNum >= criteriaNum)
                    {
                        flag = true;
                        double jaccard = Math.Round((double)countNum * 100 / ((double)pababakDict[dictKey].Count + (double)pababakDict[compareDictKey].Count - (double)countNum));
                        if (!dictResult.ContainsKey(dictKey)) dictResult.Add(dictKey, new List<string[]>());
                        Console.WriteLine("===============경계=================");
                        Console.WriteLine("자카드 지수 : " + jaccard);
                        Console.WriteLine(dictKey +  " 시간의 집합");
                        pababakDict[dictKey].Sort();
                        for (int n = 0; n < pababakDict[dictKey].Count; n++)
                        {
                            Console.Write(pababakDict[dictKey][n] + " ");
                        }
                        Console.WriteLine("\n" + compareDictKey + " 시간의 집합");
                        pababakDict[compareDictKey].Sort();
                        for (int n = 0; n < pababakDict[compareDictKey].Count; n++)
                        {
                            Console.Write(pababakDict[compareDictKey][n] + " ");
                        }
                        Console.WriteLine();
                        dictResult[dictKey].Add(new string[] { compareDictKey, jaccard.ToString() });
                    }
                }
            }
            return flag;
        }
    }
}
