using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{

    public int foodEaten;
    public GameManager GameManager;

    private void Start()
    {
        foodEaten = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            foodEaten += 1;
            GameManager.hunger = 100;
            other.gameObject.SetActive(false);
        }
    }

}
