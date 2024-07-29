using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BGMToggle : MonoBehaviour
{

    public AudioSource BGM;
    public Toggle BgmToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
