using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smell3 : MonoBehaviour
{
    public LineRenderer line; //to hold the line Renderer
    public Transform target;
    private NavMeshPath path;
    public CharacterController controller;
    public AudioSource audioSource;

    void Start()
    {
        path = new NavMeshPath();
    }

    void Update()
    {
        // Calculate NavMesh path.
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

        // Draw the path on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            DrawPath(path);
            audioSource.Play();
        }

        // Stop drawing path when no longer clicking
        if (Input.GetMouseButtonUp(0))
        {
            line.positionCount = 0;
        }

    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners
        line.SetPositions(path.corners);
    }
}
