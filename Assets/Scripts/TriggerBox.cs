using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class TriggerBox : MonoBehaviour
{
    public string stageName;
    public bool isOneTimeTrigger;

    public UnityEvent OnTrigger;

    [SerializeField] GameObject[] showObj;

    [SerializeField] GameObject[] destoryObj;

    [Header("开启首次特殊对话")]
    public bool isOnce = false;
    public DialogueBase dialogue_1st;
    [Header("开启重复对话")]
    public bool isRepeat = false;
    public DialogueBase dialogue_Repeat;

    [Header("开启加载下一个场景")]
    public string sceneName;

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
        if (DialogueManager.instance.inDialogue) return;
        
        Debug.Log("ThisClicked:" + stageName);

        if (PauseMenu.isPaused) return;
        Debug.Log("ThisClicked:" + stageName);

        //SceneManager.LoadScene(sceneName);
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        if (stageName != "") GameManager.instance.Load(stageName);
        else if(sceneName != "") SceneManager.LoadScene(sceneName);

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

        if (destoryObj.Length > 0)
        {
            foreach (GameObject obj in destoryObj)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }

            }
        }


        if (isOnce) {

            if(dialogue_1st) DialogueManager.instance.EnqueueDialogue(dialogue_1st);

            isOnce = false;
        }else if (isRepeat)
        {
            if (dialogue_Repeat) DialogueManager.instance.EnqueueDialogue(dialogue_Repeat);
        }


    }

    public void LoadGame1()
    {
        GameManager.instance.Load("game1");
    }
    public void LoadGame2()
    {
        GameManager.instance.Load("game2");
    }
 



}
