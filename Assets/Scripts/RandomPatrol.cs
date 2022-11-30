using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour{

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;
    public float minSpeed;
    public float maxSpeed;

    public int secondsToMaxSpeed;
    
    Vector2 targetPosition;
    Vector3 initialPosition;
    public GameObject restartPanel;


    // Start is called before the first frame update
    void Start(){
        secondsToMaxSpeed = 30;
        minSpeed = 0.75f;
        maxSpeed = 2.0f;
        minX = -8.31f;
        maxX = 8.4f;
        minY = -4.41f;
        maxY = 4.45f;

        initialPosition = new Vector3(getRandomPosition().x, getRandomPosition().y, 0.0f);
        transform.position = transform.position + initialPosition;

        //Debug.Log(initialPosition);
        targetPosition = getRandomPosition();

    }

    // Update is called once per frame
    void Update(){

        float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultypercentage());
        if ((Vector2) transform.position != targetPosition){
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed*Time.deltaTime);
        }
        else{
            targetPosition = getRandomPosition();
        }
    }


    Vector2 getRandomPosition(){
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        Vector2 v = new Vector2(randX,randY);
        return v;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //Debug.Log("collided with a: " + collision.tag);
        //Debug.Log(collision);
        if (collision.tag == "Planet") {
            //Debug.Log("planet");
            PlanetCreation.instance.pause();
            restartPanel.SetActive(true);
        }
    }


    private float getDifficultypercentage(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed);
    }


}
