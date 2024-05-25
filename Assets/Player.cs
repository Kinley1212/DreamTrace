using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tomDev
{
    public class Player : MonoBehaviour
    {
        public GameObject gameObject;

        void Start()
        {


        }

        float[] total = { 1f, 2f, 3f };
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

        float a = 100;
        float b = 200;
        float Add(float no1, float no2)
        {
            var x = no1 + no2;

            return x;
        }

    }
}
