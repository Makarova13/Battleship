using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCellProcessing : MonoBehaviour
{
    public Cell cell = new Cell();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(cell.Parent != null)
        {
            cell.Parent.GetComponent<FieldCreation>().Click(cell.X, cell.Y);
        }
        else
        {
            Debug.Log("cell null");
        }
    }
}
