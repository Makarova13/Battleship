using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Cell
    {
        private int[,] _neighbours;
        public GameObject Parent { get; set; }
        public CellState State { get; set; } = 0;

        public int X;
        public int Y;

        public static bool CellExists(int x, int y)
        {
            return (x >= 0) && (x <= 10) && (y >= 0) && (y <= 10);
        }
    }
}
