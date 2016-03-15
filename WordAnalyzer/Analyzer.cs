using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WordAnalyzer
{
    public class Analyzer
    {
        /// <summary>
        /// Requests the Analyzer to analyze the input
        /// </summary>
        /// <param name="input"></param>
        public AnalysisResults Analyze(IEnumerable<string> input)
        {
            m_IWordCount = 0;
            m_ILongestWordLength = 0;
            m_MaxWordList = new List<string>();

            foreach (var val in input)
            {
                //System.Console.WriteLine(val);

                //Total World Count
                m_IWordCount++;

                //Longest word in the collection.
                if (val.Length > m_ILongestWordLength)
                    m_ILongestWordLength = val.Length;

                //Most occurance of the word
                if (m_MaxOccurenceDictionary.ContainsKey(val))
                {
                    m_MaxOccurenceDictionary[val] = m_MaxOccurenceDictionary[val] + 1;
                }
                else
                {
                    m_MaxOccurenceDictionary.Add(val, 1);
                }

                int iCount = 1;
                //find max count from m_MaxOccurenceDictionary
                foreach (var pair in m_MaxOccurenceDictionary)
                {
                    if (pair.Value > iCount)
                    {
                        m_MaxWordList.Clear();
                        iCount = pair.Value;
                        m_MaxWordList.Add(pair.Key);
                    }
                    else if (pair.Value == iCount)
                    {
                        m_MaxWordList.Add(pair.Key);
                    }

                }

            }
            return new AnalysisResults
            {
                LongestWordLength = m_ILongestWordLength,
                WordCount = m_IWordCount,
                MostCommonlyUsedWords = m_MaxWordList
            };
        }

        private int m_IWordCount;
        private int m_ILongestWordLength;
        private List<string> m_MaxWordList;
        private readonly Dictionary<string, int> m_MaxOccurenceDictionary = new Dictionary<string, int>();
    }
}
