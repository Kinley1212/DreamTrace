using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDairy : TriggerBox
{
    [Header("配置获取日记页")]
    public bool isLocked = false;
    public int dairyPage;

    [Header("是否是获取日记内容页")]
    public bool isGetNewPagePart = false;
    public int dairyContentIndex;


    private new void OnMouseDown()
    {
        if (DialogueManager.instance.inDialogue) return;
        base.OnMouseDown();
        if (isLocked) return;

        if(isGetNewPagePart) GameManager.instance.GetDairy(dairyPage, dairyContentIndex);
        else GameManager.instance.GetDairy(dairyPage);
    }

}
