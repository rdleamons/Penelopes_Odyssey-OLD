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

    public float getHunger()
    {
        hunger = hunger - sub/1800;
        return hunger;
    }

    public void UpdateScreen()
    {
        HungerBar.value = hunger;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getHunger();
        UpdateScreen();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadScentScene()
    {
        SceneManager.LoadScene("Path Testing");
    }
}
