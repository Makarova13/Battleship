using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public Sprite[] Img;

    public int Index = 0;

    private void ChangeImage()
    {
        if (Index < Img.Length) 
        {
            GetComponent<SpriteRenderer>().sprite = Img[Index];
        }
    }
    void Start()
    {
        ChangeImage();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeImage();
    }
}
