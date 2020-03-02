using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreation : MonoBehaviour
{
    public GameObject Letters;

    public GameObject Numbers;

    public GameObject Cells;

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

        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                Cells.GetComponent<Characters>().Index = 0;
                cells[i, j] = Instantiate(Cells);
                cells[i, j].transform.position = new Vector3(x, y, startPosition.z);
                x += 0.5f;
            }

            x = startPosition.x + 0.5f;
            y -= 0.5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
