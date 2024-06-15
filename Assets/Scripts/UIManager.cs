using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public GameObject dairyOpenPanel;
    public GameObject dairyBtn;
    public Image dairyImg;
    private void Awake()
    {
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
}
