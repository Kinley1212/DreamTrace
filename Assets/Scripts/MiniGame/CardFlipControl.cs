using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CardFlipControl : MonoBehaviour
{
    [SerializeField] string stageName;

    [SerializeField] int roundTotal = 2;
    [SerializeField] GameObject aim;
    [SerializeField] GameObject pointer;
    [SerializeField] Transform aimStartPos;
    [SerializeField] Transform aimEndPos;

    [SerializeField] Transform pointerStartPos;
    [SerializeField] Transform pointerEndPos;

    [SerializeField] Transform targetTran;
    Vector3 startPos;
    Vector3 endPos;
    [SerializeField] float timeSpeed;
    [SerializeField] float timeSpeedPointer;

    bool isAimDone = false;
    bool isPointerDone = false;

    [SerializeField] int score = 0;
    [SerializeField] int round = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = aimStartPos.transform.position;
        endPos = aimEndPos.transform.position;

        aim.transform.position = startPos;
        StartCoroutine(MoveAim());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAimDone)
        {
            StopAllCoroutines();
            aim.transform.DOPause();  
            isAimDone = true;

            startPos = pointerStartPos.position;
            endPos = pointerEndPos.position;
            pointer.transform.position = startPos;
            //score
            float distance = Vector3.Distance(aim.transform.position, targetTran.position);
            if (distance > 1.5f && distance < 2f) score++;

            StartCoroutine(MovePointer());

            return;
        }


        if (Input.GetMouseButtonDown(0) && isAimDone && !isPointerDone)
        {
            StopAllCoroutines();
            pointer.transform.DOPause();
            isPointerDone = true;
            //score
            float distance = Vector3.Distance(pointer.transform.position, startPos);
            if (distance > 4.2f && distance < 5.5f) score++;


            if (score >= 2)
            {
                round++;

                if (round >= roundTotal)
                {
                    GameManager.instance.Load(stageName);
                    return;
                }
                else
                {
                    startPos = aimStartPos.transform.position;
                    endPos = aimEndPos.transform.position;
                    StartCoroutine(MoveAim());
                    score = 0;
                    isAimDone = false;
                    isPointerDone = false;
                }
            }
            else
            {
                startPos = aimStartPos.transform.position;
                endPos = aimEndPos.transform.position;
                StartCoroutine(MoveAim());
                score = 0;
                isAimDone = false;
                isPointerDone = false;
            }

        }
        


      
    }
    IEnumerator MovePointer()
    {
        while (true)
        {
            pointer.transform.DOMove(endPos, timeSpeedPointer);
            yield return new WaitForSeconds(timeSpeedPointer + 0.1f);
            pointer.transform.DOMove(startPos, timeSpeedPointer);
            yield return new WaitForSeconds(timeSpeedPointer + 0.1f);
        }
    }



    IEnumerator MoveAim()
    {
        while (true)
        {
            aim.transform.DOMove(endPos, timeSpeed);
            yield return new WaitForSeconds(timeSpeed + 0.2f);
            aim.transform.DOMove(startPos, timeSpeed);
            yield return new WaitForSeconds(timeSpeed + 0.2f);
        }
    }
}
