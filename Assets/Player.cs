using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject gameObject;

    void Start()
    {
        
    }

    bool isClickable = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isClickable)
        {
          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            
                if (hit.collider.gameObject.tag == "Box")
                {
                    TriggerBox triggerBox;
                    if (hit.collider.gameObject.TryGetComponent<TriggerBox>(out triggerBox))
                    {
                    }
                    else { Debug.LogError("BoxTag√ª≈‰÷√TriggerBox"); }
                }


            }
        }
    }
}
