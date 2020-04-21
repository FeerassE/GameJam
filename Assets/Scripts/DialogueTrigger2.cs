using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue2()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
