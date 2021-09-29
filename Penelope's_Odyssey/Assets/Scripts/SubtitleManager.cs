using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour
{

    public GameObject textBox;
    
    void Start()
    {
        StartCoroutine("Sequence");
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "WASD to move.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Space to jump.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Click to stop & sniff.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Watch your hunger meter -- don't let Penelope starve!";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";

    }

}
