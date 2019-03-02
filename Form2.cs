using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_algorithm
{
    public partial class Form2 : Form
    {
        double time_common = 0;
        List<String> list_common = new List<string>();

        String s1 = "";
        String s2 = "";

        public Form2(String file1, String file2)
        {
            InitializeComponent();
            /*   this.AutoSize = false;
              this.AutoScroll = true;

              ScrollBar vScrollBar1 = new VScrollBar();
             vScrollBar1.Dock = DockStyle.Right;
              vScrollBar1.Scroll += (sender, e) => { this.VerticalScroll.Value = vScrollBar1.Value; };
              this.Controls.Add(vScrollBar1);*/
            s1 = file1;
            s2 = file2;

        }

        public void show()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<String> my_list = new List<string>();
            String path1 = s1;
            String path2 = s2;
            string common_text;




            Common_text obj = new Common_text();
            my_list = obj.put_common_sentences_inFile(path1, path2);

            list_common = my_list.Distinct().ToList();

            common_text = string.Join("", list_common.ToArray());
            textbox.Text = common_text;
            label1.Text = list_common.Count().ToString();
            stopwatch.Stop();
            time_common = stopwatch.Elapsed.TotalMinutes;


        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            show();
        }


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
            char[] delimiters = new char[] { '.' };
            string[] ss = myString.Split(delimiters, StringSplitOptions.None);
            foreach (String sen in ss) { sentences.Add(sen + '.'); }




            return sentences;
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

            List<String> osentence1 = new List<string>();
            List<String> osentence2 = new List<string>();


            List<String> sentence1 = new List<string>();
            List<String> sentence2 = new List<string>();
            List<String> merge_list = new List<string>();
            merge_list.Add("\n");
            merge_list.Add("\n");



            osentence1 = Common(s1);

            osentence2 = Common(s2);


            Dictionary<String, int> map = new Dictionary<string, int>();


            //   list_common = list_common.Distinct().ToList();
            sentence1 = osentence1.Distinct().ToList();
            sentence2 = osentence2.Distinct().ToList();

            for (int i = 0; i < list_common.Count(); i++)
            {
                map.Add(list_common[i], 0);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            if (sentence1.Count() >= sentence2.Count())
            {
                for (int i = 0; i < sentence2.Count(); i++)
                {
                    bool state1;
                    bool state2;
                    state1 = map.ContainsKey(sentence1[i]);
                    state2 = map.ContainsKey(sentence2[i]);


                    if (state1 == true && map[sentence1[i]] == 0)
                    {
                        map[sentence1[i]] = 1;
                        merge_list.Add(sentence1[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence1[i]);
                    }


                    if (state2 == true && map[sentence2[i]] == 0)
                    {
                        map[sentence2[i]] = 1;
                        merge_list.Add(sentence2[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence2[i]);
                    }


                }


                // int start = sentence1.Count() - sentence2.Count();

                for (int i = sentence2.Count(); i < sentence1.Count(); i++)
                {
                    bool state1;

                    state1 = map.ContainsKey(sentence1[i]);



                    if (state1 == true && map[sentence1[i]] == 0)
                    {
                        map[sentence1[i]] = 1;
                        merge_list.Add(sentence1[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence1[i]);
                    }
                }
            }
            else
            {
                bool state1;
                bool state2;
                for (int i = 0; i < sentence1.Count(); i++)
                {
                  
                    state1 = map.ContainsKey(sentence2[i]);
                    state2 = map.ContainsKey(sentence1[i]);


                    if (state1 == true && map[sentence2[i]] == 0)
                    {
                        map[sentence2[i]] = 1;
                        merge_list.Add(sentence2[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence2[i]);
                    }


                    if (state2 == true && map[sentence1[i]] == 0)
                    {
                        map[sentence1[i]] = 1;
                        merge_list.Add(sentence1[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence1[i]);
                    }


                }


                // int start = sentence1.Count() - sentence2.Count();

                for (int i = sentence1.Count(); i < sentence2.Count(); i++)
                {
                    

                    state1 = map.ContainsKey(sentence2[i]);



                    if (state1 == true && map[sentence2[i]] == 0)
                    {
                        map[sentence2[i]] = 1;
                        merge_list.Add(sentence2[i]);
                    }

                    else if (state1 == false)
                    {
                        merge_list.Add(sentence2[i]);
                    }
                }


            }

                stopwatch.Stop();
                double alltime = time_common + stopwatch.Elapsed.TotalMinutes;
                timelable.Text = alltime.ToString() + "  Miniute";
            

            String common_text = string.Join("", merge_list.ToArray());
            textbox.Text = common_text;


        }



        private void button3_Click_1(object sender, EventArgs e)
        {


            textbox.Text = "";
            List<string> file1 = new List<String>();
            file1 = Common(s1);
            String common_text = string.Join("", file1.ToArray());
            textbox.Text = common_text;

            String s;
            for (int i = 0; i < file1.Count(); i++)
            {


                if (list_common.Contains(file1[i]))
                {
                    int index = textbox.Text.IndexOf(file1[i]);
                    int legth = file1[i].Length;
                    textbox.Select(index, legth);
                    textbox.SelectionColor = Color.Red;



                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            textbox.Text = "";
            List<string> file1 = new List<String>();
            file1 = Common(s2);
            String common_text = string.Join("", file1.ToArray());
            textbox.Text = common_text;

            String s;
            for (int i = 0; i < file1.Count(); i++)
            {


                if (list_common.Contains(file1[i]))
                {
                    int index = textbox.Text.IndexOf(file1[i]);
                    int legth = file1[i].Length;
                    textbox.Select(index, legth);
                    textbox.SelectionColor = Color.Red;



                }

            }
        }
    }
}
