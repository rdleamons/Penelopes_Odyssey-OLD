using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{

    public int foodEaten;
    public GameManager GameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            foodEaten += 1;
            GameManager.hunger = 100;
            Destroy(other.gameObject);
        }
    }

}
