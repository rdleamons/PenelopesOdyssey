using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smell : MonoBehaviour
{
    public LineRenderer line; //to hold the line Renderer
    //public Transform target;
    private NavMeshPath path;
    public CharacterController controller;
    public AudioSource audioSource;
    public ParticleSystem[] hotdog;

    //public GameObject[] targets;
    public List<GameObject> targets = new List<GameObject>();
    private GameObject target;

    void Start()
    {
        path = new NavMeshPath();
        target = targets[0];
    }

    void Update()
    {
        // Calculate NavMesh path.
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, path);

        // Draw the path on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            DrawPath(path);
            audioSource.Play();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < hotdog.Length; i++)
            {
                hotdog[i].Play();
            }
        }

        // Stop drawing path when no longer clicking
        if (Input.GetMouseButtonUp(0))
        {
            line.positionCount = 0;
            
        }
        else if (Input.GetMouseButtonUp(1))
        {
            for (int i = 0; i < hotdog.Length; i++)
            {
                hotdog[i].Stop();
            }
        }

    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners
        line.SetPositions(path.corners);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.name)
        {
            targets.Remove(other.gameObject);
            target = targets[0];

        }
        else if(other.gameObject.CompareTag("object") && other.gameObject.name != target.name)
        {
            targets.Remove(other.gameObject);
        }
    }
}
