using System.Collections.Generic;
using System.Linq;


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
            var listInput = input.ToList();   

            m_lstMaxWordOccurance = null;
            m_iwordCount = 0;
            m_iLongestWordInList = 0;

            //Total Word count in the list
            m_iwordCount = listInput.Any()? listInput.Count() : 0 ; 

            //Longest length word in the collection
            m_iLongestWordInList = listInput.Any()? listInput.Select(inputl => inputl.Length).Max() : 0; 

            // To Find the list of Max Occucarance of the word
            var results = from word in listInput
                            group word by word into newword
                            select newword;
            
            var finalwordlist = results.Any() ? results.Where(x => x.Count() == results.Max(c => c.Count())).Select(a => a.Key) : null;
            m_lstMaxWordOccurance = finalwordlist;            
            
            return new AnalysisResults()
            {
                WordCount = m_iwordCount,
                LongestWordLength = m_iLongestWordInList,
                MostCommonlyUsedWords = m_lstMaxWordOccurance
            };                
        }

        private int m_iwordCount;
        private int m_iLongestWordInList;
        private IEnumerable<string> m_lstMaxWordOccurance;
    }
}
