using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : SnakePart
{
    private Rigidbody2D rigidbody;

    private bool makeTurn = false;
    private Vector2 turnPosition;
    private bool aTurn;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = moveVektor;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeTurn)
        {
            // Debug.Log("X= " + transform.position.x);
            //  Debug.Log("Potion: " + transform.position + "\n" + "To: " + turnPosition + "\n\n\n");

            float xPosition = transform.position.x;
            float yPosition = transform.position.y;

            float turnX = turnPosition.x;
            float turnY = turnPosition.y;

            xPosition = cutOf(xPosition);
            yPosition = cutOf(yPosition);

            turnX = cutOf(turnX);
            turnY = cutOf(turnY);


            if ((xPosition == turnX && yPosition == turnY) ||isBeountLimit(turnPosition))
            {

                makeTurn = false;
                if (aTurn)
                {
                    moveVektor = rotateVektorIn2d(moveVektor, 90);
                }
                else
                {
                    moveVektor = rotateVektorIn2d(moveVektor, -90);
                }

                if (getNextElement() != null)
                {
                    getNextElement().makeRotaton(turnPosition, aTurn);
                }
                rigidbody.velocity = moveVektor;

                transform.position = turnPosition;

            }
        }

    }

    private float cutOf(float input)
    {
        return (float)(Math.Floor(input * 100) / 100);
    }

    public void makeRotaton(Vector2 position, bool aTurn)
    {
        makeTurn = true;
        turnPosition = position;
        this.aTurn = aTurn;
    }

}
