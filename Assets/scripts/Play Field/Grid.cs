using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid : MonoBehaviour
{

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
                var newTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);

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
        camera.transform.position = new Vector3(((float)with) / 2, ((float)height) / 2,-1);
        if (height >= with)
        {
            camera.orthographicSize = (float)height / 2;
        }
        else
        {
            camera.orthographicSize = (float)with / 2;
        }
        camera.backgroundColor= Color.white;    
    }

    // Start is called before the first frame update
    void Start()
    {
        tile = Resources.Load<Tile>("TileObject");
        field = new Tile[height, with];
        moveCamera();
        drawGrid();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
