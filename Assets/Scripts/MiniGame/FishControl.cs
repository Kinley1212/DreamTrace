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
        if (collision.transform.CompareTag("Fish")) {
            Debug.Log(collision.gameObject.name);
            score++;

            collision.transform.GetComponent<FishObj>().HookUpFish(hook);
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

        //
        game.SetActive(false);

    }

}
