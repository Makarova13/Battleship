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
        public GameObject Parent;
        public CellState State = 0;

        public int X;
        public int Y;
    }
}
