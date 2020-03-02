using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreation : MonoBehaviour
{
    public GameObject Letters;
    public GameObject Numbers;
    public GameObject Cells;
    public Field Field;

    private GameObject[] letters;
    private GameObject[] numbers;
    private GameObject[,] cells;

    private const int fieldSize = 10;

    private void DrawField()
    {
        var startPosition = transform.position;

        DrawCharacters(startPosition);
        DrawBoard(startPosition);
    }

    private void DrawCharacters(Vector3 startPosition)
    {
        float x = startPosition.x + 0.5f;
        float y = startPosition.y - 0.5f;

        letters = new GameObject[fieldSize];
        numbers = new GameObject[fieldSize];

        for (int i = 0; i < fieldSize; i++)
        {
            Letters.GetComponent<Characters>().Index = i;
            letters[i] = Instantiate(Letters);
            letters[i].transform.position = new Vector3(x, startPosition.y, startPosition.z);
            x += 0.5f;

            Numbers.GetComponent<Characters>().Index = i;
            numbers[i] = Instantiate(Numbers);
            numbers[i].transform.position = new Vector3(startPosition.x, y, startPosition.z);
            y -= 0.5f;
        }
    }

    private void DrawBoard(Vector3 startPosition)
    {
        float x = startPosition.x + 0.5f;
        float y = startPosition.y - 0.5f;

        cells = new GameObject[fieldSize, fieldSize];
        Field = new Field();
        int cellIndex = 0;

        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                Cells.GetComponent<Characters>().Index = 0;
                cells[i, j] = Instantiate(Cells);
                cells[i, j].transform.position = new Vector3(x, y, startPosition.z);
                x += 0.5f;

                cells[i, j].GetComponent<ClickOnCellProcessing>().cell.Parent = this.gameObject;
                cells[i, j].GetComponent<ClickOnCellProcessing>().cell.X = i;
                cells[i, j].GetComponent<ClickOnCellProcessing>().cell.Y = j;

                Field.Cells[cellIndex] = cells[i, j].GetComponent<ClickOnCellProcessing>().cell;
                cellIndex++;
            }

            x = startPosition.x + 0.5f;
            y -= 0.5f;
        }
    }

    void Start()
    {
        DrawField();
    }

    void Update()
    {
        
    }

    public void Click(int x, int y, CellState state)
    {
        cells[x, y].GetComponent<Characters>().Index = (int)state;
        cells[x, y].GetComponent<ClickOnCellProcessing>().cell.State = state;
    }
}