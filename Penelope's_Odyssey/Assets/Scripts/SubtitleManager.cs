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
        textBox.GetComponent<Text>().text = "Penelope's owner hasn't been home in a few days, and she's getting worried.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Thus, our brave hero sets out on a mission to find her owner.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Use WASD to move.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Use space to jump.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Click & hold to stop and sniff for objects that could lead to Penelope's owner.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Sniffing will also show the location of food.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Watch your hunger meter -- don't let Penelope starve!";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Press shift to sprint, but watch out! This will make your hunger decrease faster!";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "And most importantly: good luck!";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";


    }

}
