using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizeToken : Token
{

    public override void action(Snake snake)
    {
        snake.addSnakePart();
        grid.addIncreaseToken();
        tile.token = null;
        Destroy(gameObject);
       // Destroy(this);
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
