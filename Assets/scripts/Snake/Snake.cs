using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private List<SnakePart> snake = new List<SnakePart>();

    private KeyCode buttonTurnLeft = KeyCode.A;
    private KeyCode buttonTurnRight = KeyCode.D;

    public void setTurnButtons(KeyCode buttonTurnLeft, KeyCode buttonTurnRight)
    {
        this.buttonTurnLeft = buttonTurnLeft;
        this.buttonTurnRight = buttonTurnRight;
    }

    public void move()
    {

    }

    private void turn()
    {
        if (Input.GetKeyDown(buttonTurnLeft))
        {
            
        }
        if (Input.GetKeyDown(buttonTurnRight))
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {

        snake.Add(new SnakeHead());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
