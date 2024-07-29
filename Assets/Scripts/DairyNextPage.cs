using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DairyNextPage : MonoBehaviour
{
    [SerializeField] GameObject[] objs;
    [SerializeField] GameObject BtnGoNext;

    [SerializeField] float delayTime = 0.5f;

    [Header("配置获取日记页")]
    public int dairyPage;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool CheckPageFinished()
    { 
         foreach (GameObject obj in objs)
        {
            if (!obj.activeSelf) return false;
        }

        BtnGoNext.SetActive(true);
        return true;    
    }

    public void GoNext()
    {
        Debug.Log("GoNext");

        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
        BtnGoNext.SetActive(false);
        GameManager.instance.GetDairy(dairyPage);
        SceneManager.LoadScene(sceneName);  
    }
}
