using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Player player;
    public Text dialogueText;
    public string[] dialogue;
    public string[] upgradeDialogue;
    public string[] goAwayDialogue;
    private int index;
    private int index2;
    private bool tutorialComplete = false;
    public int numberOfUpgrades;
    private bool firstDialogueDone = false;
    public GameObject disappearEffect;
    public float wordSpeed;
    public GameObject ContinueButton;
    public bool playerClose;
    public UpgradeUI upgradeUI;
    public bool done = false;
    public BossCamera boss;
    public GameObject text;
    // Update is called once per frame
    void Update()
    {
        

        if (!done)
        {
                if (Input.GetKeyDown(KeyCode.E) && playerClose)
                {
                    text.SetActive(false);
                    if (dialoguePanel.activeInHierarchy)
                    {
                        zeroText();
                    }
                    else
                    {
                        dialoguePanel.SetActive(true);
                        StartCoroutine(Typing());


                    }
                }
                if (dialogueText.text == dialogue[index])
                {
                    ContinueButton.SetActive(true);
                    if (Input.GetButtonDown("Fire1"))
                    {
                        NextLine();
                    }
                }
           
        }
        


    }

    public void zeroText()
    {
        index = 0;
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
    public void Reset()
    {
        dialogue = upgradeDialogue;
        index = 0;
        done = false;

    }
    void Die()
    {
        
        Instantiate(disappearEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    public void NextLine()
    {
        ContinueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            tutorialComplete = true;
            upgradeUI.ChooseUpgrades();
            numberOfUpgrades++;
            done = true;
            zeroText();
            boss.Passable(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
            text.SetActive(false);
            zeroText();
        }
    }
}
