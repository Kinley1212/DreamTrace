using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDairyUnlock : MonoBehaviour
{

    //[SerializeField] TriggerBox[] triggerBoxes;
    [SerializeField] bool[] triggerBoxesTriggered;

    [SerializeField] float delayTime = 1f;

    [Header("配置获取日记页")]
    public bool isLocked = false;
    public int dairyPage;

    [Header("是否是获取日记内容页")]
    public bool isGetNewPagePart = false;
    public int dairyContentIndex;


    // Start is called before the first frame update
    void Start()
    {
        //triggerBoxesTriggered  = new bool[triggerBoxes.Length]; 
        for (int i = 0; i < triggerBoxesTriggered.Length; i++) { triggerBoxesTriggered[i] = false; }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UnlockTrigger(int index)
    {
        triggerBoxesTriggered[index] = true;

        Invoke("CheckUnlock", delayTime);
    }

    void CheckUnlock()
    {
        for (int i = 0; i < triggerBoxesTriggered.Length; i++) 
        {
            if (!triggerBoxesTriggered[i]) return;
        }


        if (isGetNewPagePart) GameManager.instance.GetDairy(dairyPage, dairyContentIndex);
        else GameManager.instance.GetDairy(dairyPage);
    }
}
