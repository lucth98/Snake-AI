using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class SnakeHead : SnakePart
{
    private List<GameObject> listOfBodyParts = new List<GameObject>();
    private Rigidbody2D rigidbody;

    void addBodyPart()
    {
        GameObject lastElemet = getLastGameOpect();

        GameObject newBodyPart = new GameObject();
        newBodyPart.name = "Snake_BodyPart_Nr" + (listOfBodyParts.Count + 1);

        Rigidbody2D rigidbody2D = newBodyPart.AddComponent<Rigidbody2D>();
        SnakeBody snakeBody = newBodyPart.AddComponent<SnakeBody>();
        SpriteRenderer renderer = newBodyPart.AddComponent<SpriteRenderer>();


        rigidbody2D.gravityScale = 0;

        renderer.sprite = Resources.Load<Sprite>("Circle");




        // calculate the Position of the new Element
        float headSize = lastElemet.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector2 posissonOfTheHead = lastElemet.transform.position;
        Vector2 movmentVektorOfElement = lastElemet.GetComponent<SnakePart>().getMoveVektor();
        Vector2 positionOfNewElement = posissonOfTheHead - movmentVektorOfElement.normalized * headSize;

        snakeBody.setMoveVektor(movmentVektorOfElement);

        //set possion
        newBodyPart.transform.position = positionOfNewElement;

        listOfBodyParts.Add(newBodyPart);

        lastElemet.GetComponent<SnakePart>().setNextElement(snakeBody);
    }

    GameObject getLastGameOpect()
    {
        GameObject result;

        if (listOfBodyParts.Count == 0)
        {
            result = GameObject.Find("Head");
        }
        else
        {
            result = listOfBodyParts[listOfBodyParts.Count - 1];
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveVektor = Vector2.right;
        rigidbody.velocity = moveVektor;
        


    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GameObject.Find("Head").transform.position);
        movementAD();
    }

    private void setSpeed()
    {

    }

    private void movementAD()
    {
        SnakeBody nextElement = getNextElement();
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveVektor = rotateVektorIn2d(moveVektor, 90);


            if (nextElement != null)
            {
                getNextElement().makeRotaton(transform.position, true);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveVektor = rotateVektorIn2d(moveVektor, -90);

            if (nextElement != null)
            {
                getNextElement().makeRotaton(transform.position, false);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            addBodyPart();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            changeAllSpeed(1.2f);
        }

        rigidbody.velocity = moveVektor;
    }
    public void changeAllSpeed(float multiplicator)
    {
        this.moveVektor *= multiplicator;

        foreach (GameObject gameObject in listOfBodyParts)
        {
            gameObject.GetComponent<SnakePart>().changeSpeed(multiplicator);
        }
    }

}
