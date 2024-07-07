using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO.Enumeration;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        Cell[] Cells = new Cell[64];
        //elem 
        Elem[] Elemek = new Elem[10];





        Pen myPen = new Pen(Brushes.Black, 1);
        Pen DeletePen = new Pen(Brushes.White, 1);


        int temporary = 0;
        int up = 0;
        int right = 0;
        int down = 0;
        int left = 0;
        int VarElse = 0;
        int LastVisited = 0;

        int[] possibility = { };

        int[] tempneighbor;
        bool Visited;
        int current = 0;
        int BinaryTree = 0;
        int entropy = 0;  //wave function collapse var
        int pick = 0;
        int[] valaszthato = new int[55];

        int experimental = 1; //experimental featurek engedélyezése

        //for selectmode 5
        int elso = 0;
        int masodik = 0;
        int harmadik = 0;
        int negyedik = 0;
        List<int> Steps = new List<int>();

        List<int> Backtracking = new List<int>();

        List<int> FinalSteps = new List<int>();
        string FinalResult = "";

        public void Form1_Load_1(object sender, EventArgs e)
        {





        }

        public void button2_Click(object sender, EventArgs e)
        {




            //reset
            temporary = 0;
            current = 0;
            BinaryTree = 0;
            up = 0;
            right = 0;
            down = 0;
            left = 0;
            VarElse = 0;
            LastVisited = 0;


            Graphics gr = panel1.CreateGraphics();
            int szamlal = 0;
            int temp = 0;






            /*
            0 0 50 0
            50 0 50 50
            50 50 0 50
            0 50 0 0

            
             
            */

            /*
            */
            float xtop = 0; //50
            float ytop = 0; //50
            float x2top = 50; //100
            float y2top = 0; //50

            float xright = 50; //100
            float yright = 0; //50
            float x2right = 50; //100
            float y2right = 50; //100

            float xbottom = 50; //100
            float ybottom = 50; //100
            float x2bottom = 0; // 50
            float y2bottom = 50; //100

            float xleft = 0;  //50
            float yleft = 50; //100
            float x2left = 0; //50
            float y2left = 0; //50


            int lefele = 6;
            int vizszint = 7;

            for (int c = 0; c <= lefele; c++)
            {
                for (int r = 0; r <= vizszint; r++)
                {


                    if (temp == 0)
                    {
                        Cells[szamlal] = new Cell(xtop, ytop, x2top, y2top, xright, yright,
                        x2right, y2right, xbottom, ybottom, x2bottom, y2bottom, xleft, yleft, x2left, y2left);
                        temp += 1;
                    };
                    xtop += 50;
                    ytop += 0;
                    x2top += 50;
                    y2top += 0;

                    xright += 50;
                    yright += 0;
                    x2right += 50;
                    y2right += 0;

                    xbottom += 50;
                    ybottom += 0;
                    x2bottom += 50;
                    y2bottom += 0;

                    xleft += 50;
                    yleft += 0;
                    x2left += 50;
                    y2left += 0;
                    Cells[szamlal] = new Cell(xtop, ytop, x2top, y2top, xright, yright,
                        x2right, y2right, xbottom, ybottom, x2bottom, y2bottom, xleft, yleft, x2left, y2left);
                    szamlal++;


                }
                xtop = 0;
                ytop += 50;
                x2top = 50;
                y2top += 50;

                xright = 50;
                yright += 50;
                x2right = 50;
                y2right += 50;

                xbottom = 50;
                ybottom += 50;
                x2bottom = 0;
                y2bottom += 50;

                xleft = 0;
                yleft += 50;
                x2left = 0;
                y2left += 50;
            }
            //Cells[0] = new Cell(false, false, false, false, false);






            {
                // [0]
                // [horizont] alkalommal 70
                // majd [horizont] alkalom után 1,2,3,4,5...
                // ((horizont * vertical) - horizont ) alkalom után (horizont alkalommal 70)

                //[1]
                // minden horizontonként 70, amúgy meg számoljon 1től

                //[2]
                //kezdjen számolni [horizonttól], majd ((horizont * vertical) - horizont ) számolás után, a maradék legyen 70. (azaz az utolsó horizontális sor)

                //[3]
                // kezdődjön 70-el, majd számoljon 0tól, és minden horizont alkalommal 70

                for (int r = 0; r <= 55; r++)
                {

                    Cells[r].entropy = 3;
                    Cells[r].Family = r;
                    Cells[r].Cvisited = false;


                }

                {
                    Cells[0].Neighbour[0] = 70;
                    Cells[0].Neighbour[1] = 1;
                    Cells[0].Neighbour[2] = 8;
                    Cells[0].Neighbour[3] = 70;

                    Cells[1].Neighbour[0] = 70;
                    Cells[1].Neighbour[1] = 2;
                    Cells[1].Neighbour[2] = 9;
                    Cells[1].Neighbour[3] = 0;

                    Cells[2].Neighbour[0] = 70;
                    Cells[2].Neighbour[1] = 3;
                    Cells[2].Neighbour[2] = 10;
                    Cells[2].Neighbour[3] = 1;

                    Cells[3].Neighbour[0] = 70;
                    Cells[3].Neighbour[1] = 4;
                    Cells[3].Neighbour[2] = 11;
                    Cells[3].Neighbour[3] = 2;

                    Cells[4].Neighbour[0] = 70;
                    Cells[4].Neighbour[1] = 5;
                    Cells[4].Neighbour[2] = 12;
                    Cells[4].Neighbour[3] = 3;

                    Cells[5].Neighbour[0] = 70;
                    Cells[5].Neighbour[1] = 6;
                    Cells[5].Neighbour[2] = 13;
                    Cells[5].Neighbour[3] = 4;

                    Cells[6].Neighbour[0] = 70;
                    Cells[6].Neighbour[1] = 7;
                    Cells[6].Neighbour[2] = 14;
                    Cells[6].Neighbour[3] = 5;

                    Cells[7].Neighbour[0] = 70;
                    Cells[7].Neighbour[1] = 70;
                    Cells[7].Neighbour[2] = 15;
                    Cells[7].Neighbour[3] = 6;

                    Cells[8].Neighbour[0] = 0;
                    Cells[8].Neighbour[1] = 9;
                    Cells[8].Neighbour[2] = 16;
                    Cells[8].Neighbour[3] = 70;

                    Cells[9].Neighbour[0] = 1;
                    Cells[9].Neighbour[1] = 10;
                    Cells[9].Neighbour[2] = 17;
                    Cells[9].Neighbour[3] = 8;

                    Cells[10].Neighbour[0] = 2;
                    Cells[10].Neighbour[1] = 11;
                    Cells[10].Neighbour[2] = 18;
                    Cells[10].Neighbour[3] = 9;

                    Cells[11].Neighbour[0] = 3;
                    Cells[11].Neighbour[1] = 12;
                    Cells[11].Neighbour[2] = 19;
                    Cells[11].Neighbour[3] = 10;

                    Cells[12].Neighbour[0] = 4;
                    Cells[12].Neighbour[1] = 13;
                    Cells[12].Neighbour[2] = 20;
                    Cells[12].Neighbour[3] = 11;

                    Cells[13].Neighbour[0] = 5;
                    Cells[13].Neighbour[1] = 14;
                    Cells[13].Neighbour[2] = 21;
                    Cells[13].Neighbour[3] = 12;

                    Cells[14].Neighbour[0] = 6;
                    Cells[14].Neighbour[1] = 15;
                    Cells[14].Neighbour[2] = 22;
                    Cells[14].Neighbour[3] = 13;

                    Cells[15].Neighbour[0] = 7;
                    Cells[15].Neighbour[1] = 70;
                    Cells[15].Neighbour[2] = 23;
                    Cells[15].Neighbour[3] = 14;

                    Cells[16].Neighbour[0] = 8;
                    Cells[16].Neighbour[1] = 17;
                    Cells[16].Neighbour[2] = 24;
                    Cells[16].Neighbour[3] = 70;

                    Cells[17].Neighbour[0] = 9;
                    Cells[17].Neighbour[1] = 18;
                    Cells[17].Neighbour[2] = 25;
                    Cells[17].Neighbour[3] = 16;

                    Cells[18].Neighbour[0] = 10;
                    Cells[18].Neighbour[1] = 19;
                    Cells[18].Neighbour[2] = 26;
                    Cells[18].Neighbour[3] = 17;

                    Cells[19].Neighbour[0] = 11;
                    Cells[19].Neighbour[1] = 20;
                    Cells[19].Neighbour[2] = 27;
                    Cells[19].Neighbour[3] = 18;

                    Cells[20].Neighbour[0] = 12;
                    Cells[20].Neighbour[1] = 21;
                    Cells[20].Neighbour[2] = 28;
                    Cells[20].Neighbour[3] = 19;

                    Cells[21].Neighbour[0] = 13;
                    Cells[21].Neighbour[1] = 22;
                    Cells[21].Neighbour[2] = 29;
                    Cells[21].Neighbour[3] = 20;

                    Cells[22].Neighbour[0] = 14;
                    Cells[22].Neighbour[1] = 23;
                    Cells[22].Neighbour[2] = 30;
                    Cells[22].Neighbour[3] = 21;

                    Cells[23].Neighbour[0] = 15;
                    Cells[23].Neighbour[1] = 70;
                    Cells[23].Neighbour[2] = 31;
                    Cells[23].Neighbour[3] = 22;

                    Cells[24].Neighbour[0] = 16;
                    Cells[24].Neighbour[1] = 25;
                    Cells[24].Neighbour[2] = 32;
                    Cells[24].Neighbour[3] = 70;

                    Cells[25].Neighbour[0] = 17;
                    Cells[25].Neighbour[1] = 26;
                    Cells[25].Neighbour[2] = 33;
                    Cells[25].Neighbour[3] = 24;


                    Cells[26].Neighbour[0] = 18;
                    Cells[26].Neighbour[1] = 27;
                    Cells[26].Neighbour[2] = 34;
                    Cells[26].Neighbour[3] = 25;

                    Cells[27].Neighbour[0] = 19;
                    Cells[27].Neighbour[1] = 28;
                    Cells[27].Neighbour[2] = 35;
                    Cells[27].Neighbour[3] = 26;

                    Cells[28].Neighbour[0] = 20;
                    Cells[28].Neighbour[1] = 29;
                    Cells[28].Neighbour[2] = 36;
                    Cells[28].Neighbour[3] = 27;

                    Cells[29].Neighbour[0] = 21;
                    Cells[29].Neighbour[1] = 30;
                    Cells[29].Neighbour[2] = 37;
                    Cells[29].Neighbour[3] = 28;

                    Cells[30].Neighbour[0] = 22;
                    Cells[30].Neighbour[1] = 31;
                    Cells[30].Neighbour[2] = 38;
                    Cells[30].Neighbour[3] = 29;

                    Cells[31].Neighbour[0] = 23;
                    Cells[31].Neighbour[1] = 70;
                    Cells[31].Neighbour[2] = 39;
                    Cells[31].Neighbour[3] = 30;

                    Cells[32].Neighbour[0] = 24;
                    Cells[32].Neighbour[1] = 33;
                    Cells[32].Neighbour[2] = 40;
                    Cells[32].Neighbour[3] = 70;

                    Cells[33].Neighbour[0] = 25;
                    Cells[33].Neighbour[1] = 34;
                    Cells[33].Neighbour[2] = 41;
                    Cells[33].Neighbour[3] = 32;

                    Cells[34].Neighbour[0] = 26;
                    Cells[34].Neighbour[1] = 35;
                    Cells[34].Neighbour[2] = 42;
                    Cells[34].Neighbour[3] = 33;

                    Cells[35].Neighbour[0] = 27;
                    Cells[35].Neighbour[1] = 36;
                    Cells[35].Neighbour[2] = 43;
                    Cells[35].Neighbour[3] = 34;

                    Cells[36].Neighbour[0] = 28;
                    Cells[36].Neighbour[1] = 37;
                    Cells[36].Neighbour[2] = 44;
                    Cells[36].Neighbour[3] = 35;

                    Cells[37].Neighbour[0] = 29;
                    Cells[37].Neighbour[1] = 38;
                    Cells[37].Neighbour[2] = 45;
                    Cells[37].Neighbour[3] = 36;

                    Cells[38].Neighbour[0] = 30;
                    Cells[38].Neighbour[1] = 39;
                    Cells[38].Neighbour[2] = 46;
                    Cells[38].Neighbour[3] = 37;

                    Cells[39].Neighbour[0] = 31;
                    Cells[39].Neighbour[1] = 70;
                    Cells[39].Neighbour[2] = 47;
                    Cells[39].Neighbour[3] = 38;

                    Cells[40].Neighbour[0] = 32;
                    Cells[40].Neighbour[1] = 41;
                    Cells[40].Neighbour[2] = 48;
                    Cells[40].Neighbour[3] = 70;

                    Cells[41].Neighbour[0] = 33;
                    Cells[41].Neighbour[1] = 42;
                    Cells[41].Neighbour[2] = 49;
                    Cells[41].Neighbour[3] = 40;

                    Cells[42].Neighbour[0] = 34;
                    Cells[42].Neighbour[1] = 43;
                    Cells[42].Neighbour[2] = 50;
                    Cells[42].Neighbour[3] = 41;

                    Cells[43].Neighbour[0] = 35;
                    Cells[43].Neighbour[1] = 44;
                    Cells[43].Neighbour[2] = 51;
                    Cells[43].Neighbour[3] = 42;

                    Cells[44].Neighbour[0] = 36;
                    Cells[44].Neighbour[1] = 45;
                    Cells[44].Neighbour[2] = 52;
                    Cells[44].Neighbour[3] = 43;

                    Cells[45].Neighbour[0] = 37;
                    Cells[45].Neighbour[1] = 46;
                    Cells[45].Neighbour[2] = 53;
                    Cells[45].Neighbour[3] = 44;

                    Cells[46].Neighbour[0] = 38;
                    Cells[46].Neighbour[1] = 47;
                    Cells[46].Neighbour[2] = 54;
                    Cells[46].Neighbour[3] = 45;

                    Cells[47].Neighbour[0] = 39;
                    Cells[47].Neighbour[1] = 70;
                    Cells[47].Neighbour[2] = 55;
                    Cells[47].Neighbour[3] = 46;

                    Cells[48].Neighbour[0] = 40;
                    Cells[48].Neighbour[1] = 49;
                    Cells[48].Neighbour[2] = 70;
                    Cells[48].Neighbour[3] = 70;

                    Cells[49].Neighbour[0] = 41;
                    Cells[49].Neighbour[1] = 50;
                    Cells[49].Neighbour[2] = 70;
                    Cells[49].Neighbour[3] = 48;

                    Cells[50].Neighbour[0] = 42;
                    Cells[50].Neighbour[1] = 51;
                    Cells[50].Neighbour[2] = 70;
                    Cells[50].Neighbour[3] = 49;

                    Cells[51].Neighbour[0] = 43;
                    Cells[51].Neighbour[1] = 52;
                    Cells[51].Neighbour[2] = 70;
                    Cells[51].Neighbour[3] = 50;

                    Cells[52].Neighbour[0] = 44;
                    Cells[52].Neighbour[1] = 53;
                    Cells[52].Neighbour[2] = 70;
                    Cells[52].Neighbour[3] = 51;

                    Cells[53].Neighbour[0] = 45;
                    Cells[53].Neighbour[1] = 54;
                    Cells[53].Neighbour[2] = 70;
                    Cells[53].Neighbour[3] = 52;

                    Cells[54].Neighbour[0] = 46;
                    Cells[54].Neighbour[1] = 55;
                    Cells[54].Neighbour[2] = 70;
                    Cells[54].Neighbour[3] = 53;

                    Cells[55].Neighbour[0] = 47;
                    Cells[55].Neighbour[1] = 70;
                    Cells[55].Neighbour[2] = 70;
                    Cells[55].Neighbour[3] = 54;
                }
            }

            if (comboBox1.SelectedIndex + 1 != 8)
            {

                for (int r = 0; r <= 55; r++)
                {
                    if (r == 1 || r == 2 || r == 3 || r == 4 || r == 5 || r == 6 || r == 8 || r == 15 || r == 16 || r == 23 || r == 24 || r == 31 || r == 32 || r == 39 || r == 40 || r == 47 || r == 49 || r == 50 || r == 51 || r == 52 || r == 53 || r == 54)
                    {
                        Cells[r].Neighbours = 3;
                    }
                }
                for (int r = 0; r <= 55; r++)
                {
                    if (r == 0 || r == 7 || r == 48 || r == 55)
                    {
                        Cells[r].Neighbours = 2;
                    }
                }
                for (int r = 0; r <= 55; r++)
                    if (r == 9 || r == 10 || r == 11 || r == 12 || r == 13 || r == 14 || r == 17 || r == 18 || r == 19 || r == 20 || r == 21 || r == 22 || r == 25 || r == 26 || r == 27 || r == 28 || r == 29 || r == 30 || r == 33 || r == 34 || r == 35 || r == 36 || r == 37 || r == 38 || r == 41 || r == 42 || r == 43 || r == 44 || r == 45 || r == 46)
                    {
                        Cells[r].Neighbours = 4;
                    }
                for (int r = 0; r <= 55; r++)
                {
                    Cells[r].pos = r;
                    gr.DrawLine(myPen, Cells[r].xtop, Cells[r].ytop, Cells[r].x2top, Cells[r].y2top);
                    gr.DrawLine(myPen, Cells[r].xright, Cells[r].yright, Cells[r].x2right, Cells[r].y2right);
                    gr.DrawLine(myPen, Cells[r].xbottom, Cells[r].ybottom, Cells[r].x2bottom, Cells[r].y2bottom);
                    gr.DrawLine(myPen, Cells[r].xleft, Cells[r].yleft, Cells[r].x2left, Cells[r].y2left);


                }

            }


            Pen SolutionPen = new Pen(Brushes.Green, 2);
            //desolution pen declar

            Pen DeSolutionPen = new Pen(Brushes.White, 2);
            //de-rajzol (de-solution)
            if (FinalSteps.Count > 0)
            {


                gr.DrawLine(DeSolutionPen, Cells[FinalSteps[0]].xleft, Cells[FinalSteps[0]].yleft - 25, Cells[FinalSteps[0]].x2left + 25, Cells[FinalSteps[0]].y2left + 25);
                for (int i = 0; i < FinalSteps.Count - 1; i++)
                {
                    //jobbra
                    if (FinalSteps[i] + 1 == FinalSteps[i + 1])
                    {
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i]].xright, Cells[FinalSteps[i]].yright + 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i + 1]].xleft, Cells[FinalSteps[i + 1]].yleft - 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                    }
                    //balra
                    if (FinalSteps[i] - 1 == FinalSteps[i + 1])
                    {
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i + 1]].xright, Cells[FinalSteps[i + 1]].yright + 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i]].xleft, Cells[FinalSteps[i]].yleft - 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                    }

                    //fentre
                    if (FinalSteps[i] - 8 == FinalSteps[i + 1])
                    {
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i]].xtop + 25, Cells[FinalSteps[i]].ytop, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i + 1]].xbottom - 25, Cells[FinalSteps[i + 1]].ybottom, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                    }

                    //lentre
                    if (FinalSteps[i] + 8 == FinalSteps[i + 1])
                    {
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i + 1]].xtop + 25, Cells[FinalSteps[i + 1]].ytop, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        gr.DrawLine(DeSolutionPen, Cells[FinalSteps[i]].xbottom - 25, Cells[FinalSteps[i]].ybottom, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                    }



                    //gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xtop + 20, Cells[FinalSteps[i]].ytop + 20, Cells[FinalSteps[i]].x2top - 20, Cells[FinalSteps[i]].y2top + 10);
                    FinalResult = FinalResult + Steps[i] + ",";
                }
                gr.DrawLine(DeSolutionPen, Cells[FinalSteps[FinalSteps.Count - 1]].xright, Cells[FinalSteps[FinalSteps.Count - 1]].yright + 25, Cells[FinalSteps[FinalSteps.Count - 1]].x2left + 25, Cells[FinalSteps[FinalSteps.Count - 1]].y2left + 25);
            }

            FinalSteps.Clear();
            Steps.Clear();
            Backtracking.Clear();

            //kiválasztjuk melyik algoritmust szeretnénk futtatni
            int SelectMode = comboBox1.SelectedIndex + 1;
            int SolutionSelectMode = comboBox2.SelectedIndex + 1;
            int SlowMode = comboBox3.SelectedIndex + 1;


            var random = new Random();
            //startpoint

            int[] SelectableStart = new int[7] { 0, 8, 16, 24, 32, 40, 48 };
            int StartPoint;
            StartPoint = SelectableStart[random.Next(0, SelectableStart.Length)];

            //exitpoint

            int[] SelectableExit = new int[7] { 7, 15, 23, 31, 39, 47, 55 };
            int ExitPoint = SelectableExit[random.Next(0, SelectableExit.Length)];

            Cells[0].Visited = true;
            

            //70,1,8,70
            //selectmode1 = aldous broder algorithm
            //selectmode2 = hunt and kill
            //selectmode3 = binary tree
            //selectmode4 = test
            if (SelectMode == 1) //aldous broder
            {
                //lépések
                label12.Text = "1 - Választunk egy véletlenszerű pontot a labirintusban. ";
                label13.Text = "2 - Kiválasztunk egy szomszédos cellát, és ha ez a cella az előzőekben nem volt \nlátogatva, akkor összekötjük a kettő cellát. ";
                label14.Text = "3 - Ismételjük az előző kettő lépést, amíg az összes cellát meg nem látogatjuk.";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("Egyszerű algoritmus, amely véletlenszerűen választ útvonalat.");


                //hátrányok
                label10.Text = Convert.ToString("Nem optimális, mivel véletlenszerűen járjuk be a labirintust, \namelynek a futási ideje nagyon magas is lehet.");

                while (temporary < 55)
                {
                    tempneighbor = Cells[current].Neighbour;
                    if (tempneighbor[0] < 70)
                    {
                        up = tempneighbor[0];
                    }
                    //checks right
                    if (tempneighbor[1] < 70)
                    {
                        right = tempneighbor[1];
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70)
                    {
                        down = tempneighbor[2];
                    }
                    //checks left
                    if (tempneighbor[3] < 70)
                    {
                        left = tempneighbor[3];
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    //test


                    current = randomValue;
                    //rombol 
                    if (Cells[current].Visited == false)
                    {

                        if (Cells[current].pos - 1 == Cells[LastVisited].pos)
                        {
                            //rombol bal
                            gr.DrawLine(DeletePen, Cells[current].xleft,
                                Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                            Cells[current].Left = false;
                            Cells[LastVisited].Right = false;

                        } //rombol bal
                        if (Cells[current].pos + 1 == Cells[LastVisited].pos)
                        {
                            //rombol jobb
                            gr.DrawLine(DeletePen, Cells[current].xright,
                                Cells[current].yright, Cells[current].x2right, Cells[current].y2right);
                            Cells[current].Right = false;
                            Cells[LastVisited].Left = false;

                        } //rombol jobb
                        if (Cells[current].pos - 8 == Cells[LastVisited].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop,
                                Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                            Cells[current].Top = false;
                            Cells[LastVisited].Bottom = false;

                        } //rombol fent
                        if (Cells[current].pos + 8 == Cells[LastVisited].pos)
                        {
                            //rombol alul

                            gr.DrawLine(DeletePen, Cells[current].xbottom,
                                Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);
                            Cells[current].Bottom = false;
                            Cells[LastVisited].Top = false;
                        } //rombol alul

                        Cells[current].Visited = true;
                        temporary++;
                    }
                    LastVisited = Cells[current].pos;

                    //wait

                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }




                }

                //test section





            }
            if (SelectMode == 2) //hunt and kill
            {
                //lépések
                label12.Text = "1 - Kiválasztjuk a kezdő cella pozícióját, majd ebből haladunk egy olyan \nszomszédos cellába, amely még nem volt látogatva. Ezt a lépést egész addig \nfolytatjuk, amíg egy zsákutcába nem jutunk.";
                label13.Text = "2 - A labirintusban egy olyan pozíciót keresünk, amely még nem látogatott, \nviszont van egy olyan szomszédja, amely már látogatott. Amint találunk \negy ilyen pozíciót, akkor a látogatott szomszédja között leromboljuk a falat, \nmajd ezt a cellát beállítjuk az új kezdő pozíciónak és visszatérünk az első lépéshez.";
                label14.Text = "";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("Viszonylag gyors algoritmus más algoritmusokhoz képest.");


                //hátrányok
                label10.Text = Convert.ToString("Előítélettel dolgozik a hunt programrész alatt.");

                //algoritmus 2 (hunt and kill)

                Cells[0].Visited = true;
            StartPosition:



                while (temporary < 55)
                {
                    //Thread.Sleep(100);
                    VarElse = 0;
                    up = 0;
                    right = 0;
                    down = 0;
                    left = 0;


                    tempneighbor = Cells[current].Neighbour;

                    if (tempneighbor[0] < 70)
                    {

                        if (Cells[tempneighbor[0]].Visited == false)
                        {
                            up = tempneighbor[0];
                            VarElse++;
                        }
                    }
                    //checks right
                    if (tempneighbor[1] < 70)
                    {

                        if (Cells[tempneighbor[1]].Visited == false)
                        {
                            right = tempneighbor[1];
                            VarElse++;
                        }
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70)
                    {

                        if (Cells[tempneighbor[2]].Visited == false)
                        {
                            down = tempneighbor[2];
                            VarElse++;
                        }
                    }
                    //checks left
                    if (tempneighbor[3] < 70)
                    {

                        if (Cells[tempneighbor[3]].Visited == false)
                        {
                            left = tempneighbor[3];
                            VarElse++;
                        }
                    }

                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }

                    if (VarElse == 0) //zsákutca
                    {
                        int HuntVar = 0;
                        int[] HuntSzomszed;
                        //hunt and kill///////////////////////// 

                        while (HuntVar < 55)
                        {
                            HuntSzomszed = Cells[HuntVar].Neighbour;
                            //valid-e
                            if (HuntSzomszed[0] < 70)
                            {
                                //nem visited + terget cell (ami adjascent) az már visited volt-->


                                if (Cells[HuntVar].Visited == false && Cells[HuntSzomszed[0]].Visited == true)
                                {
                                    current = HuntVar;
                                    gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                                    Cells[current].Top = false;
                                    Cells[HuntSzomszed[0]].Bottom = false;
                                    Cells[current].Visited = true;
                                    temporary++;
                                    LastVisited = Cells[current].pos;

                                    goto StartPosition;

                                }
                            }







                            //checks right
                            if (HuntSzomszed[1] < 70)
                            {

                                if (Cells[HuntVar].Visited == false && Cells[HuntSzomszed[1]].Visited == true)
                                {
                                    current = HuntVar;
                                    gr.DrawLine(DeletePen, Cells[current].xright, Cells[current].yright, Cells[current].x2right, Cells[current].y2right);
                                    Cells[current].Right = false;
                                    Cells[HuntSzomszed[1]].Left = false;
                                    Cells[current].Visited = true;
                                    temporary++;
                                    LastVisited = Cells[current].pos;

                                    goto StartPosition;

                                }
                            }
                            //checks bottom
                            if (HuntSzomszed[2] < 70)
                            {
                                if (Cells[HuntVar].Visited == false && Cells[HuntSzomszed[2]].Visited == true)
                                {
                                    current = HuntVar;
                                    gr.DrawLine(DeletePen, Cells[current].xbottom, Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);
                                    Cells[current].Bottom = false;
                                    Cells[HuntSzomszed[2]].Top = false;
                                    Cells[current].Visited = true;
                                    temporary++;
                                    LastVisited = Cells[current].pos;

                                    goto StartPosition;

                                }
                            }
                            //checks left
                            if (HuntSzomszed[3] < 70)
                            {
                                if (Cells[HuntVar].Visited == false && Cells[HuntSzomszed[3]].Visited == true)
                                {
                                    current = HuntVar;
                                    gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                                    Cells[current].Left = false;
                                    Cells[HuntSzomszed[3]].Right = false;
                                    Cells[current].Visited = true;
                                    temporary++;
                                    LastVisited = Cells[current].pos;

                                    goto StartPosition;

                                }
                            }
                            HuntVar++; //maybe something here?


                        }
                    }
                    else

                    {
                        VarElse = 0;
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    //test


                    current = randomValue;
                    //rombol 
                    if (Cells[current].Visited == false)
                    {


                        if (Cells[current].pos - 1 == Cells[LastVisited].pos)
                        {
                            //rombol bal
                            gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                            Cells[current].Left = false;
                            Cells[LastVisited].Right = false;
                        }
                        else if (Cells[current].pos + 1 == Cells[LastVisited].pos)
                        {
                            //rombol jobb
                            gr.DrawLine(DeletePen, Cells[current].xright, Cells[current].yright, Cells[current].x2right, Cells[current].y2right);
                            Cells[current].Right = false;
                            Cells[LastVisited].Left = false;
                        }
                        else if (Cells[current].pos - 8 == Cells[LastVisited].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                            Cells[current].Top = false;
                            Cells[LastVisited].Bottom = false;
                        }
                        else if (Cells[current].pos + 8 == Cells[LastVisited].pos)
                        {
                            //rombol alul

                            gr.DrawLine(DeletePen, Cells[current].xbottom, Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);
                            Cells[current].Bottom = false;
                            Cells[LastVisited].Top = false;
                        }

                        Cells[current].Visited = true;
                        temporary++;
                    }
                    LastVisited = Cells[current].pos;


                }



            }
            if (SelectMode == 3) //binary tree
            {
                //lépések
                label12.Text = "1 - Kiválasztunk egy cellát, majd leromboljuk vagy az alsó, vagy  a jobb oldali falát.";
                label13.Text = "2 - Ezt a lépést ismételjük, amíg az összes cellát meg nem látogattuk.";
                label14.Text = "";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("A szomszédos cellák állapotát nem kell tudnia.");


                //hátrányok
                label10.Text = Convert.ToString("Nagyon egyszerű/primitív, ezáltal túlságosan felismerhető. Előítélettel \ndolgozik (jelen esetben, alsó és jobb oldali), ez által az utolsó sor mindig üres lesz.");
                while (temporary < 55)
                {
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }


                    right = 0;
                    down = 0;
                    VarElse = 0;
                    //bias : south, east
                    {
                        tempneighbor = Cells[BinaryTree].Neighbour;

                        //checks right
                        if (tempneighbor[1] < 70)
                        {
                            right = tempneighbor[1];
                            VarElse++;
                        }
                        //checks bottom
                        if (tempneighbor[2] < 70)
                        {
                            down = tempneighbor[2];
                            VarElse++;
                        }
                        if (VarElse == 0)
                        {

                            break;
                        }


                        //random kiválasztom hogy melyiket rombolom le


                        int[] selectableInts = new int[4] { up, right, down, left };
                        int randomValue = 0;
                        while (randomValue <= 0)
                        {
                            randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                        }

                        current = randomValue;
                        //rombol 




                        if (Cells[current].pos - 1 == Cells[BinaryTree].pos)
                        {
                            //rombol bal
                            gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                            Cells[current].Left = false;
                            Cells[BinaryTree].Right = false;

                        }

                        if (Cells[current].pos - 8 == Cells[BinaryTree].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                            Cells[current].Top = false;
                            Cells[BinaryTree].Bottom = false;
                        }


                        Cells[current].Visited = true;
                        temporary++;


                        BinaryTree++;

                    }
                }
            }
            if (SelectMode == 99) //test template
            {
                //test template

                //előnyök
                label8.Text = Convert.ToString("A szomszédos cellák állapotát nem kell tudnia.");


                //hátrányok
                label10.Text = Convert.ToString("Nagyon egyszerű/primitív, ezáltal túlságosan felismerhető.");
                while (temporary < 55)
                {
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }

                    tempneighbor = Cells[current].Neighbour;
                    if (tempneighbor[0] < 70)
                    {
                        up = tempneighbor[0];
                    }
                    //checks right
                    if (tempneighbor[1] < 70)
                    {
                        right = tempneighbor[1];
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70)
                    {
                        down = tempneighbor[2];
                    }
                    //checks left
                    if (tempneighbor[3] < 70)
                    {
                        left = tempneighbor[3];
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    //test


                    current = randomValue;
                    //rombol 
                    if (Cells[current].Visited == false)
                    {

                        if (Cells[current].pos - 1 == Cells[LastVisited].pos)
                        {
                            //rombol bal
                            gr.DrawLine(DeletePen, Cells[current].xleft,
                                Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                        }
                        if (Cells[current].pos + 1 == Cells[LastVisited].pos)
                        {
                            //rombol jobb
                            gr.DrawLine(DeletePen, Cells[current].xright,
                                Cells[current].yright, Cells[current].x2right, Cells[current].y2right);
                        }
                        if (Cells[current].pos - 8 == Cells[LastVisited].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop,
                                Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                        }
                        if (Cells[current].pos + 8 == Cells[LastVisited].pos)
                        {
                            //rombol alul
                            gr.DrawLine(DeletePen, Cells[current].xbottom,
                                Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);
                        }

                        Cells[current].Visited = true;
                        temporary++;
                    }
                    LastVisited = Cells[current].pos;


                }
            }
            if (SelectMode == 6) //Prim's algorithm
            {
                //lépések
                label12.Text = "1 - Kiválasztunk egy véletlen cellát, majd megjelöljük azt látogatottnak.";
                label13.Text = "2 - A látogatott cella szomszédjait, megjelöljük frontier celláknak.";
                label14.Text = "3 - Választunk egy frontier cellát, majd összekötjük egy már látogatott cellával. \nA frontier cellát megjelöljük látogatottnak, majd visszatérünk a második lépéshez.";
                label15.Text = "4 - Ezt a három lépést addig ismételjük, amíg az összes cellát meglátogatjuk.";

                //előnyök
                label8.Text = Convert.ToString("Előítélet mentes, egyszerűen implementálható algoritmus. \nAz aldous broder algoritmus továbbfejlesztett változata, \namely nem támaszkodik a véletlenre.");


                //hátrányok
                label10.Text = Convert.ToString("Memória használata nagy más algoritmusokhoz képest, \nmivel az összes frontier cella állapotát a memóriában kell tartani működés közben.");




                //Cells[0].Visited = false;
                //random kezdő cella
                int PrimRandomStart = 0;

                PrimRandomStart = random.Next(0, 56); //0-55 között

                current = PrimRandomStart;
                LastVisited = PrimRandomStart;
                Cells[current].Visited = true;
                temporary = 0;
                temporary++;

                //a szomszédjait beállítjuk frontiernek
                tempneighbor = Cells[current].Neighbour;

                if (tempneighbor[0] < 70)
                {
                    Cells[tempneighbor[0]].Frontier = true;
                }
                if (tempneighbor[1] < 70)
                {
                    Cells[tempneighbor[1]].Frontier = true;
                }
                if (tempneighbor[2] < 70)
                {
                    Cells[tempneighbor[2]].Frontier = true;
                }
                if (tempneighbor[3] < 70)
                {
                    Cells[tempneighbor[3]].Frontier = true;
                }

                int PrimSearch = 0;
                int Talalat = 0;



                while (temporary < 55)
                {
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }

                    if (PrimSearch == 56) //failsafe
                    {
                        break;
                    }
                    tempneighbor = Cells[PrimSearch].Neighbour;

                    if (Cells[PrimSearch].Frontier == true && Cells[PrimSearch].Visited == false)   //ahol vagyunk ott a frontier true
                    {
                        LastVisited = PrimSearch; //hogy a rombolás működjön

                        if (tempneighbor[0] < 70)  //nem-e out of bounds
                        {
                            if (Cells[tempneighbor[0]].Visited == true) //a szomszéd visited-e
                            {
                                up = tempneighbor[0]; //ha visited, belerakjuk az up-ba ahova mehetünk
                                Talalat++;
                            }
                        }




                        if (tempneighbor[1] < 70)
                        {
                            if (Cells[tempneighbor[1]].Visited == true)
                            {
                                right = tempneighbor[1];
                                Talalat++;
                            }
                        }




                        if (tempneighbor[2] < 70)
                        {
                            if (Cells[tempneighbor[2]].Visited == true)
                            {
                                down = tempneighbor[2];
                                Talalat++;
                            }
                        }




                        if (tempneighbor[3] < 70)
                        {
                            if (Cells[tempneighbor[3]].Visited == true)
                            {
                                left = tempneighbor[3];
                                Talalat++;
                            }
                        }
                    }
                    PrimSearch++;

                    if (Talalat > 0)  //rombolas
                    {
                        //random kiválasztom hova megyünk következőnek
                        int[] selectableInts = new int[4] { up, right, down, left };
                        int randomValue = 0;
                        while (randomValue <= 0)
                        {
                            randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                        }
                        current = randomValue;

                        if (Cells[current].pos - 1 == Cells[LastVisited].pos)
                        {
                            //rombol bal --> ide kell beírni hogy a rombolt cella Frontier-jei íródjanak átt
                            gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                            tempneighbor = Cells[LastVisited].Neighbour;
                            if (tempneighbor[0] < 70)
                            {
                                Cells[tempneighbor[0]].Frontier = true;
                            }
                            if (tempneighbor[2] < 70)
                            {
                                Cells[tempneighbor[2]].Frontier = true;
                            }
                            if (tempneighbor[3] < 70)
                            {
                                Cells[tempneighbor[3]].Frontier = true;
                            }

                            Cells[current].Left = false;
                            Cells[LastVisited].Right = false;

                        }
                        if (Cells[current].pos + 1 == Cells[LastVisited].pos)
                        {
                            //rombol jobb
                            gr.DrawLine(DeletePen, Cells[current].xright, Cells[current].yright, Cells[current].x2right, Cells[current].y2right);

                            tempneighbor = Cells[LastVisited].Neighbour;

                            if (tempneighbor[0] < 70)
                            {
                                Cells[tempneighbor[0]].Frontier = true;
                            }

                            if (tempneighbor[1] < 70)
                            {
                                Cells[tempneighbor[1]].Frontier = true;
                            }

                            if (tempneighbor[2] < 70)
                            {
                                Cells[tempneighbor[2]].Frontier = true;
                            }

                            Cells[current].Right = false;
                            Cells[LastVisited].Left = false;

                        }
                        if (Cells[current].pos - 8 == Cells[LastVisited].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);

                            tempneighbor = Cells[LastVisited].Neighbour;


                            if (tempneighbor[0] < 70)
                            {
                                Cells[tempneighbor[0]].Frontier = true;
                            }

                            if (tempneighbor[1] < 70)
                            {
                                Cells[tempneighbor[1]].Frontier = true;
                            }

                            if (tempneighbor[3] < 70)
                            {
                                Cells[tempneighbor[3]].Frontier = true;
                            }

                            Cells[current].Top = false;
                            Cells[LastVisited].Bottom = false;

                        }
                        if (Cells[current].pos + 8 == Cells[LastVisited].pos)
                        {
                            //rombol alul

                            gr.DrawLine(DeletePen, Cells[current].xbottom, Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);

                            tempneighbor = Cells[LastVisited].Neighbour; //lastvisited


                            if (tempneighbor[1] < 70)
                            {
                                Cells[tempneighbor[1]].Frontier = true;
                            }

                            if (tempneighbor[2] < 70)
                            {
                                Cells[tempneighbor[2]].Frontier = true;
                            }

                            if (tempneighbor[3] < 70)
                            {
                                Cells[tempneighbor[3]].Frontier = true;
                            }

                            Cells[current].Bottom = false;
                            Cells[LastVisited].Top = false;

                        }



                        Cells[LastVisited].Visited = true;

                        temporary++;

                        //lenullázzuk
                        up = 0;
                        right = 0;
                        left = 0;
                        down = 0;

                        Talalat = 0;
                        PrimSearch = 0;
                    }




                }

                gr.DrawLine(DeletePen, Cells[0].xright, Cells[0].yright, Cells[0].x2right, Cells[0].y2right);
                Cells[0].Right = false;
                Cells[1].Left = false;


            }
            if (SelectMode == 4) //sidewinder
            {
                //lépések
                label12.Text = "1 - Kiválasztjuk hogy az első sorban mennyi cellával dolgozunk, \nmajd ezek között leromboljuk a falakat.";
                label13.Text = "2 - Véletlen szerűen a kiválaszott cellák közül választunk egyet, \nmajd ennek a felső falát leromboljuk.";
                label14.Text = "3 - Ismételjük a 1-2 lépést amíg az összes cellán végigmegyünk.";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("Memória költsége alacsony.");


                //hátrányok
                label10.Text = Convert.ToString("Felismerhető az első sor generálásáról, mivel előítélettel dolgozik. \nEzen okokból az első sor mindig egy folyosó lesz.");
                while (temporary < 7)
                {
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }
                    //Thread.Sleep(100);
                    right = 0;
                    up = 0;
                    VarElse = 0;
                    //bias : south, east

                    //binarytree is the pos where you are rn
                    tempneighbor = Cells[BinaryTree].Neighbour;
                    //checks up
                    if (tempneighbor[0] < 70)
                    {
                        up = tempneighbor[0];
                        VarElse++;
                    }
                    //checks right
                    if (tempneighbor[1] < 70)
                    {
                        right = tempneighbor[1];
                        VarElse++;
                    }

                    if (VarElse == 0)
                    {

                        break;
                    }
                    //checks left

                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    //test


                    current = randomValue;
                    //rombol 




                    if (Cells[current].pos - 1 == Cells[BinaryTree].pos)
                    {
                        //rombol bal
                        gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                        Cells[current].Left = false;
                        Cells[BinaryTree].Right = false;

                    }

                    if (Cells[current].pos - 8 == Cells[BinaryTree].pos)
                    {
                        //rombol fent
                        gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                        Cells[current].Top = false;
                        Cells[BinaryTree].Bottom = false;
                    }


                    Cells[current].Visited = true;
                    temporary++;
                    BinaryTree++;

                }

                BinaryTree++;
                int randomchance;
                temporary = 0;
                tempneighbor = Cells[BinaryTree].Neighbour;
                //47
                while (temporary < 46)
                {
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }
                    right = 0;
                    up = 0;
                    VarElse = 0;
                    elso = 0;
                    masodik = 0;
                    //bias : south, east
                    {
                        //binarytree is the pos where you are rn
                        if (BinaryTree <= 55)
                        {
                            tempneighbor = Cells[BinaryTree].Neighbour;
                        }
                        else { break; }



                        /////////////////////1
                        if (tempneighbor[1] < 70)    //checks if it's out of bounds
                        {
                            elso = BinaryTree;

                            randomchance = random.Next(100);
                            if (randomchance <= 50)
                            {
                                BinaryTree++;
                                temporary++;

                                goto RombolasPont;

                            }
                            else
                            {
                                gr.DrawLine(DeletePen, Cells[BinaryTree].xright, Cells[BinaryTree].yright, Cells[BinaryTree].x2right, Cells[BinaryTree].y2right);
                                Cells[BinaryTree].Right = false;
                                Cells[tempneighbor[1]].Left = false;
                                BinaryTree++;
                                temporary++;
                            }


                        }
                        else
                        {
                            elso = BinaryTree;
                            BinaryTree++;
                            temporary++;

                            goto RombolasPont;
                        }


                        if (BinaryTree <= 55)
                        {
                            tempneighbor = Cells[BinaryTree].Neighbour;
                        }
                        /////////////////////2
                        if (tempneighbor[1] < 70)
                        {
                            masodik = BinaryTree;


                            randomchance = random.Next(100);
                            if (randomchance <= 50)
                            {
                                BinaryTree++;
                                temporary++;

                                goto RombolasPont;

                            }
                            else
                            {
                                gr.DrawLine(DeletePen, Cells[BinaryTree].xright, Cells[BinaryTree].yright, Cells[BinaryTree].x2right, Cells[BinaryTree].y2right);
                                Cells[BinaryTree].Right = false;
                                Cells[tempneighbor[1]].Left = false;
                                BinaryTree++;
                                temporary++;
                            }
                        }
                        else
                        {
                            masodik = BinaryTree;
                            BinaryTree++;
                            temporary++;

                            goto RombolasPont;

                        }




                    
                    //checks left
                    //random valasztok jeloltet

                    RombolasPont:
                        if (BinaryTree <= 55)
                        {
                            tempneighbor = Cells[BinaryTree].Neighbour;
                        }
                        int randomMarked = 0;
                        int[] MarkedInt = new int[2] { elso, masodik };
                        while (randomMarked <= 0)
                        {
                            randomMarked = MarkedInt[random.Next(0, 2)];
                        }

                        //rombol fent
                        gr.DrawLine(DeletePen, Cells[randomMarked].xtop, Cells[randomMarked].ytop, Cells[randomMarked].x2top, Cells[randomMarked].y2top);
                        Cells[randomMarked].Top = false;
                        Cells[Cells[randomMarked].Neighbour[0]].Bottom = false;  //a randommarked feletti cellának a Bottom attibutiumat írja átt












                    }

                }
                // utolsó cella tetejét leromboljuk
                int OUTelso = 54;
                int OUTmasodik = 55;
                int OUTrandomMarked = 0;
                int[] OUTMarkedInt = new int[2] { OUTelso, OUTmasodik };
                while (OUTrandomMarked <= 0)
                {
                    OUTrandomMarked = OUTMarkedInt[random.Next(0, 2)];
                }

                gr.DrawLine(DeletePen, Cells[OUTrandomMarked].xtop, Cells[OUTrandomMarked].ytop, Cells[OUTrandomMarked].x2top, Cells[OUTrandomMarked].y2top);
                Cells[OUTrandomMarked].Top = false;
                Cells[Cells[OUTrandomMarked].Neighbour[0]].Bottom = false;
                OUTrandomMarked = 54;
                gr.DrawLine(DeletePen, Cells[OUTrandomMarked].xright, Cells[OUTrandomMarked].yright, Cells[OUTrandomMarked].x2right, Cells[OUTrandomMarked].y2right);
                Cells[OUTrandomMarked].Right = false;
                Cells[OUTrandomMarked + 1].Left = false;



            }
            if (SelectMode == 5) //wave function collapse
            {

                //lépések
                label12.Text = "1 - Választunk egy cellát, majd az ide elhelyezhető \nelemek közül lehelyezünk egyet véletlen szerűen.";
                label13.Text = "2 - A szomszédos cellák entrópiáját átszámoljuk, \nvalamint az entrópiát tartalmazó listát amelyben az elhelyezhető \nelemek vannak tárolva.  ";
                label14.Text = "3 - Ezt a két lépést egészen addig folytatjuk, \namíg a labirintus összes cellájának az entrópiája egyenlő lesz 0-val, \nami azt jelenti hogy nem tudunk több elemet elhelyezni.";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("Nagyon nagy testreszabhatóság, jól kiválasztott elemek esetén. \nValamint előítélet mentes algoritmus is lehet.");


                //hátrányok
                label10.Text = Convert.ToString("Magas hibaráta, valamint magas memóriaköltség. ");

                //programrész

                //minimum

                int wawemin = 99;
                int wawerandom = 0;
                wawerandom = random.Next(0, 56);
                int wawepick = 0;
                List<int> converttest = new List<int>();

                //elem setup
                for (int r = 0; r <= 5; r++)
                {
                    Elemek[r] = new Elem();
                }

                //Elemek deklarálása
                {


                    Elemek[0].Rfent = true;
                    Elemek[0].Rjobb = true;
                    Elemek[0].Ralul = false;
                    Elemek[0].Rbal = true;


                    Elemek[0].fent.Add(1);
                    Elemek[0].fent.Add(2);
                    Elemek[0].fent.Add(3);

                    Elemek[0].jobb.Add(0);
                    Elemek[0].jobb.Add(2);
                    Elemek[0].jobb.Add(3);

                    Elemek[0].alul.Add(2);

                    Elemek[0].bal.Add(0);
                    Elemek[0].bal.Add(1);
                    Elemek[0].bal.Add(2);

                    //2

                    Elemek[1].Rfent = true;
                    Elemek[1].Rjobb = true;
                    Elemek[1].Ralul = true;
                    Elemek[1].Rbal = false;


                    Elemek[1].fent.Add(1);
                    Elemek[1].fent.Add(2);
                    Elemek[1].fent.Add(3);

                    Elemek[1].jobb.Add(0);
                    Elemek[1].jobb.Add(2);
                    Elemek[1].jobb.Add(3);

                    Elemek[1].alul.Add(0);
                    Elemek[1].alul.Add(1);
                    Elemek[1].alul.Add(3);

                    //Elemek[1].bal.Add(0);
                    Elemek[1].bal.Add(3);

                    //3

                    Elemek[2].Rfent = false;
                    Elemek[2].Rjobb = true;
                    Elemek[2].Ralul = true;
                    Elemek[2].Rbal = true;


                    //    Elemek[2].fent.Add(0);
                    Elemek[2].fent.Add(0);

                    Elemek[2].jobb.Add(0);
                    Elemek[2].jobb.Add(2);
                    Elemek[2].jobb.Add(3);

                    Elemek[2].alul.Add(0);
                    Elemek[2].alul.Add(1);
                    Elemek[2].alul.Add(3);

                    Elemek[2].bal.Add(0);
                    Elemek[2].bal.Add(1);
                    Elemek[2].bal.Add(2);

                    //4

                    Elemek[3].Rfent = true;
                    Elemek[3].Rjobb = false;
                    Elemek[3].Ralul = true;
                    Elemek[3].Rbal = true;


                    Elemek[3].fent.Add(1);
                    Elemek[3].fent.Add(2);
                    Elemek[3].fent.Add(3);

                    //    Elemek[3].jobb.Add(0);
                    Elemek[3].jobb.Add(1);

                    Elemek[3].alul.Add(0);
                    Elemek[3].alul.Add(1);
                    Elemek[3].alul.Add(3);

                    Elemek[3].bal.Add(0);
                    Elemek[3].bal.Add(1);
                    Elemek[3].bal.Add(2);
                }
                int WaweCounter = 0;
                while (WaweCounter < 100)
                {
                    //késleltetés
                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }
                    //minimum keresés
                    for (int r = 0; r <= 55; r++)
                    {
                        if (Cells[r].Visited == false)
                        {
                            if (Cells[r].entropy < wawemin && Cells[r].entropy != 0)
                            {
                                wawemin = Cells[r].entropy;
                            }
                        }
                    }




                    //cellát választunk
                    int Fsafe = 0;
                    while (Cells[wawerandom].entropy != wawemin || Cells[wawerandom].Visited == true)
                    {
                        wawerandom = random.Next(0, 56);
                        Fsafe++;
                        if (Fsafe == 999)
                        {
                            goto WaweCollapseEnd;
                        }
                    }
                    Fsafe = 0;
                    //tempneighbort beállítjuk
                    tempneighbor = Cells[wawerandom].Neighbour;
                    Cells[wawerandom].Visited = true;


                    //választunk elemet

                    wawepick = random.Next(0, Cells[wawerandom].EntropyPossible.Count); //wawepick=random sorszám a listán
                    wawepick = Cells[wawerandom].EntropyPossible[wawepick]; //wawepick=Elem száma

                    //test vegyük azt hogy 0 lesz most
                    //wawepick = 0;

                    //FENT

                    //if hogy nem OOB future
                    if (tempneighbor[0] < 70)
                    {

                        IEnumerable<int> TemporalStorage = Cells[wawerandom - 8].EntropyPossible.Intersect(Elemek[wawepick].fent); //wawepick az melyik elem (módosítjuk a wawepicket és a wawerandom - 8)
                        converttest.AddRange(TemporalStorage);

                        Cells[wawerandom - 8].EntropyPossible.Clear();
                        Cells[wawerandom - 8].EntropyPossible.AddRange(converttest);
                        Cells[wawerandom - 8].entropy = Cells[wawerandom - 8].EntropyPossible.Count;

                        //reset
                        converttest.Clear();

                        //rombol
                        if (Elemek[wawepick].Rfent == true)
                        {
                            gr.DrawLine(DeletePen, Cells[wawerandom].xtop, Cells[wawerandom].ytop, Cells[wawerandom].x2top, Cells[wawerandom].y2top);
                            Cells[wawerandom].Top = false;
                            Cells[wawerandom - 8].Bottom = false;
                        }
                    }

                    //JOBBRA
                    if (tempneighbor[1] < 70)
                    {

                        IEnumerable<int> TemporalStorage = Cells[wawerandom + 1].EntropyPossible.Intersect(Elemek[wawepick].jobb); //wawepick az melyik elem (módosítjuk a wawepicket és a wawerandom - 8)
                        converttest.AddRange(TemporalStorage);

                        Cells[wawerandom + 1].EntropyPossible.Clear();
                        Cells[wawerandom + 1].EntropyPossible.AddRange(converttest);
                        Cells[wawerandom + 1].entropy = Cells[wawerandom + 1].EntropyPossible.Count;

                        //reset
                        converttest.Clear();

                        //rombol
                        if (Elemek[wawepick].Rjobb == true)
                        {
                            gr.DrawLine(DeletePen, Cells[wawerandom].xright, Cells[wawerandom].yright, Cells[wawerandom].x2right, Cells[wawerandom].y2right);
                            Cells[wawerandom].Right = false;
                            Cells[wawerandom + 1].Left = false;
                        }
                    }

                    //ALUL
                    if (tempneighbor[2] < 70)
                    {

                        IEnumerable<int> TemporalStorage = Cells[wawerandom + 8].EntropyPossible.Intersect(Elemek[wawepick].alul); //wawepick az melyik elem (módosítjuk a wawepicket és a wawerandom - 8)
                        converttest.AddRange(TemporalStorage);

                        Cells[wawerandom + 8].EntropyPossible.Clear();
                        Cells[wawerandom + 8].EntropyPossible.AddRange(converttest);
                        Cells[wawerandom + 8].entropy = Cells[wawerandom + 8].EntropyPossible.Count;

                        //reset
                        converttest.Clear();

                        //rombol
                        if (Elemek[wawepick].Ralul == true)
                        {
                            gr.DrawLine(DeletePen, Cells[wawerandom].xbottom, Cells[wawerandom].ybottom, Cells[wawerandom].x2bottom, Cells[wawerandom].y2bottom);
                            Cells[wawerandom].Bottom = false;
                            Cells[wawerandom + 8].Top = false;
                        }
                    }
                    //Bal
                    if (tempneighbor[3] < 70)
                    {

                        IEnumerable<int> TemporalStorage = Cells[wawerandom - 1].EntropyPossible.Intersect(Elemek[wawepick].bal); //wawepick az melyik elem (módosítjuk a wawepicket és a wawerandom - 8)
                        converttest.AddRange(TemporalStorage);

                        Cells[wawerandom - 1].EntropyPossible.Clear();
                        Cells[wawerandom - 1].EntropyPossible.AddRange(converttest);
                        Cells[wawerandom - 1].entropy = Cells[wawerandom - 1].EntropyPossible.Count;

                        //reset
                        converttest.Clear();

                        //rombol
                        if (Elemek[wawepick].Rbal == true)
                        {
                            gr.DrawLine(DeletePen, Cells[wawerandom].xleft, Cells[wawerandom].yleft, Cells[wawerandom].x2left, Cells[wawerandom].y2left);
                            Cells[wawerandom].Left = false;
                            Cells[wawerandom - 1].Right = false;
                        }
                    }
                    WaweCounter++;
                    wawemin = 99;
                }
            WaweCollapseEnd:
                int correction = 0;
                for (int r = 0; r <= 55; r++)
                {
                    tempneighbor = Cells[r].Neighbour;
                    if (Cells[r].Top == true && Cells[r].Right == true && Cells[r].Bottom == true && Cells[r].Left == true)
                    {

                        if (tempneighbor[0] < 70 && correction == 0)
                        {
                            gr.DrawLine(DeletePen, Cells[r].xtop, Cells[r].ytop, Cells[r].x2top, Cells[r].y2top);
                            Cells[r].Top = false;
                            Cells[r - 8].Bottom = false;
                            correction++;
                        }
                        if (tempneighbor[1] < 70 && correction == 0)
                        {
                            gr.DrawLine(DeletePen, Cells[r].xright, Cells[r].yright, Cells[r].x2right, Cells[r].y2right);
                            Cells[r].Right = false;
                            Cells[r + 1].Left = false;
                            correction++;
                        }
                        if (tempneighbor[2] < 70 && correction == 0)
                        {
                            gr.DrawLine(DeletePen, Cells[r].xbottom, Cells[r].ybottom, Cells[r].x2bottom, Cells[r].y2bottom);
                            Cells[r].Bottom = false;
                            Cells[r + 8].Top = false;
                            correction++;
                        }
                        if (tempneighbor[3] < 70 && correction == 0)
                        {
                            gr.DrawLine(DeletePen, Cells[r].xleft, Cells[r].yleft, Cells[r].x2left, Cells[r].y2left);
                            Cells[r].Left = false;
                            Cells[r - 1].Right = false;
                            correction++;
                        }
                    }
                    correction = 0;
                }

                for (int r = 0; r <= 47; r++)
                {
                    if (Cells[r].Right == false && Cells[r].Bottom == false && Cells[r + 9].Left == false && Cells[r + 9].Top == false)
                    {
                        // berajzoljuk a kiss + jelet
                        gr.DrawLine(myPen, Cells[r + 9].xbottom - 40, Cells[r + 9].ybottom - 50, Cells[r + 9].x2bottom - 10, Cells[r + 9].y2bottom - 50);
                        gr.DrawLine(myPen, Cells[r + 9].xright - 50, Cells[r + 9].yright - 10, Cells[r + 9].x2right - 50, Cells[r + 9].y2right - 40);
                    }
                }
                int Cstepping;
                int Cmarked;
                int Cfailsafe = 0;
                up = 0;
                right = 0;
                down = 0;
                left = 0;
                //POST CORRECTION

                Cmarked = 1;
                Cells[StartPoint].Cvisited = true;
                while (Cmarked<55)
                {
                SearchMark:
                    Cstepping = 0;
                    LastVisited = StartPoint;
                    Cfailsafe++;
                    if (Cfailsafe == 1000)
                    {
                        break;
                    }


                    //Search+mark
                    current = StartPoint;
                    while (Cstepping < 1000)
                {
                    
                    tempneighbor = Cells[current].Neighbour;
                    if (tempneighbor[0] < 70 && Cells[current].Top==false)
                    {
                        up = tempneighbor[0];
                    }
                    //checks right
                    if (tempneighbor[1] < 70 && Cells[current].Right == false)
                    {
                        right = tempneighbor[1];
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70 && Cells[current].Bottom == false)
                    {
                        down = tempneighbor[2];
                    }
                    //checks left
                    if (tempneighbor[3] < 70 && Cells[current].Left == false)
                    {
                        left = tempneighbor[3];
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    LastVisited = current;
                    current = randomValue;
                        up = 0;
                        right = 0;
                        down = 0;
                        left = 0;


                   if (Cells[current].Cvisited == false)  {
                        Cells[current].Cvisited = true;
                            Cmarked++;

                            }
                   


                    Cstepping++;


                }

                //Search + destroy
                Cstepping = 0;
                LastVisited = StartPoint;
                    current = StartPoint;
                    while (Cstepping < 1000)
                {
                    
                    tempneighbor = Cells[current].Neighbour;
                    if (tempneighbor[0] < 70 && Cells[current].Top == false)
                    {
                        up = tempneighbor[0];
                    }
                    //checks right
                    if (tempneighbor[1] < 70 && Cells[current].Right == false)
                    {
                        right = tempneighbor[1];
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70 && Cells[current].Bottom == false)
                    {
                        down = tempneighbor[2];
                    }
                    //checks left
                    if (tempneighbor[3] < 70 && Cells[current].Left == false)
                    {
                        left = tempneighbor[3];
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }

                    if (tempneighbor[0] < 70)
                    {
                            if(Cells[tempneighbor[0]].Cvisited == false)
                            {
                                //rombol a kettő között majd goto start
                                gr.DrawLine(DeletePen, Cells[current].xtop, Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);

                                Cells[tempneighbor[0]].Bottom = false;
                                Cells[current].Top = false;
                                goto SearchMark;
                            }
                    }

                        if (tempneighbor[1] < 70)
                        {
                            if (Cells[tempneighbor[1]].Cvisited == false)
                            {
                                //rombol a kettő között majd goto start
                                gr.DrawLine(DeletePen, Cells[current].xright, Cells[current].yright, Cells[current].x2right, Cells[current].y2right);

                                Cells[tempneighbor[1]].Left = false;
                                Cells[current].Right = false;
                                goto SearchMark;
                            }
                        }

                        if (tempneighbor[2] < 70)
                        {
                            if (Cells[tempneighbor[2]].Cvisited == false)
                            {
                                //rombol a kettő között majd goto start
                                gr.DrawLine(DeletePen, Cells[current].xbottom, Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);

                                Cells[tempneighbor[2]].Top = false;
                                Cells[current].Bottom = false;
                                goto SearchMark;
                            }
                        }

                        if (tempneighbor[3] < 70)
                        {
                            if (Cells[tempneighbor[3]].Cvisited == false)
                            {
                                //rombol a kettő között majd goto start
                                gr.DrawLine(DeletePen, Cells[current].xleft, Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);

                                Cells[tempneighbor[3]].Right = false;
                                Cells[current].Left = false;
                                goto SearchMark;
                            }
                        }

                        LastVisited = current;
                    current = randomValue;
                        up = 0;
                        right = 0;
                        down = 0;
                        left = 0;



                        Cstepping++;


                }
                }
                up = 0;

                



















                
            }
            if (SelectMode == 999) // felező (nem elkészült algoritmus)
            {
                for (int r = 0; r <= 55; r++)
                {
                    Cells[r].Top = false;
                    Cells[r].Right = false;
                    Cells[r].Bottom = false;
                    Cells[r].Left = false;

                }


                for (int r = 0; r <= 7; r++)
                {
                    gr.DrawLine(myPen, Cells[r].xtop, Cells[r].ytop, Cells[r].x2top, Cells[r].y2top);
                    Cells[r].Top = true;
                    Cells[r].OOBTop = true;
                }

                for (int r = 0; r <= 48; r = r + 8)
                {
                    gr.DrawLine(myPen, Cells[r].xleft, Cells[r].yleft, Cells[r].x2left, Cells[r].y2left);
                    Cells[r].Left = true;
                    Cells[r].OOBLeft = true;
                }

                for (int r = 7; r <= 55; r = r + 8)
                {
                    gr.DrawLine(myPen, Cells[r].xright, Cells[r].yright, Cells[r].x2right, Cells[r].y2right);
                    Cells[r].Right = true;
                    Cells[r].OOBRight = true;
                }

                for (int r = 48; r <= 55; r++)
                {
                    gr.DrawLine(myPen, Cells[r].xbottom, Cells[r].ybottom, Cells[r].x2bottom, Cells[r].y2bottom);
                    Cells[r].Bottom = true;
                    Cells[r].OOBBottom = true;
                }
                int starting = 0;
                int oszlop = 0;
                int hosszu = 0;
                int magas = 0;
                int SzamHossz = 0;
                int SzamMagas = 0;
                int InitialKezd = 0;
                int belep = 0;
                int eltolas = 0;
                int eltszam = 0;
                List<int> ToDeleteR = new List<int>();
                List<int> ToDeleteB = new List<int>();
                //szimulálunk 

                // vertical

                while (temporary < 2)
                {
                    belep = 0;
                    //tapogatás
                    for (int x = 0; x <= 55; x = x + 8)
                    {
                        starting = x;
                        for (int r = 0; r <= 7; r++)
                        {
                            hosszu++;  //számoljuk

                            if (Cells[starting].Right == true)
                            {

                                if (Cells[starting].OOBRight == true)
                                {
                                    SzamHossz = hosszu;
                                    hosszu = 0;
                                    break;
                                }

                                if (eltolas == eltszam)
                                {
                                    SzamHossz = hosszu;
                                    hosszu = 0;
                                    break;
                                }
                                else
                                {
                                    eltszam++;
                                    SzamHossz = 0;
                                }

                            }
                            starting++;
                        }
                        magas++; //számoljuk
                        if (Cells[x].Bottom == true)
                        {
                            SzamMagas = magas;
                            magas = 0;
                            break;
                        }


                    }
                    //SzamMagas >= SzamHossz && ez hiányzik belőle test
                    if (SzamMagas >= SzamHossz && SzamMagas > 1 && SzamHossz > 1)
                    {
                        belep++;
                        //horizont
                        Random a = new Random();
                        int kezdop = a.Next(0, SzamMagas - 1);


                        kezdop = kezdop * 8;
                        InitialKezd = kezdop;
                        for (int r = 1; r <= SzamHossz; r++)
                        {


                            //gr.DrawLine(myPen, Cells[kezdop].xbottom, Cells[kezdop].ybottom, Cells[kezdop].x2bottom, Cells[kezdop].y2bottom);
                            Cells[kezdop].Bottom = true;
                            Cells[kezdop + 8].Top = true;
                            kezdop++;
                        }
                        ToDeleteB.Add(a.Next(InitialKezd, kezdop));
                    }

                    //vertical
                    if (SzamMagas < SzamHossz && SzamMagas > 1 && SzamHossz > 1)
                    {

                        belep++;
                        Random a = new Random();
                        int kezdop = a.Next(0, SzamHossz - 1);
                        InitialKezd = kezdop;


                        for (int r = 1; r <= SzamMagas; r++)
                        {


                            //gr.DrawLine(myPen, Cells[kezdop].xright, Cells[kezdop].yright, Cells[kezdop].x2right, Cells[kezdop].y2right);
                            Cells[kezdop].Right = true;
                            Cells[kezdop + 1].Left = true;
                            kezdop = kezdop + 8;
                        }
                        int trying = 2;
                        while (trying % 8 != InitialKezd)
                        {
                            trying = a.Next(InitialKezd, kezdop - 1);
                        }
                        ToDeleteR.Add(trying);
                    }
                    if (belep == 0)
                    {
                        eltolas++;
                    }
                    temporary++;

                }
                


                //gr.DrawLine(myPen, Cells[9].xright-25 , Cells[9].yright - 10, Cells[9].x2right - 25, Cells[9].y2right - 40); 

                //left
                gr.DrawLine(myPen, Cells[9].xleft, Cells[9].yleft - 25, Cells[9].x2left + 25, Cells[9].y2left + 25);

                //right
                gr.DrawLine(myPen, Cells[10].xright, Cells[10].yright + 25, Cells[10].x2left + 25, Cells[10].y2left + 25);

                //fent
                gr.DrawLine(myPen, Cells[11].xtop + 25, Cells[11].ytop, Cells[11].x2left + 25, Cells[11].y2left + 25);

                //fent
                gr.DrawLine(myPen, Cells[12].xbottom - 25, Cells[12].ybottom, Cells[12].x2left + 25, Cells[12].y2left + 25);
            }
            int look = 0;
            int rename = 0;
            if (SelectMode == 7) //Kruskal
            {
                //lépések
                label12.Text = "1 - Választunk egy véletlenszerű cellát a labirintusban. ";
                label13.Text = "2 - Ha ennek a cellának létezik olyan szomszédja amely \njelölése nem egyezik meg a választott cella jelölésével, \nakkor leromboljuk a két cella közötti falat.";
                label14.Text = "3 - Átírjuk a cella jelöléseket";
                label15.Text = "";

                //előnyök
                label8.Text = Convert.ToString("Egyszerű algoritmus, futási ideje átlagos.");


                //hátrányok
                label10.Text = Convert.ToString("Nem optimális nagy algoritmusok generálására, \nmivel minden cella rendelkezik saját jelöléssel, \namely gyakran átírásra kerül.");

                while (temporary < 55)
                {
                    current = random.Next(0, 55);
                    LastVisited = current;

                    tempneighbor = Cells[current].Neighbour;
                    if (tempneighbor[0] < 70)
                    {
                        up = tempneighbor[0];
                    }
                    //checks right
                    if (tempneighbor[1] < 70)
                    {
                        right = tempneighbor[1];
                    }
                    //checks bottom
                    if (tempneighbor[2] < 70)
                    {
                        down = tempneighbor[2];
                    }
                    //checks left
                    if (tempneighbor[3] < 70)
                    {
                        left = tempneighbor[3];
                    }
                    //random kiválasztom hova megyünk következőnek
                    int[] selectableInts = new int[4] { up, right, down, left };
                    int randomValue = 0;
                    while (randomValue <= 0)
                    {
                        randomValue = selectableInts[random.Next(0, selectableInts.Length)];
                    }
                    //test


                    current = randomValue;
                    up = 0;
                    right = 0;
                    down = 0;
                    left = 0;
                    //rombol 
                    if (Cells[current].Family != Cells[LastVisited].Family)
                    {
                        

                        if (Cells[current].pos - 1 == Cells[LastVisited].pos)
                        {
                            //rombol bal
                            gr.DrawLine(DeletePen, Cells[current].xleft,
                                Cells[current].yleft, Cells[current].x2left, Cells[current].y2left);
                            Cells[current].Left = false;
                            Cells[LastVisited].Right = false;

                        } //rombol bal
                        if (Cells[current].pos + 1 == Cells[LastVisited].pos)
                        {
                            //rombol jobb
                            gr.DrawLine(DeletePen, Cells[current].xright,
                                Cells[current].yright, Cells[current].x2right, Cells[current].y2right);
                            Cells[current].Right = false;
                            Cells[LastVisited].Left = false;

                        } //rombol jobb
                        if (Cells[current].pos - 8 == Cells[LastVisited].pos)
                        {
                            //rombol fent
                            gr.DrawLine(DeletePen, Cells[current].xtop,
                                Cells[current].ytop, Cells[current].x2top, Cells[current].y2top);
                            Cells[current].Top = false;
                            Cells[LastVisited].Bottom = false;

                        } //rombol fent
                        if (Cells[current].pos + 8 == Cells[LastVisited].pos)
                        {
                            //rombol alul

                            gr.DrawLine(DeletePen, Cells[current].xbottom,
                                Cells[current].ybottom, Cells[current].x2bottom, Cells[current].y2bottom);
                            Cells[current].Bottom = false;
                            Cells[LastVisited].Top = false;
                        } //rombol alul

                        //családokat beállítjuk
                        look = Cells[current].Family;
                        rename = Cells[LastVisited].Family;
                        temporary++;
                    }
                    

                    //wait

                    switch (SlowMode)
                    {
                        case 1:
                            Thread.Sleep(0);
                            break;
                        case 2:
                            Thread.Sleep(10);
                            break;
                        case 3:
                            Thread.Sleep(20);
                            break;
                        case 4:
                            Thread.Sleep(50);
                            break;
                        case 5:
                            Thread.Sleep(100);
                            break;
                        case 6:
                            Thread.Sleep(200);
                            break;
                    }


                    //ciklus amely végigmegy az összesen

                    for (int r = 0; r <= 55; r++)
                    {
                        if(Cells[r].Family == look){
                            Cells[r].Family= rename;
                        }

                    }




                }

               




            }

            

            //Rombol Start
            gr.DrawLine(DeletePen, Cells[StartPoint].xleft, Cells[StartPoint].yleft, Cells[StartPoint].x2left, Cells[StartPoint].y2left);

            //Rombol Exit
            gr.DrawLine(DeletePen, Cells[ExitPoint].xright, Cells[ExitPoint].yright, Cells[ExitPoint].x2right, Cells[ExitPoint].y2right);

            // megoldás
            if (SolutionSelectMode == 3) //nincs megoldás
            {
                //empty
            }
            else
            {
                // IF választás

                int[] Solution = new int[55];
                int PossiblePaths = 0;
                int SolutionCurrent;
                bool SolutionTop = false;
                bool SolutionRight = false;
                bool SolutionBottom = false;
                bool SolutionLeft = false;
                int Sup = 0;
                int Sright = 0;
                int Sdown = 0;
                int Sleft = 0;
                int SolutionCheckpoint = 0;
                int SC = 1;  //SolutionCounter
                int validity = 1;
                int RemoverIncrement = 0;
                int BacktrackCounter = 0;




                if (SolutionSelectMode == 1)
                {
                    Solution[0] = StartPoint;
                    SolutionCurrent = StartPoint;
                    Cells[SolutionCurrent].SV = true;
                    Steps.Add(Cells[SolutionCurrent].pos);

                    while (SolutionCurrent != ExitPoint)
                    {
                    SearchPoint:
                        PossiblePaths = 0;
                        if (Cells[SolutionCurrent].Neighbour[0] <= 55)
                        {   //megnézi hogy nem e out of bounds
                            if (Cells[SolutionCurrent].Top == false && Cells[Cells[SolutionCurrent].Neighbour[0]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionTop = true;
                            }
                        }

                        if (Cells[SolutionCurrent].Neighbour[1] <= 55)
                        {
                            if (Cells[SolutionCurrent].Right == false && Cells[Cells[SolutionCurrent].Neighbour[1]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionRight = true;
                            }
                        }

                        if (Cells[SolutionCurrent].Neighbour[2] <= 55)
                        {
                            if (Cells[SolutionCurrent].Bottom == false && Cells[Cells[SolutionCurrent].Neighbour[2]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionBottom = true;
                            }
                        }


                        if (Cells[SolutionCurrent].Neighbour[3] <= 55)
                        {
                            if (Cells[SolutionCurrent].Left == false && Cells[Cells[SolutionCurrent].Neighbour[3]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionLeft = true;
                            }
                        }



                        //Merre megyünk tovább

                        if (PossiblePaths > 0)
                        {
                            BacktrackCounter = 0;
                            RemoverIncrement = 0; //Visszaállítjuk egyre ha találtunk possible pathsot
                            validity = 1; //Valid a mozgás


                            if (SolutionTop == true && validity == 1)
                            {

                                SolutionCurrent = Cells[SolutionCurrent].Neighbour[0]; //a currentet a felső szomszédra állítjuk, mivel fel mozgunk
                                Steps.Add(Cells[SolutionCurrent].pos);  // hozzáadjuk a listához a megoldást


                                Solution[SC] = SolutionCurrent;
                                SC++;
                                Cells[SolutionCurrent].SV = true;

                                validity = 0;  //azt jelenti hogy már egy irányba elindultunk
                            }

                            if (SolutionRight == true && validity == 1)
                            {
                                SolutionCurrent = Cells[SolutionCurrent].Neighbour[1];
                                Steps.Add(Cells[SolutionCurrent].pos);

                                Solution[SC] = SolutionCurrent;
                                SC++;
                                Cells[SolutionCurrent].SV = true;

                                validity = 0;
                            }

                            if (SolutionBottom == true && validity == 1)
                            {
                                SolutionCurrent = Cells[SolutionCurrent].Neighbour[2];
                                Steps.Add(Cells[SolutionCurrent].pos);

                                Solution[SC] = SolutionCurrent;
                                SC++;
                                Cells[SolutionCurrent].SV = true;

                                validity = 0;
                            }

                            if (SolutionLeft == true && validity == 1)
                            {
                                SolutionCurrent = Cells[SolutionCurrent].Neighbour[3];
                                Steps.Add(Cells[SolutionCurrent].pos);

                                Solution[SC] = SolutionCurrent;
                                SC++;
                                Cells[SolutionCurrent].SV = true;

                                validity = 0;
                            }
                            SolutionTop = false;
                            SolutionRight = false;
                            SolutionBottom = false;
                            SolutionLeft = false;
                        }

                        if (PossiblePaths == 0)
                        {
                            RemoverIncrement++;
                            //Steps.Remove(Cells[SolutionCurrent].pos);

                            Backtracking.Add(Cells[SolutionCurrent].pos);
                            //elindulunk visszafele és
                            if (RemoverIncrement > Steps.Count) { break; }
                            else
                            {
                                SolutionCurrent = Steps[Steps.Count - RemoverIncrement];  //-1 a Countertől az a visszafele mozgás iránya
                            }
                            //Steps.RemoveAt(SC);
                            BacktrackCounter++;
                            //Steps.RemoveAt(Steps); //at utolsó backtrackcounter mennyiségűt removolni
                            goto SearchPoint;

                        }

                    } 




                    string Bresult = "";
                    for (int i = 0; i < Backtracking.Count; i++)
                    {
                        Bresult = Bresult + Backtracking[i] + ",";
                    }

                    string result = "";
                    for (int i = 0; i < Steps.Count; i++)

                    {

                        result = result + Steps[i] + ",";
                    }


                    


                    foreach (int number in Steps)
                    {
                        if (!Backtracking.Contains(number))
                        {
                            FinalSteps.Add(number);
                        }
                    }

                    foreach (int number in Backtracking)
                    {
                        Console.Write(number + " ");
                    }
                    


                    gr.DrawLine(SolutionPen, Cells[FinalSteps[0]].xleft, Cells[FinalSteps[0]].yleft - 25, Cells[FinalSteps[0]].x2left + 25, Cells[FinalSteps[0]].y2left + 25);
                    for (int i = 0; i < FinalSteps.Count - 1; i++)
                    {
                        //jobbra
                        if (FinalSteps[i] + 1 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xright, Cells[FinalSteps[i]].yright + 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xleft, Cells[FinalSteps[i + 1]].yleft - 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        }
                        //balra
                        if (FinalSteps[i] - 1 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xright, Cells[FinalSteps[i + 1]].yright + 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xleft, Cells[FinalSteps[i]].yleft - 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        }

                        //fentre
                        if (FinalSteps[i] - 8 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xtop + 25, Cells[FinalSteps[i]].ytop, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xbottom - 25, Cells[FinalSteps[i + 1]].ybottom, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        }

                        //lentre
                        if (FinalSteps[i] + 8 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xtop + 25, Cells[FinalSteps[i + 1]].ytop, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xbottom - 25, Cells[FinalSteps[i]].ybottom, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        }

                        FinalResult = FinalResult + Steps[i] + ",";
                    }
                    gr.DrawLine(SolutionPen, Cells[FinalSteps[FinalSteps.Count - 1]].xright, Cells[FinalSteps[FinalSteps.Count - 1]].yright + 25, Cells[FinalSteps[FinalSteps.Count - 1]].x2left + 25, Cells[FinalSteps[FinalSteps.Count - 1]].y2left + 25);
                }

                if (SolutionSelectMode == 2)
                {
                    Solution[0] = StartPoint;
                    SolutionCurrent = StartPoint;
                    Cells[SolutionCurrent].SV = true;
                    Steps.Add(Cells[SolutionCurrent].pos);

                    while (SolutionCurrent != ExitPoint)
                    {
                    SearchPoint:
                        PossiblePaths = 0;
                        if (Cells[SolutionCurrent].Neighbour[0] <= 55)
                        {   //megnézi hogy nem e out of bounds
                            if (Cells[SolutionCurrent].Top == false && Cells[Cells[SolutionCurrent].Neighbour[0]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionTop = true;
                            }
                        }

                        if (Cells[SolutionCurrent].Neighbour[1] <= 55)
                        {
                            if (Cells[SolutionCurrent].Right == false && Cells[Cells[SolutionCurrent].Neighbour[1]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionRight = true;
                            }
                        }

                        if (Cells[SolutionCurrent].Neighbour[2] <= 55)
                        {
                            if (Cells[SolutionCurrent].Bottom == false && Cells[Cells[SolutionCurrent].Neighbour[2]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionBottom = true;
                            }
                        }


                        if (Cells[SolutionCurrent].Neighbour[3] <= 55)
                        {
                            if (Cells[SolutionCurrent].Left == false && Cells[Cells[SolutionCurrent].Neighbour[3]].SV == false)
                            {
                                PossiblePaths++;
                                SolutionLeft = true;
                            }
                        }



                        //Merre megyünk tovább

                        if (PossiblePaths > 0)
                        {
                            BacktrackCounter = 0;
                            RemoverIncrement = 0; //Visszaállítjuk egyre ha találtunk possible pathsot
                            validity = 1; //Valid a mozgás

                            Random r = new Random();
                            int rInt = r.Next(1, 5);
                            switch (rInt)
                            {
                                case 1:

                                    if (SolutionTop == true && validity == 1)
                                    {

                                        SolutionCurrent = Cells[SolutionCurrent].Neighbour[0]; //a currentet a felső szomszédra állítjuk, mivel fel mozgunk
                                        Steps.Add(Cells[SolutionCurrent].pos);  // hozzáadjuk a listához a megoldást


                                        Solution[SC] = SolutionCurrent;
                                        SC++;
                                        Cells[SolutionCurrent].SV = true;

                                        validity = 0;
                                        SolutionTop = false;
                                        SolutionRight = false;
                                        SolutionBottom = false;
                                        SolutionLeft = false;//azt jelenti hogy már egy irányba elindultunk
                                    }
                                    break;
                                case 2:
                                    if (SolutionRight == true && validity == 1)
                                    {
                                        SolutionCurrent = Cells[SolutionCurrent].Neighbour[1];
                                        Steps.Add(Cells[SolutionCurrent].pos);

                                        Solution[SC] = SolutionCurrent;
                                        SC++;
                                        Cells[SolutionCurrent].SV = true;

                                        validity = 0;
                                        SolutionTop = false;
                                        SolutionRight = false;
                                        SolutionBottom = false;
                                        SolutionLeft = false;
                                    }
                                    break;
                                case 3:
                                    if (SolutionBottom == true && validity == 1)
                                    {
                                        SolutionCurrent = Cells[SolutionCurrent].Neighbour[2];
                                        Steps.Add(Cells[SolutionCurrent].pos);

                                        Solution[SC] = SolutionCurrent;
                                        SC++;
                                        Cells[SolutionCurrent].SV = true;

                                        validity = 0;
                                        SolutionTop = false;
                                        SolutionRight = false;
                                        SolutionBottom = false;
                                        SolutionLeft = false;
                                    }
                                    break;
                                case 4:
                                    if (SolutionLeft == true && validity == 1)
                                    {
                                        SolutionCurrent = Cells[SolutionCurrent].Neighbour[3];
                                        Steps.Add(Cells[SolutionCurrent].pos);

                                        Solution[SC] = SolutionCurrent;
                                        SC++;
                                        Cells[SolutionCurrent].SV = true;

                                        validity = 0;
                                        SolutionTop = false;
                                        SolutionRight = false;
                                        SolutionBottom = false;
                                        SolutionLeft = false;
                                    }

                                    break;
                            }
                        }

                        if (PossiblePaths == 0)
                        {
                            RemoverIncrement++;
                            //Steps.Remove(Cells[SolutionCurrent].pos);

                            Backtracking.Add(Cells[SolutionCurrent].pos);
                            //elindulunk visszafele és
                            if (RemoverIncrement > Steps.Count) { break; }
                            else
                            {
                                SolutionCurrent = Steps[Steps.Count - RemoverIncrement];  //-1 a Countertől az a visszafele mozgás iránya
                            }
                            //Steps.RemoveAt(SC);
                            BacktrackCounter++;
                            //Steps.RemoveAt(Steps); //at utolsó backtrackcounter mennyiségűt removolni
                            goto SearchPoint;

                        }

                    } //while vége

                    
                    int TestPos = 9;
                    // label1.Text = Convert.ToString(Cells[TestPos].Top);
                    //label2.Text = Convert.ToString(Cells[TestPos].Right);
                    //label3.Text = Convert.ToString(Cells[TestPos].Bottom);
                    //label4.Text = Convert.ToString(Cells[TestPos].Left);

                    //Console.WriteLine(Steps[1]);




                    string Bresult = "";
                    for (int i = 0; i < Backtracking.Count; i++)
                    {
                        Bresult = Bresult + Backtracking[i] + ",";
                    }

                    string result = "";
                    for (int i = 0; i < Steps.Count; i++)

                    {

                        result = result + Steps[i] + ",";
                    }


                    
                   


                    foreach (int number in Steps)
                    {
                        if (!Backtracking.Contains(number))
                        {
                            FinalSteps.Add(number);
                        }
                    }

                    foreach (int number in Backtracking)
                    {
                        Console.Write(number + " ");
                    }
                    


                    gr.DrawLine(SolutionPen, Cells[FinalSteps[0]].xleft, Cells[FinalSteps[0]].yleft - 25, Cells[FinalSteps[0]].x2left + 25, Cells[FinalSteps[0]].y2left + 25);
                    for (int i = 0; i < FinalSteps.Count - 1; i++)
                    {
                        //jobbra
                        if (FinalSteps[i] + 1 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xright, Cells[FinalSteps[i]].yright + 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xleft, Cells[FinalSteps[i + 1]].yleft - 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        }
                        //balra
                        if (FinalSteps[i] - 1 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xright, Cells[FinalSteps[i + 1]].yright + 25, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xleft, Cells[FinalSteps[i]].yleft - 25, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        }

                        //fentre
                        if (FinalSteps[i] - 8 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xtop + 25, Cells[FinalSteps[i]].ytop, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xbottom - 25, Cells[FinalSteps[i + 1]].ybottom, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                        }

                        //lentre
                        if (FinalSteps[i] + 8 == FinalSteps[i + 1])
                        {
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i + 1]].xtop + 25, Cells[FinalSteps[i + 1]].ytop, Cells[FinalSteps[i + 1]].x2left + 25, Cells[FinalSteps[i + 1]].y2left + 25);
                            gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xbottom - 25, Cells[FinalSteps[i]].ybottom, Cells[FinalSteps[i]].x2left + 25, Cells[FinalSteps[i]].y2left + 25);
                        }



                        //gr.DrawLine(SolutionPen, Cells[FinalSteps[i]].xtop + 20, Cells[FinalSteps[i]].ytop + 20, Cells[FinalSteps[i]].x2top - 20, Cells[FinalSteps[i]].y2top + 10);
                        FinalResult = FinalResult + Steps[i] + ",";
                    }
                    gr.DrawLine(SolutionPen, Cells[FinalSteps[FinalSteps.Count - 1]].xright, Cells[FinalSteps[FinalSteps.Count - 1]].yright + 25, Cells[FinalSteps[FinalSteps.Count - 1]].x2left + 25, Cells[FinalSteps[FinalSteps.Count - 1]].y2left + 25);
                }

                //empty
            }

            

        }



        void visit(int[] p)
        {

        }
        void button1_Click_1(object sender, EventArgs e)
        {




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();
            for (int r = 0; r <= 55; r++)
            {

                Cells[r].Top = true;
                Cells[r].Right = true;
                Cells[r].Bottom = true;
                Cells[r].Left = true;
                gr.DrawLine(myPen, Cells[r].xtop, Cells[r].ytop, Cells[r].x2top, Cells[r].y2top);
                gr.DrawLine(myPen, Cells[r].xright, Cells[r].yright, Cells[r].x2right, Cells[r].y2right);
                gr.DrawLine(myPen, Cells[r].xbottom, Cells[r].ybottom, Cells[r].x2bottom, Cells[r].y2bottom);
                gr.DrawLine(myPen, Cells[r].xleft, Cells[r].yleft, Cells[r].x2left, Cells[r].y2left);
            }

            //reset
            int temporary = 0;
            int up = 0;
            int right = 0;
            int down = 0;
            int left = 0;
            int VarElse = 0;
            int LastVisited = 0;

            int[] possibility = { };

            int[] tempneighbor;
            bool Visited;
            int current = 0;
            int BinaryTree = 0;
            int entropy = 0;  //wave function collapse var
            int pick = 0;
            int[] valaszthato = new int[55];

            int experimental = 1; //experimental featurek engedélyezése

            //for selectmode 5
            int elso = 0;
            int masodik = 0;
            int harmadik = 0;
            int negyedik = 0;
        }
    }
}

