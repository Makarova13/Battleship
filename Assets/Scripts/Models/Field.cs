using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Field
    {
        public Cell[] Cells { get; set; }

        public Field()
        {
            Cells = new Cell[100];
        }

        public bool CheckIfShipCanBePlaced(int x, int y)
        {
            var neighbours = GetNeighbours(x, y);

            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i] != null)
                {
                    CellState state = neighbours[i].State;

                    switch (state)
                    {
                        case CellState.Empty:
                            break;
                        case CellState.Boat:
                            return false;
                    }
                }
            }

            return true;
        }

        public Cell[] GetNeighbours(int x, int y)
        {
            var neighbours = new Cell[9];

            neighbours[0] = GetCell(x + 1, y + 1);
            neighbours[1] = GetCell(x, y + 1);
            neighbours[2] = GetCell(x - 1, y + 1);
            neighbours[3] = GetCell(x + 1, y);
            neighbours[4] = GetCell(x, y);
            neighbours[5] = GetCell(x - 1, y);
            neighbours[6] = GetCell(x + 1, y - 1);
            neighbours[7] = GetCell(x, y - 1);
            neighbours[8] = GetCell(x - 1, y - 1);

            return neighbours;
        }

        public Cell GetCell(int x, int y)
        {
            foreach (var cell in Cells)
            {
                if (cell.X == x && cell.Y == y)
                {
                    return cell;
                }
            }

            return null;
        }
    }
}
