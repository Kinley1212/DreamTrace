using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour
{
    public int score = 0;
    public GameObject game;
    public GameObject fishdestory;
    public GameObject fishshow;
    public GameObject boatdestory;
    public GameObject boatshow;
    public Transform hook;
    public int dairyPage;
    public int dairyContentIndex;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1f);

        //CheckGameOver
        if (score >= 5) GameOver();

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Fish"))
        {
            FishObj fishObj = collision.transform.GetComponent<FishObj>();
            if (fishObj.isOpen)
            {
                Debug.Log(collision.gameObject.name);
                score++;
                fishObj.HookUpFish(hook);
            }
        }
    }

    void GameOver()
    {
        GameManager.instance.Load("stage8");
        Cursor.visible = true;
        fishdestory.SetActive(false);
        fishshow.SetActive(true);
        boatdestory.SetActive(false);
        boatshow.SetActive(true);
        GameManager.instance.GetDairy(dairyPage, dairyContentIndex);

        //
        game.SetActive(false);

    }

}
