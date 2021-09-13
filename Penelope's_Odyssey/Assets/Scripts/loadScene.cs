using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    public string sceneName;

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
            SceneManager.LoadScene("StartScreen");
        }
    }
}
