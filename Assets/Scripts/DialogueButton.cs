using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    bool isEnable = false;
    public void GetNextLine()
    {
        if(isEnable) DialogueManager.instance.DequeueDialogue();

    }

    public void OnOpen()
    {
        isEnable = false;
        Invoke("CD", 0.1f);
    }

    public void CD()
    {
        isEnable = true;
    }

}
