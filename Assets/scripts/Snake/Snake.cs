using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private List<SnakePart> snake = new List<SnakePart>();

    private KeyCode buttonTurnLeft = KeyCode.A;
    private KeyCode buttonTurnRight = KeyCode.D;

    SnakeHead snakeHeadpre;// = Resources.Load<SnakeHead>("SnakeHeadObject");
    //SnakeBody snakeBodypre = Resources.Load<SnakeBody>("SnakeBodyObject");

    private Grid Grid;
    public void setTurnButtons(KeyCode buttonTurnLeft, KeyCode buttonTurnRight)
    {
        this.buttonTurnLeft = buttonTurnLeft;
        this.buttonTurnRight = buttonTurnRight;
    }

    public void move()
    {
        snake[0].moveSnakePart();
    }

    public void turn()
    {
        Debug.Log("Turn in Snake" );
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
    }

    public void addSnakePart()
    {
        snake[0].addBodyPart();
    }

    public void addBodyToSnake(SnakeBody body)
    {
        snake.Add(body);
    }


    public void init(int x, int y, Grid grid)
    {
        snakeHeadpre = Resources.Load<SnakeHead>("SnakeHeadObject");
        SnakeHead head = Instantiate(snakeHeadpre, new Vector3(x, y,-2), Quaternion.identity);
        head.direction = SnakePart.Direction.right;
        head.grid = grid;
        head.init();
        snake.Add(head);


        this.Grid = grid;

        move(); 
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
