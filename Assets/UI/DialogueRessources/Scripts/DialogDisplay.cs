using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;
    public GameObject continueButton;
    public GameObject dialog;
    public GameObject cutscene;
    public Animator animator;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;
    public static float dialogSpeed;

    private void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
        animator.SetBool("isOpen", true);
        animator.enabled = false;
        dialog.SetActive(true);
        continueButton.SetActive(true);
        DisplayLine();
        activeLineIndex += 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (activeLineIndex < 3)
            {
                DisplayLine();
                activeLineIndex += 1;
            }
            else
            {
                activeLineIndex += 1;
                animator.enabled = true;
                animator.SetBool("isOpen", false);
                speakerLeft.SetActive(false);
                speakerRight.SetActive(false);
                continueButton.SetActive(false);
                dialog.SetActive(false);
                cutscene.SetActive(true);
            }
        }
    }

    public void NextLine()
    {
        if (activeLineIndex < 3)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            activeLineIndex += 1;
            animator.enabled = true;
            animator.SetBool("isOpen", false);
            speakerLeft.SetActive(false);
            speakerRight.SetActive(false);
            continueButton.SetActive(false);
            dialog.SetActive(false);
            cutscene.SetActive(true);
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Characters character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerLeft, speakerRight, speakerUILeft, line.text, 1);
        }
        else
        {
            SetDialog(speakerRight, speakerLeft, speakerUIRight, line.text, 2);
        }
    }

    void SetDialog(
        GameObject activeSpeaker,
        GameObject inactiveSpeaker,
        SpeakerUI activeSpeakerUI,
        string text,
        int voice
        )
    {
        activeSpeakerUI.Dialog = text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));
        inactiveSpeaker.SetActive(false);
        activeSpeaker.SetActive(true);

        IEnumerator TypeSentence(string sentence)
        {
            activeSpeakerUI.Dialog = "";
            foreach (char letter in sentence.ToCharArray())
            {
                if (activeLineIndex <= 3)
                {
                    activeSpeakerUI.Dialog += letter;
                    if (voice == 1)
                        FindObjectOfType<audioManager>().Play("BipFather");
                    else if (voice == 2)
                        FindObjectOfType<audioManager>().Play("BipPlayer");
                    yield return new WaitForSeconds(dialogSpeed);
                }
            }
        }
    }

    
}
