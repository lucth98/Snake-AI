using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Snake : ScriptableObject
{
    private List<SnakePart> snake = new List<SnakePart>();

    private KeyCode buttonTurnLeft = KeyCode.A;
    private KeyCode buttonTurnRight = KeyCode.D;



    SnakeHead snakeHeadpre;// = Resources.Load<SnakeHead>("SnakeHeadObject");
    //SnakeBody snakeBodypre = Resources.Load<SnakeBody>("SnakeBodyObject");

    private Grid Grid;

    public Grid getGrid()
    {
        return Grid;
    }

    public int getSnakeLenght()
    {
        return snake.Count;
    }

    public void setTurnButtons(KeyCode buttonTurnLeft, KeyCode buttonTurnRight)
    {
        this.buttonTurnLeft = buttonTurnLeft;
        this.buttonTurnRight = buttonTurnRight;
    }

    public void move()
    {
        snake[0].moveSnakePart();
        //test for comit
    }

    public void turn()
    {
        if (snake[0].turnRequiret)
        {
            return;
        }

        if (Input.GetKeyDown(buttonTurnLeft))
        {
            snake[0].turn(false);
        }
        if (Input.GetKeyDown(buttonTurnRight))
        {
            snake[0].turn(true);

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            addSnakePart();

        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            reset();

        }
    }

    public void addPartToList(SnakePart part)
    {
        snake.Add(part);


    }

    public Vector2 getHeadPosition()
    {
        Vector2 position = new Vector2();

        position.x = snake[0].x;
        position.y = snake[0].y;

        return position;

    }

    public void addSnakePart()
    {
        snake[0].addBodyPart();
    }

    public void addBodyToSnake(SnakeBody body)
    {
        snake.Add(body);
    }

    public void changeSpeed(float newSpeed)
    {
        foreach (SnakePart b in snake)
        {
            //Debug.Log("change Speed" + "length= " + snake.Count);
            b.changeSpeed(newSpeed);
        }
    }

    public void init(int x, int y, Grid grid)
    {
      //  snakeHeadpre = Resources.Load<SnakeHead>("SnakeHeadObject");
        SnakeHead head = GameObject.Find("GameObject.Find")   //Instantiate(snakeHeadpre, new Vector3(x, y, -2), Quaternion.identity);
        head.transform
        head.direction = SnakePart.Direction.right;
        head.grid = grid;
        head.snake = this;

        head.init();
        snake.Add(head);


        this.Grid = grid;

        move();
    }

    public void reset()
    {
        if (snake.Count > 1)
        {

            for (int i = 1; i < snake.Count; i++)
            {
                snake[i].deliteSnakePart();
                snake.RemoveAt(i);
                i--;
            }
        }

        //Reset Snake Head
        Vector2 newHeadPosition = new Vector2(Grid.height / 2, Grid.with / 2);
        snake[0].teleportPart(newHeadPosition);
        snake[0].moveSnakePart();
        snake[0].nextElement = null;


        Grid.reset();
    }


    public void makeAITurn(bool turnRight)
    {
        if (!snake[0].turnRequiret)
        {
            //dreht die schlage
            snake[0].turn(turnRight);
        }
    }



}
