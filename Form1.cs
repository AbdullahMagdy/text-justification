using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_algorithm
{
    public partial class Form1 : Form
    {
        int width = 0;
        OpenFileDialog ob = new OpenFileDialog();

        String file1_after_justifiy = "";
        String file2_after_justifiy = "";

        public Form1()
        {
            InitializeComponent();
            //   this.VerticalScroll.Visible = true;
            this.AutoSize = false;
            this.AutoScroll = true;

            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender, e) => { this.VerticalScroll.Value = vScrollBar1.Value; };
            this.Controls.Add(vScrollBar1);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ob.ShowDialog();
            textBox1.Text = ob.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            width = Int32.Parse(textBox2.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {


            String path = textBox1.Text;


            double minimum_badness = 0;
            int number_lines = 0;
            int arr_size = 0;
            long[] arr_badness = new long[Int16.MaxValue];
            long[] arr_from_to = new long[Int16.MaxValue];


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TextJustification awl = new TextJustification();


            System.IO.StreamReader myFile =
            new System.IO.StreamReader(path);
            string myString = myFile.ReadToEnd();



            String[] words = myString.Split(' ');
            String text_justification = awl.justify(words, width, ref  minimum_badness, ref number_lines, ref arr_size);
            stopwatch.Stop();


            label1.Text = text_justification;

            String s1 = " # of lines = " + number_lines;
            String s2 = " Execution time = " + stopwatch.Elapsed + " SECONDS";
            String s3 = " The minimum obtained badness for the first word in the given file = " + minimum_badness.ToString();

            File.WriteAllText("E:/FCIS/3rd year/Algorithms/project/TestCases/after_justify/NF.txt", label1.Text);
            using (StreamWriter writer = new StreamWriter("E:/FCIS/3rd year/Algorithms/project/TestCases/after_justify/_Output.txt"))
            {
                writer.WriteLine(s1);
                writer.WriteLine(s2);
                writer.WriteLine(s3);
                /*    writer.WriteLine("--From Word -- To Word -- Min badness");
                    for (int i = 0; i < arr_size; i++)
                    {
                        writer.Write("      " + i + "          " + arr_from_to[i] + "            " + arr_badness[i]);
                        writer.WriteLine("");

                    }
                    */

            }

            file1_after_justifiy = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = "";


        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            String path = textBox1.Text;

            double minimum_badness = 0;
            int number_lines = 0;
            int arr_size = 0;
            long[] arr_badness = new long[Int16.MaxValue];
            long[] arr_from_to = new long[Int16.MaxValue];


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            TextJustification awl = new TextJustification();


            System.IO.StreamReader myFile =
            new System.IO.StreamReader(path);
            string myString = myFile.ReadToEnd();

            string[] ss = myString.Split('.');
            IList<String> my_list = ss;
            double[] array_hold_badness = new double[my_list.Count()];
            int y = 0;

            for (int i = 0; i < my_list.Count(); i++)
            {
                my_list[i] += '.';
            }


            int alllines = 0;
            String display = "";
            using (StreamWriter writer = new StreamWriter("E:/FCIS/3rd year/Algorithms/project/TestCases/after_justify/_Output.txt"))
            {
                for (int i = 0; i < my_list.Count(); i++)
                {
                    String string1 = my_list[i];
                    string[] words = string1.Split(' ');
                    String text_justification = awl.justify(words, width, ref  minimum_badness, ref number_lines, ref arr_size);
                    array_hold_badness[y] = minimum_badness;
                    display += text_justification;
                    y++;
                    alllines += number_lines;
                    /*     writer.WriteLine("--From Word -- To Word -- Min badness");
                         for (int x = 0; x < arr_size; x++)
                         {
                             writer.Write("      " + x + "          " + arr_from_to[x] + "            " + arr_badness[x]);
                             writer.WriteLine("");

                         }*/
                }



                stopwatch.Stop();

                double total_min_badness = 0;
                for (int i = 0; i < array_hold_badness.Count(); i++)
                {
                    total_min_badness += array_hold_badness[i];
                }


                label1.Text = display;
                Array.Sort(array_hold_badness);


                String s1 = " # of lines = " + alllines;
                String s2 = " Execution time = " + stopwatch.Elapsed + " SECONDS";
                String s3 = " The minimum obtained badness for the first word in the given file = " + total_min_badness.ToString();

                File.WriteAllText("D:/project/Samples/after_justifiy/NF4.txt", label1.Text);

                writer.WriteLine(s1);
                writer.WriteLine(s2);
                writer.WriteLine(s3);




            }



        }

        private void button5_Click(object sender, EventArgs e)
        {


            label1.Text = "";
            String path = textBox1.Text;

            double minimum_badness = 0;
            int number_lines = 0;
            int arr_size = 0;
            long[] arr_badness = new long[Int16.MaxValue];
            long[] arr_from_to = new long[Int16.MaxValue];


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TextJustification awl = new TextJustification();


            System.IO.StreamReader myFile =
            new System.IO.StreamReader(path);
            string myString = myFile.ReadToEnd();

            string[] words = myString.Split(' ');
            String text_justification = awl.justify(words, width, ref  minimum_badness, ref number_lines, ref arr_size);
            stopwatch.Stop();


            label1.Text = text_justification;

            String s1 = " # of lines = " + number_lines;
            String s2 = " Execution time = " + stopwatch.Elapsed + " SECONDS";
            String s3 = " The minimum obtained badness for the first word in the given file = " + minimum_badness.ToString();

            File.WriteAllText("D:/project/Samples/after_justifiy/NF.txt", label1.Text);
            using (StreamWriter writer = new StreamWriter("D:/project/Samples/after_justifiy/_Output.txt"))
            {
                writer.WriteLine(s1);
                writer.WriteLine(s2);
                writer.WriteLine(s3);
                /*  writer.WriteLine("--From Word -- To Word -- Min badness");
                  for (int i = 0; i < arr_size; i++)
                  {
                      writer.Write("      " + i + "          " + arr_from_to[i] + "            " + arr_badness[i]);
                      writer.WriteLine("");

                  }
                  */

            }

            file2_after_justifiy = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2(file1_after_justifiy, file2_after_justifiy);
            obj.Visible = true;

        }
    }
}
