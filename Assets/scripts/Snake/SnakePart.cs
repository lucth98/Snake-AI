using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
   
    public enum Rotation
    {
        clockwise, counterclockwise
    }

    private SnakeBody nextElement;
    public Vector2 moveVektor;

    public void setNextElement(SnakeBody body)
    {
        nextElement = body;
    }

    public SnakeBody getNextElement()
    {
        return nextElement;
    }

    public void setMoveVektor(Vector2 vector)
    {
        this.moveVektor = vector;
    }

    public Vector2 getMoveVektor()
    {
        return this.moveVektor;
    }

    public void changeSpeed(float multiplicator)
    {
        this.moveVektor *= multiplicator;

       
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Vector2 rotateVektorIn2d(Vector2 source, float angle)
    {
        return Quaternion.AngleAxis(angle, Vector3.forward) * source;
    }

    public bool isBeountLimit(Vector2 limit)
    {
        bool result = false;
        if (moveVektor != null)
        {
            
            Vector2 vector =new Vector2(moveVektor.x,moveVektor.y);
            vector.Normalize();

            vector.x = (float)Math.Round(vector.x);
            vector.y = (float)Math.Round(vector.y);
          
            Debug.Log("Vector:\nX="+vector.x+" Y="+vector.y+"\n");
            if (vector.Equals(Vector2.left))
            {

                Debug.Log("left");
                result = limit.x > transform.position.x;
            }
            else if (vector.Equals(Vector2.right))
            {
                Debug.Log("right");
                result = limit.x < transform.position.x;
            }
            else if (vector.Equals(Vector2.up))
            {
                Debug.Log("up");
                result = limit.y < transform.position.y;
            }
            else if (vector.Equals(Vector2.down))
            {
                Debug.Log("down");
                result = limit.y > transform.position.y;
            }
        }


        return result;
    }


}
