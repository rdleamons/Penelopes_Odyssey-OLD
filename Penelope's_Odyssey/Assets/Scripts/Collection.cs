using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // Can be added to movement/manager later

    public int foodEaten;
    public GameManager1 manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            foodEaten += 1;
            manager.hunger = 100;
            Destroy(other.gameObject);
        }
    }

}
