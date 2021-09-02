using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Smell : MonoBehaviour
{
    private LineRenderer line;
    private GameObject player;
    private GameObject food;

    private Vector3 playerPos;
    private Vector3 foodPos;
    
    public int lengthOfLineRenderer = 2;


    // Start is called before the first frame update
    void Start()
    {
        //Find necessary objects
        food = GameObject.FindGameObjectWithTag("food");
        player = GameObject.FindGameObjectWithTag("Player");
        line = gameObject.GetComponent<LineRenderer>();

        //Disable line initially
        line.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Variable to hold line endpoints
        var points = new Vector3[lengthOfLineRenderer];

        // Update player and food positions
        playerPos = player.transform.position;
        foodPos = food.transform.position;

        // Set endpoint values
        points[0] = playerPos;
        points[1] = food.transform.position;

        // If player clicks, show the scent line
        if (Input.GetMouseButtonDown(0))
        {
            line.enabled = true;
            if(Physics.Linecast(playerPos, food.transform.position))
                line.SetPositions(points);
        }

        // Disable scent line
        if(Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
    }
}
