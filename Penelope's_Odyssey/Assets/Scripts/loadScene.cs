using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class loadScene : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI winText;

    public Scene currentScene;
    //public Movement movement;

    private void Start()
    {
        //winText.enabled = false;
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            StartCoroutine("win");
        }
    }

    IEnumerator win()
    {
        //movement.canMove = false;
        winText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");

    }
}
