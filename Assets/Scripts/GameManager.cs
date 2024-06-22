using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public struct stage
{
    public GameObject stageObj;
    public string name;
    public int num;
}

[Serializable]
public struct Page
{
    public Sprite[] spr;
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] stage[] stages;
    [SerializeField] Page[] dairy;
    public int index;
    public int contentIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame udddddddddddddddddddddddddddpdate
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void GetDairy(int dairyPage, int dairyContentIndex)
    {
        index = dairyPage;
        contentIndex = dairyContentIndex;

        UIManager.instance.dairyImg.sprite = dairy[index].spr[contentIndex];
    }



    public void Load(string stageName)
    {
        foreach (stage stage in stages)
        {
            if (stage.name == stageName)
            {
                stage.stageObj.SetActive(true);
            }
            else
            {
                Debug.Log("stageName" + stageName);
                Debug.Log("stage.name" + stage.name);
                stage.stageObj.SetActive(false);
            }
        }
    }

    public void LoadNewStage(stage[] newStages)
    {
        stages = newStages;
    }

    public void UnlockDiary()
    { 
         UIManager.instance.dairyBtn.SetActive(true);
    }
}
