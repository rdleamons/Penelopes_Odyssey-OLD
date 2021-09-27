using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject MenuRoot;

    // Need to add win condition to this script -- currently, it's in loadScene. 
    public float hunger = 100;
    public float sub = 2;
    public Slider HungerBar;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;
    //public Movement movement;

    private void Start()
    {
        MenuRoot.SetActive(false);
        loseText.enabled = false;
        winText.enabled = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (MenuRoot.activeSelf)
        {
            getHunger();
            UpdateScreen();
        }
        else
        {
            changeHunger();
            UpdateScreen();
        }


        // Lock cursor when clicking outside of menu
        if (!MenuRoot.activeSelf && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SetPauseMenuActivation(!MenuRoot.activeSelf);
        }

        if (hunger <= 0)
        {
            StartCoroutine("lose");
        }

        /*
        getHunger();
        UpdateScreen();

        if(hunger <= 0)
        {
            StartCoroutine("lose");
        }
        */
    }

    public float getHunger()
    {
        return hunger;
    }

    public float changeHunger()
    {
        hunger = hunger - sub / 180;
        return hunger;
    }

    public void UpdateScreen()
    {
        HungerBar.value = hunger;
    }

    public void ClosePauseMenu()
    {
        SetPauseMenuActivation(false);
    }

    void SetPauseMenuActivation(bool active)
    {
        MenuRoot.SetActive(active);

        if (MenuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

    }

    IEnumerator lose()
    {
        //movement.canMove = false;
        loseText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator win()
    {
        //movement.canMove = false;
        winText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");

    }
}
