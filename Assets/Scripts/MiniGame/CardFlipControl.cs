using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CardFlipControl : MonoBehaviour
{
    [SerializeField] string stageName;

    //public int dairyPage;
    //public int dairyContentIndex;

    AudioSource audioSource;
    public AudioClip get;


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

    public Sprite newSprite;

    [SerializeField] GameObject[] showObj;

    public GameObject prefabToSpawn; // 将你要生成的GameObject拖拽到这个变量上
    private Vector3 aimPosition; // 用于存储aim停留的位置

    // Start is called before the first frame update
    void Start()
    {
        startPos = aimStartPos.transform.position;
        endPos = aimEndPos.transform.position;

        aim.transform.position = startPos;
        StartCoroutine(MoveAim());

        audioSource = GetComponent<AudioSource>();

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
            // 获取aim停留的位置
            aimPosition = aim.transform.position;

            // 在aim停留的位置实例化一个新的GameObject
            GameObject newObj = Instantiate(prefabToSpawn, aimPosition, Quaternion.identity);

            Destroy(newObj, 1f);

            StopAllCoroutines();
            pointer.transform.DOPause();
            isPointerDone = true;

            audioSource.clip = get;
            audioSource.Play();

            //score
            float distance = Vector3.Distance(pointer.transform.position, startPos);
            if (distance > 4.2f && distance < 5.5f) score++;


            if (score >= 2)
            {
                round++;

                if (round >= roundTotal)
                {
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
                    StartCoroutine(DelayedLoad(1f));
                    aim.GetComponent<SpriteRenderer>().sprite = newSprite;

                    //GameManager.instance.GetDairy(dairyPage, dairyContentIndex);
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
    IEnumerator DelayedLoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.instance.Load("stage17");
    }

}
