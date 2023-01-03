using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class SnakeAI : Agent
{
    //  [Observable]
    private CameraSensorComponent cameraSensor;

    private SnakeHead head;
    private Snake snake;



    private void init()
    {
        cameraSensor = GetComponent<CameraSensorComponent>();
        head = GetComponent<SnakeHead>();
        snake = head.snake;

        cameraSensor.Camera = Camera.main;
    }



    public override void OnEpisodeBegin()
    {
 
       // snake.reset();


    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Hier wird mit den sensor daten an die AI zu verbeiten geschickt

        //Anz an Elementen
        float snakeLenght = (float)snake.getSnakeLenght();
        sensor.AddObservation(snakeLenght);

    }



    public void aiDeath()
    {
        //AI punishment for Dying

        AddReward(-50.0f);
        // Testen: Vieleicht straffe erh�hen mit l�nge zb strafe = -l�nge der Schlange -50

        snake.reset();
        EndEpisode();
    }

    public void snakeIncreaseReward()
    {
        AddReward(1.0f);
        // Testen: Vieleicht rewart erh�hen mit l�nge zb rewart = l�nge der Schlange
    }



    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("Des action= " + actions.DiscreteActions[0]);
        Debug.Log("Con action = " + actions.ContinuousActions[0]);
        snake.makeAITurn(actions.ContinuousActions[0] < 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
       // RequestDecision();
        
    }
}
