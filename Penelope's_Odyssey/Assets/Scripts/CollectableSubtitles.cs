using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSubtitles : MonoBehaviour
{

    public GameObject textBox;
    private GameObject foundObj;
    public SubtitleManager sm;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "object")
        {
            foundObj = other.gameObject;
            StartCoroutine("Found");
        }

        if(other.tag == "exit")
        {
            sm.StartCoroutine("Win");
        }
    }

    IEnumerator Found()
    {
        if(foundObj.name == "BaseballHat")
        {
            textBox.GetComponent<Text>().text = "She tried to put this on me while we were playing, but it was too bigÅE";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if(foundObj.name == "Compass")
        {
            textBox.GetComponent<Text>().text = "She used this whenever we would play out the stories from her books. I wonder what itís used forÅE";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "SquishMouse")
        {
            textBox.GetComponent<Text>().text = "I would sleep on this whenever I snuck out during the night. Itís super comfy, though she did almost crush me rolling onto it one night.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Book")
        {
            textBox.GetComponent<Text>().text = "She would read this to me every night. Itís about someone trying to get home to their family no matter whatÅEI miss hearing it.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Backpack")
        {
            textBox.GetComponent<Text>().text = "It matches mine! She was so excited when she gave it to me.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }

    }
}
