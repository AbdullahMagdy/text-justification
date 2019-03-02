using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace project_algorithm
{
    class Common_text
    {
        public static List<string> Common(String s)
        {

            /*
            var filePath = s;
            var sentences = new List<string>();
            using (TextReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();

                    if (line.Trim().EndsWith("."))
                    {
                        line.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                            .ForEach(l => sentences.Add(l.Trim() + "."));
                    }
                }
            }
            */
            List<String> sentences = new List<string>();
            System.IO.StreamReader myFile =
            new System.IO.StreamReader(s);
            String myString = myFile.ReadToEnd();
            char[] delimiters = new char[] {'.'};
            string[] ss = myString.Split(delimiters, StringSplitOptions.None);
            foreach (String sen in ss) { sentences.Add(sen+'.'); }

            


            return sentences;
        }


        public List<string> put_common_sentences_inFile(String path1, String path2)
        {
            List<string> sentences1 = new List<string>();
            List<string> sentences2 = new List<string>();
            List<string> sentences3 = new List<string>();

            String file1 =path1;
            String file2 = path2;

            StringBuilder builder = new StringBuilder();

            sentences1 = Common(file1);
            sentences2 = Common(file2);

            if (sentences1.Count <= sentences2.Count)
            {
                for (int i = 0; i < sentences1.Count; i++)
                {
                    for (int j = 0; j < sentences2.Count; j++)
                    {
                        if (sentences1[i] == sentences2[j])
                        {
                            sentences3.Add(sentences1[i]);
                            break;
                        }

                    }

                }
            }
            else
            {
                for (int i = 0; i < sentences2.Count; i++)
                {
                    for (int j = 0; j < sentences1.Count; j++)
                    {
                        if (sentences2[i] == sentences1[j])
                        {
                            sentences3.Add(sentences2[i]);
                            break;
                        }

                    }

                }
           

            }
            
         /*   List<string> sentences4 = new List<string>();
            for (int i = 0; i < sentences3.Count; i++)
            {
                if (sentences3[i] != "."||sentences3[i]=="")
                    sentences4.Add(sentences3[i]);


            }

*/



            return sentences3;

        }

       

    }
}
