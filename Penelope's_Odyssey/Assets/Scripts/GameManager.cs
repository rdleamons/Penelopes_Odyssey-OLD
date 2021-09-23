using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Need to add win condition to this script -- currently, it's in loadScene. 
    public float hunger = 100;
    public float sub = 2;
    public Slider HungerBar;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;
    public Movement movement;

    private void Start()
    {
        loseText.enabled = false;
        winText.enabled = false;
    }

    void Update()
    {
        getHunger();
        UpdateScreen();

        if(hunger <= 0)
        {
            StartCoroutine("lose");
        }
    }

    public float getHunger()
    {
        hunger = hunger - sub / 180;
        return hunger;
    }

    public void UpdateScreen()
    {
        HungerBar.value = hunger;
    }

    IEnumerator lose()
    {
        movement.canMove = false;
        loseText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator win()
    {
        movement.canMove = false;
        winText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");

    }
}
