using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public DialogueBase dialogue;


    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
        Debug.Log("开始对话，配置：" + dialogue.name);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TriggerDialogue();
        }
    }
}
