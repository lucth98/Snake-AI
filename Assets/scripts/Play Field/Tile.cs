using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isBarrier = false;
    public SnakePart snake { get; set; }
    public Token token { get; set; }
    public void setCollor(bool type)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (type)
        {
            spriteRenderer.color = new Color32(62, 250, 147, 255);
        }
        else
        {
            spriteRenderer.color = new Color32(137, 250, 188, 255);
        }
    }

    public void makeBarrier()
    {
        isBarrier = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
    }

    public bool isThisBarrier()
    {
        return isBarrier;
    }


    public Vector2 getPostion()
    {
        return transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    internal void setWhiteColor()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(250, 250, 250, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
