using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDairy : TriggerBox
{

    public int dairyPage;
    public int dairyContentIndex;


    private void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.instance.GetDairy(dairyPage, dairyContentIndex);
    }

}
