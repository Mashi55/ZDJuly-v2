using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsApp1
{
    public class Cell
    {
        public bool OOBTop = false;
        public bool OOBRight = false;
        public bool OOBBottom = false;
        public bool OOBLeft = false;

        public int Family = 0;

        public bool Cvisited = false; //Correction visited

        public bool Top = true;
        public bool Right = true;
        public bool Bottom = true;
        public bool Left = true;
        public bool Visited = false;
        public bool SV = false;   //Solution Visited
        public int Neighbours = 0;
        public int[] Neighbour= {0,0,0,0 };
        public List<int> EntropyPossible = new List<int>
        {
            0,1,2
        };
        public int pos;
        public int entropy;
        public int[] possible = { 0, 1, 2, 3, 4 };
        public bool Frontier = false;
        //top
        public float xtop;
        public float ytop;
        public float x2top;
        public float y2top;

        //right
        public float xright;
        public float yright;
        public float x2right;
        public float y2right;

        //bottom
        public float xbottom;
        public float ybottom;
        public float x2bottom;
        public float y2bottom;

        //left
        public float xleft;
        public float yleft;
        public float x2left;
        public float y2left;



        public Cell(/*bool Toppos, bool Rightpos, bool Bottompos, bool Leftpos, bool Visitedstatus,*/ float x1top, float y1top, float xtwotop, float ytwotop, float x1right, float y1right, float xtworight, float ytworight, float x1bottom, float y1bottom, float xtwobottom, float ytwobottom, float x1left, float y1left, float xtwoleft, float ytwoleft)
        {
            /*Top = Toppos;
            Right = Rightpos;
            Bottom = Bottompos;
            Left = Leftpos;
            Visited = Visitedstatus;
            */
            xtop = x1top;
            ytop = y1top;
            x2top = xtwotop;
            y2top = ytwotop;

            xright = x1right;
            yright = y1right;
            x2right = xtworight;
            y2right = ytworight;

            xbottom = x1bottom;
            ybottom = y1bottom;
            x2bottom = xtwobottom;
            y2bottom = ytwobottom;

            xleft = x1left;
            yleft = y1left;
            x2left = xtwoleft;
            y2left = ytwoleft;
        }
       
        public int GetNeighbours()
        {
            return Neighbours;
        }

        public string GetNeighbour()
        {
            var val = String.Join(",", Neighbour.ToArray());
            return val;
        }
    }
}
