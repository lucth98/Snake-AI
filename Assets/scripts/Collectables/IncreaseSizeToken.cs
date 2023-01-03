using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizeToken : Token
{

    public override void action(Snake snake)
    {
        snake.addSnakePart();
        grid.addIncreaseToken();
        grid.removeIncreaseTokenFormTokenList(this);


        tile.token = null;
        Destroy(gameObject);
       // Destroy(this);
    }

    public Vector2 getPosition()
    {
       return transform.position;
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
