using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerBox : MonoBehaviour
{
    public string stageName;
    public bool isOneTimeTrigger;

    public UnityEvent OnTrigger;

    [SerializeField] GameObject[] showObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnMouseDown()
    {
        Debug.Log("ThisClicked:" + stageName);

        //SceneManager.LoadScene(sceneName);
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        if (stageName != "") GameManager.instance.Load(stageName);
        if (isOneTimeTrigger) Destroy(gameObject);

        OnTrigger.Invoke();

        if (showObj.Length > 0)
        {
            foreach (GameObject obj in showObj)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }

            }
        }
    }

    void ClickThis()
    {


    }
}
