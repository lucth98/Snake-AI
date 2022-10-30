using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    public int x { get; set; }
    public int y { get; set; }
    public SnakePart nextElement { get; set; }
    public Direction direction { get; set; }
    public enum Direction
    {
        up, down, left, right
    }

    private Tile positonTile; //eventuell unnötig
    private Tile turnTile;
    private bool nextTurn;

    SnakeBody snakeBodypre;// = Resources.Load<SnakeBody>("SnakeBodyObject");

    public Grid grid { get; set; }


    snakeMoveFunction snakeMove;


    public void turn(bool turnRight)
    {
        if (turnRight)
        {
            switch (direction)
            {
                case Direction.up:
                    direction = Direction.right;
                    break;

                case Direction.down:
                    direction = Direction.left;
                    break;

                case Direction.right:
                    direction = Direction.down;
                    break;

                case Direction.left:
                    direction = Direction.up;
                    break;
            }
        }

        else
        {
            switch (direction)
            {
                case Direction.up:
                    direction = Direction.left;
                    break;

                case Direction.down:
                    direction = Direction.right;
                    break;

                case Direction.right:
                    direction = Direction.up;
                    break;

                case Direction.left:
                    direction = Direction.down;
                    break;
            }
        }

        nextElement.informOfTurn(positonTile, turnRight);
    }

    public void informOfTurn(Tile positionOfTurn, bool turnRight)
    {
        this.nextTurn = turnRight;
        this.turnTile = positionOfTurn;
    }


    private void addBodyToCordinates(int x, int y)
    {
        //TODo shau ob neues Body Part im Spielfelt liegt
        SnakeBody newBodyPart = Instantiate(snakeBodypre, new Vector2(x, y), Quaternion.identity);

        newBodyPart.x = x;
        newBodyPart.y = y;


        newBodyPart.grid = grid;

        try
        {
            newBodyPart.positonTile = grid.getTile(x, y);
        }
        catch (Exception ex)
        {

        }
    }


    public void addBodyPart()
    {
        if (nextElement != null)
        {
            nextElement.addBodyPart();
        }
        else
        {
            switch (direction)
            {
                case Direction.up:
                    addBodyToCordinates(x, y - 1);
                    break;

                case Direction.down:
                    addBodyToCordinates(x, y + 1);
                    break;

                case Direction.right:
                    addBodyToCordinates(x - 1, y);
                    break;

                case Direction.left:
                    addBodyToCordinates(x + 1, y);
                    break;
            }
        }
    }

    public void moveSnakePart()
    {
        if (nextElement != null)
        {
            nextElement.moveSnakePart();
        }
        else
        {

            //in callback: wenn Bewegung fertig dann -> Schlange kopf wieder in bewegung setzen
        }

        int targedX = x;
        int targedY = y;

        switch (direction)
        {
            case Direction.up:
                targedY++;
                break;

            case Direction.down:
                targedY--;
                break;

            case Direction.right:
                targedX++;
                break;

            case Direction.left:
                targedY--;
                break;
        }

        //ToDo schau ob ziel im Spielfeld liegt
        //ToDo collisionsabfrage
        snakeMove.moveToSmoothly(new Vector2(targedX, targedY));
    }


    public void movedToPositonCallBack(int newX, int newY)  //wird von snakemove gerufen wenn eine bewegug fertig ist
    {
        this.x = newX;
        this.y = newY;

        try
        {
            this.positonTile = grid.getTile(x, y);
            positonTile.snake = this;
        }
        catch (Exception e)
        {

        }

        Vector2 turnPos = turnTile.getPostion();

        if (turnPos.x == this.x && turnPos.y == this.y)  //check ob sich im neuen Feld eine Trhung stafinden soll
        {
            turn(nextTurn);
        }

        if (nextElement == null)
        {
            grid.snake.move();// wenn alle elemte sich begt haben muss die nechtste bewegung beim kopf starten
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        snakeBodypre = Resources.Load<SnakeBody>("SnakeBodyObject");
        snakeMove = GetComponent<snakeMoveFunction>();
        snakeMove.SnakePart = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
