using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public GameObject dairyOpenPanel;
    public GameObject dairyBtn;
    public Image dairyImg;

    public string dairyToSceneName;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);  
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }


    public void OpenDairy()
    {
        dairyOpenPanel.SetActive(true);
        dairyBtn.SetActive(false);
    }

    public void CloseDairy()
    {
        dairyOpenPanel.SetActive(false);
        dairyBtn.SetActive(true);
    }


    public int passwordPressed = 0;


    public DairyButton[] dairyButtons;
    public void CheckNum()
    {
        bool isAllPressed = true;
        foreach (DairyButton btn in dairyButtons)
        {
            if (!btn.isPressed) isAllPressed = false;
        }
        if (isAllPressed)
        {
            OpenDairy();
            SceneManager.LoadScene(dairyToSceneName);
        } 
    }

    public void WrongNumPressed()
    {
        foreach (DairyButton btn in dairyButtons)
        {
            if (btn.isPressed) btn.isPressed = false;
        }
    }
}
