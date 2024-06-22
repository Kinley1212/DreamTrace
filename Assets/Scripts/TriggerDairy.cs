using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDairy : TriggerBox
{
    [Header("配置获取日记页")]
    public bool isLocked = false;
    public int dairyPage;
    public int dairyContentIndex;


    private new void OnMouseDown()
    {
        base.OnMouseDown();
        if (isLocked) return;
        GameManager.instance.GetDairy(dairyPage, dairyContentIndex);
    }

}
