using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public static Player Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public GameObject TextPanel;



    void Start()
    {
    }
        

 
    void Update()
    {
       
    }
}
