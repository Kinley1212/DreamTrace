using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip get;

    public static UIManager instance;

    public GameObject dairyOpenPanel;
    public GameObject dairyBtn;
    public Image dairyImg;

    public string dairyToSceneName;

    public AudioSource BGM;
    public Toggle BgmToggle;

    public DairyNextPage[] dairyNextPages;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);  
        if (instance == null) instance = this;
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }


    public void OpenDairy()
    {
        dairyOpenPanel.SetActive(true);
        dairyBtn.SetActive(false);

        audioSource.clip = get;
        audioSource.Play();
    }

    public void CloseDairy()
    {
        foreach (DairyNextPage item in dairyNextPages) { 
        if( item.CheckPageFinished())
                   return;
        }

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

    public void BGMoptions()
    {
        if (BgmToggle.isOn)
        {
            BGM.Stop();
        }
        else
        {
            BGM.Play();
        }
    }





}
