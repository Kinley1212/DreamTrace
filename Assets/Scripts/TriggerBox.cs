using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBox : MonoBehaviour
{
    public string stageName;
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
        Debug.Log("ThisClicked:" + stageName);

        //SceneManager.LoadScene(sceneName);
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        GameManager.instance.Load(stageName);

        Destroy(gameObject);    
    }

    void ClickThis()
    { 
    
    
    }
}
