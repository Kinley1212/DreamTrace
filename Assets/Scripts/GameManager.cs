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
public class GameManager : MonoBehaviour
{

    public static GameManager instance; 
    [SerializeField] stage[] stages;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); 
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
