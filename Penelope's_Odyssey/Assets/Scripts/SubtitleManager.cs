using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class SubtitleManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject subtitles;
    private int index;

    private List<string> lines;

    void Start()
    {
        lines = new List<string>(File.ReadAllLines("D:/Senior Project/PenelopesOdyssey/Penelope's_Odyssey/Assets/tutorialText.txt")); 
        index = 0;
        subtitles.SetActive(true);
        textBox.GetComponent<Text>().text = lines[0];
    }

    private void Update()
    {
        if(textBox.GetComponent<Text>().text == "")
        {
            subtitles.gameObject.SetActive(false);
        }
        else
        {
            subtitles.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            index++;
            textBox.GetComponent<Text>().text = lines[index];
        }

        if(index == lines.Count)
        {
            textBox.GetComponent<Text>().text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("food"))
        {
            textBox.GetComponent<Text>().text = "I am getting hungry. Oh! She used to give me bits of these as treats!";
        }
    }


    /*
    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Penelope's owner hasn't been home in a few days, and she's getting worried.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "It's been a while since she’s come to play with me. Is she okay?";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "She’s never been gone so long. Oh no! Is she in trouble?! I have to find her!";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Use WASD to move.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "I’m real good at sneaking out of my cage! The big ones never seemed to like that very much though.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Use space to jump.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Click & hold the left mouse button to stop and sniff for objects that could lead to Penelope's owner.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "This is hers. I can use its scent to find her! Hopefully I can find more along the way.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Click & hold the right mouse button to stop and sniff for food.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Oh, I was getting hungry. Oh! She used to give me bits of these as treats!";
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
        textBox.GetComponent<Text>().text = "She must have gone this way! Don’t worry I’m on my way! I’ll save you no matter what!";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
    }
    */

}
