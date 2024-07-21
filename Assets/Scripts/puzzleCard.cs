using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCard : MonoBehaviour
{
    bool isDragble = true;
    public GameObject obj;
    public GameObject obj2;

    [Header("配置获取日记页")]
    public bool isLocked = false;
    public int dairyPage;
    public int dairyContentIndex;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool isOn = false;
    private void OnMouseDrag()
    {
        if (!isDragble) return;
       Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("PuzzleArea"))
            {
                Debug.Log("EnterCard");
                isOn = true;
            }
            else { isOn = false; }
        }
        else { isOn = false; }
    }

  

    private void OnMouseUp()
    {
        Debug.Log("MouseUp");
        if (isOn)
        {
            isDragble = false;
            obj.SetActive(true);
            obj2.SetActive(true);

            GameManager.instance.GetDairy(dairyPage, dairyContentIndex);

        }
    }
}
