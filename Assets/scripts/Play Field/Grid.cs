using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid : MonoBehaviour
{
    public Snake snake { get; private set; }

    private int height = 60;

    private int with = 60;

    private Tile tile;

    private Tile[,] field;
    public void drawGrid()
    {
        for (int x = 0; x < with; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var newTile = Instantiate(tile, new Vector3(x, y,1), Quaternion.identity);

                newTile.name = "Tile Pos: X=" + x + " Y=" + y;

                newTile.setCollor((x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0));

                field[y, x] = newTile;
            }
        }
    }

    public void setSize(int with, int height)
    {
        this.with = with;
        this.height = height;
    }

    private void moveCamera()
    {
        Camera camera = Camera.main;
        camera.transform.position = new Vector3(((float)with) / 2, ((float)height) / 2,-10);
        if (height >= with)
        {
            camera.orthographicSize = (float)height / 2 +2;
        }
        else
        {
            camera.orthographicSize = (float)with / 2+2;
        }
        camera.backgroundColor= Color.white;    
    }

    public Tile getTile(int x ,int y)
    {
        return field[y, x];
    }

    // Start is called before the first frame update
    void Start()
    {
        tile = Resources.Load<Tile>("TileObject");
        field = new Tile[height, with];
        moveCamera();
        drawGrid();

       initSnake();

    }

    private void initSnake()
    {
        snake = new Snake();
        snake.init(with / 2, height / 2, this);

        //ToDO RandPos

    }
    // Update is called once per frame
    void Update()
    {
        snake.turn();
    }
}
