using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class loadScene : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI winText;

    private void Start()
    {
        winText.enabled = false;
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
        winText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScreen");

    }
}
