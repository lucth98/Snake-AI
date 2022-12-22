using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public Grid grid { get;  set; }
    public Tile tile { get; set; }

    public void deliteToken()
    {
        Destroy(gameObject);
    }
    public virtual void action(Snake snake)
    {

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
