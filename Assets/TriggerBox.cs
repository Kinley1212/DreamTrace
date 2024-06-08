using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("ThisClicked:" + sceneName);
        Player.Instance.TextPanel.SetActive(true);


        Destroy(gameObject);    
    }

    void ClickThis()
    { 
    
    
    }
}
