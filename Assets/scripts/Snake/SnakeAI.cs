using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class SnakeAI : Agent
{
    //  [Observable]
  // private CameraSensorComponent cameraSensor;

    private SnakeHead head;
    private Snake snake;
    private Grid grid;


    private float lastDistanceToInceaseToken = 0.0f;





    public void init()
    {
     //   cameraSensor = GetComponent<CameraSensorComponent>();
        head = GetComponent<SnakeHead>();
        snake = head.snake;

     //   cameraSensor.Camera = Camera.main;

        grid = snake.getGrid();

        lastDistanceToInceaseToken = calculateDistanz();
    }


    private float calculateDistanz()
    {
        Vector2 position = snake.getHeadPosition();

        List<IncreaseSizeToken> tokens = grid.increaseList;

        if (tokens.Count == 0)
        {
            return 100;
        }

        float newDistance = Vector2.Distance(position, tokens[0].getPosition());

        for (int i = 0; i < tokens.Count; i++)
        {
            float distance = Vector2.Distance(position, tokens[0].getPosition());

            if (distance < newDistance)
            {
                newDistance = distance;
            }
        }

        return newDistance;
    }

    private void distanceToTokenRewart()
    {


        float newDistance = calculateDistanz();

        if (newDistance < lastDistanceToInceaseToken)
        {
            AddReward(0.1f);
        }
        else
        {
            AddReward(-0.1f);
        }

        lastDistanceToInceaseToken = newDistance;
    }


    public override void OnEpisodeBegin()
    {

        // snake.reset();


    }

    public override void CollectObservations(VectorSensor sensor)
    {
        try
        {
            //Hier wird mit den sensor daten an die AI zu verbeiten geschickt


            //Anz an Elementen
            float snakeLenght = (float)snake.getSnakeLenght();
            sensor.AddObservation(snakeLenght);

            //distanz zum token
            sensor.AddObservation(lastDistanceToInceaseToken);
            Debug.Log("Ai Data length= " + snakeLenght + "distance to token= " + lastDistanceToInceaseToken);
        }catch (Exception ex)
        {

        }

    }



    public void aiDeath()
    {
        //AI punishment for Dying

        AddReward(-1f);
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
        try
        {
            float movment = actions.DiscreteActions[0];
            Debug.Log("descreteaction= " + movment);
            if(movment == 0)
            {
                Debug.Log("straigth ahead");
                return;
            }
            if(movment == 1)
            {
                Debug.Log("turn left");
                snake.makeAITurn(false);

            }
            if(movment == 2)
            {
                Debug.Log("turn right");
                snake.makeAITurn(true);
            }

        }
        catch (Exception e)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // init();
    }

    // Update is called once per frame
    void Update()
    {
        // RequestDecision();

    }
}
