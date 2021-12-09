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

    //public GameObject winScreen;
    public GameObject loseScreen;

    public vThirdPersonController controller;
    public GameManager gm;
    public Collection collection;


    private List<string> lines;
    private int index;

    // Set tutorial text as active
    void Start()
    {
        lines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/tutorialText.txt"));
        index = 0;
        subtitles.SetActive(true);
        textBox.GetComponent<Text>().text = lines[0];
        //winScreen.SetActive(false);
        loseScreen.SetActive(false);

        StartCoroutine("stopMove");
    }

    private void Update()
    {
        // If the text is null, turn off the text box UI
        if (textBox.GetComponent<Text>().text == "")
            subtitles.gameObject.SetActive(false);
        else
            subtitles.gameObject.SetActive(true);

        // If player hits enter, scroll through the text. 
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
        else if(other.CompareTag("object"))// Doesnt have any hotdogs .))
        {
            foundObj = other.gameObject;
            StartCoroutine("Found");
        }

        if(other.CompareTag("food"))
        {
            if(collection.foodEaten == 1)
            {
                foundObj = other.gameObject;
                StartCoroutine("Found");
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            StartCoroutine("TurnBack");
        }
    }

    IEnumerator Win()
    {
        subtitles.gameObject.SetActive(true);
        textBox.GetComponent<Text>().text = "I think she went this way!";
        yield return new WaitForSeconds(3);

        //winScreen.SetActive(true);
        //yield return new WaitForSeconds(5);
        SceneManager.LoadScene("EndCut");
    }

    IEnumerator Lose()
    {
        subtitles.gameObject.SetActive(true);
        textBox.GetComponent<Text>().text = "I don't feel so good... ";

        yield return new WaitForSeconds(3);
        loseScreen.SetActive(true);
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
            textBox.GetComponent<Text>().text = "She used this whenever we would play out the stories from her books. I wonder what it's used forÅ?";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "SquishMouse")
        {
            textBox.GetComponent<Text>().text = "I would sleep on this whenever I snuck out during the night. It's super comfy, but she did almost crush me rolling onto it one night.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }
        else if (foundObj.name == "Book")
        {
            textBox.GetComponent<Text>().text = "She would read this to me every night. It's about someone trying to get home to their family no matter whatÅ. I miss hearing it . . .";
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
            textBox.GetComponent<Text>().text = "Oh! She used to give me bits of these as treats!";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
        }

    }

    IEnumerator TurnBack()
    {
        textBox.GetComponent<Text>().text = "I'm losing her scent! I should turn back.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
    }


    IEnumerator stopMove()
    {
        Debug.Log("Stop???");
        controller.lockMovement = true;
        controller.lockRotation = true;

        yield return new WaitUntil(() => index > lines.Count - 2);

        controller.lockMovement = false;
        controller.lockRotation = false;
    }
}
