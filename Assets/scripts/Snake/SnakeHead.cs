using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakePart
{
    

    public override void collisionAction()
    {
        snake.changeSpeed(0f);
    }

    public override void tokenAction(Token token)
    {
        token.action(snake);
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
