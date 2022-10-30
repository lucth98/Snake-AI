using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    private int x { get; set; }
    private int y { get; set; }
    private SnakePart nextElement { get; set; }
    private Direction direction { get; set; }
    enum Direction
    {
        up, down, left, right
    }

    private Tile positonTile;
    private Tile TurnTile;


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

    public void informOfTurn(Tile positionOfTurn , bool turnRight)
    {
        //ToDo
    }

    public void moveSnakePart()
    {


        //ToDO
        nextElement.moveSnakePart();
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
