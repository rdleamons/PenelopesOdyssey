using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Invector.vCharacterController;

public class Smell : MonoBehaviour
{
    public GameManager gm;
    public LineRenderer line; //to hold the line Renderer
    //public Transform target;
    private NavMeshPath path;
    public AudioSource audioSource;
    public ParticleSystem[] hotdog;

    //public GameObject[] targets;
    public List<GameObject> targets = new List<GameObject>();
    private GameObject target;

    public GameObject backpackFoundIcon;
    public GameObject compassFoundIcon;
    public GameObject squishFoundIcon;
    public GameObject bookFoundIcon;
    public GameObject crownFoundIcon;

    private vThirdPersonController controller;

    /*
    public GameObject backpackIcon;
    public GameObject compassIcon;
    public GameObject squishIcon;
    public GameObject bookIcon;
    public GameObject crownIcon;
    */
    void Start()
    {
        path = new NavMeshPath();
        target = targets[0];
        controller = GetComponent<vThirdPersonController>();

        backpackFoundIcon.gameObject.SetActive(false);
        compassFoundIcon.gameObject.SetActive(false);
        squishFoundIcon.gameObject.SetActive(false);
        bookFoundIcon.gameObject.SetActive(false);
        crownFoundIcon.gameObject.SetActive(false);
        
    }

    void Update()
    {
        // Calculate NavMesh path.
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, path);

        // Draw the path on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            controller.lockMovement = true;
            DrawPath(path);

            if(gm.paused == false)
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
            controller.lockMovement = false;
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
        if (other.gameObject.CompareTag("object"))//other.gameObject.name == target.name )
        {
            targets.Remove(other.gameObject);
            target = targets[0];
        }
        /*
        else if(other.gameObject.CompareTag("object") && other.gameObject.name != target.name)
        {
            targets.Remove(other.gameObject);
        }
        */

        if (other.gameObject.name == "Backpack")
            backpackFoundIcon.gameObject.SetActive(true);
        else if (other.gameObject.name == "Compass")
            compassFoundIcon.gameObject.SetActive(true);
        else if (other.gameObject.name == "SquishMouse")
            squishFoundIcon.gameObject.SetActive(true);
        else if (other.gameObject.name == "Book")
            bookFoundIcon.gameObject.SetActive(true);
        else if (other.gameObject.name == "BaseballHat")
            crownFoundIcon.gameObject.SetActive(true);
    }
}
