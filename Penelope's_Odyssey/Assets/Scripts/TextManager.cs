using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;

public class TextManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject subtitles;
    private GameObject foundObj;

    public vThirdPersonController controller;
    public GameManager gm;

    private List<string> lines;
    private int index;

    // Set tutorial text as active
    void Start()
    {
        lines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/tutorialText.txt"));
        index = 0;
        subtitles.SetActive(true);
        textBox.GetComponent<Text>().text = lines[0];
    }

    private void Update()
    {
        // If the text is null, turn off the text box UI
        if (textBox.GetComponent<Text>().text == "")
            subtitles.gameObject.SetActive(false);
        else
            subtitles.gameObject.SetActive(true);

        // If player hits enter, scroll through the text. !!! Check this
        if (Input.GetKeyDown(KeyCode.Return) && index != lines.Count)
        {
            index++;
            textBox.GetComponent<Text>().text = lines[index];
        }

        // If player dies, start lose conditon
        if (gm.hunger <= 0)
        {
            controller.lockMovement = true;
            StartCoroutine("Lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {       
        // Check if player runs into exit
        if (other.CompareTag("exit"))
            StartCoroutine("Win");

        // Check if player finds an object
        else if(other.CompareTag("object") || other.CompareTag("food"))
        {
            foundObj = other.gameObject;
            StartCoroutine("Found");
        }
    }

    IEnumerator Win()
    {
        subtitles.gameObject.SetActive(true);
        textBox.GetComponent<Text>().text = "She must have gone this way! Donít worry Iím on my way! Iíll save you no matter what!";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("CreditScroll");

    }

    IEnumerator Lose()
    {
        subtitles.gameObject.SetActive(true);
        textBox.GetComponent<Text>().text = "I don't feel too good... ";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("CreditScroll");
    }

    // Show text based on found object
    IEnumerator Found()
    {
        if (foundObj.name == "BaseballHat")
        {
            textBox.GetComponent<Text>().text = "She tried to put this on me while we were playing, but it was too bigÅ.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Compass")
        {
            textBox.GetComponent<Text>().text = "She used this whenever we would play out the stories from her books. I wonder what itís used forÅ?";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "SquishMouse")
        {
            textBox.GetComponent<Text>().text = "I would sleep on this whenever I snuck out during the night. Itís super comfy, but she did almost crush me rolling onto it one night.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Book")
        {
            textBox.GetComponent<Text>().text = "She would read this to me every night. Itís about someone trying to get home to their family no matter whatÅ. I miss hearing it . . .";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Backpack")
        {
            textBox.GetComponent<Text>().text = "It matches mine! She was so excited when she gave it to me.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }

        if (foundObj.CompareTag("food"))
        {
            textBox.GetComponent<Text>().text = "I am getting hungry. Oh! She used to give me bits of these as treats!";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }

    }

}
