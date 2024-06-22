using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogueBase myDialogue;

    //Handler 在点击时触发
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        eventHandler.Invoke();
        DialogueManager.instance.CloseOption();

        if (myDialogue != null)
        {
            DialogueManager.instance.EnqueueDialogue(myDialogue);
            Debug.Log("开始对话，配置：" + myDialogue.name);
        }

    }
}
