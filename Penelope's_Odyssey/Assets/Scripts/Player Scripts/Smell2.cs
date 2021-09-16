using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smell2 : MonoBehaviour
{
    public LineRenderer line; //to hold the line Renderer
    public Transform target; //to hold the transform of the target
    public NavMeshAgent agent; //to hold the agent of this gameObject
    public NavMeshPath path;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line.positionCount = 1;
            StartCoroutine("getPath");
        }

        if(Input.GetMouseButtonUp(0))
        {
            line.positionCount = 0;
            StopCoroutine("getPath");
        }
    }

    IEnumerator getPath()
    {
        line.SetPosition(0, agent.transform.position); //set the line's origin

        agent.SetDestination(target.position); //create the path
        yield return new WaitForEndOfFrame(); //wait for the path to generate

        NavMesh.CalculatePath(agent.transform.position, target.transform.position, NavMesh.AllAreas, path);

        DrawPath(agent.path);
    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners
        line.SetPositions(path.corners);
    }
}
