using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject MenuRoot;

    public float hunger = 100;
    public float sub = 2;
    public Slider HungerBar;
    public TextMeshProUGUI loseText;

    private void Start()
    {
        MenuRoot.SetActive(false);
        loseText.enabled = false;
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
        loseText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");
    }
}
