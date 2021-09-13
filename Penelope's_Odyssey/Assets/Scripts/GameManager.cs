using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float hunger = 100;
    public float sub = 2;
    public Slider HungerBar;
    

    void Update()
    {
        getHunger();
        UpdateScreen();

        if(hunger <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }
    }

    public float getHunger()
    {
        hunger = hunger - sub / 1800;
        return hunger;
    }

    public void UpdateScreen()
    {
        HungerBar.value = hunger;
    }
}
