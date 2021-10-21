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
        textBox.GetComponent<Text>().text = "Sniffing will also show the location of food.";
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

}
