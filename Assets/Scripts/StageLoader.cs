using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField] stage[] stages;



    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadNewStage(stages);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
