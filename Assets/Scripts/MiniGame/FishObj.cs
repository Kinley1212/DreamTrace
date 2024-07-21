using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishObj : MonoBehaviour
{
    public Sprite sprOpen;
    public Sprite sprClose;

    SpriteRenderer spriteRenderer;

    public bool isOpen;
    public bool isGet = false;

    float speed;
    float range;

    float offset;

    Transform hook;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        speed = Random.Range(1f, 1.3f);
        range = Random.Range(2f, 4f);
        offset = Random.Range(range, range* 3f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isGet)
        {
            spriteRenderer.sprite = sprOpen;
            spriteRenderer.sortingOrder = 5;
      
           
            transform.position = hook.position;
            timer -= Time.deltaTime;
            if(timer <= 0) Destroy(gameObject);
            return;
        }

        float z = Mathf.PingPong(Time.time * speed + offset, range);
     

        transform.position = new Vector3(transform.position.x, transform.position.y, z - (range/2f));
       

        if (transform.position.z > 0)
        {
            spriteRenderer.sprite = sprOpen;
            spriteRenderer.sortingOrder = 5;
            isOpen = true;

            float scaleDelta = Mathf.MoveTowards(transform.localScale.x, 0.6f, Time.deltaTime * 0.1f);
            transform.localScale = new Vector3(scaleDelta, scaleDelta, scaleDelta);
        }
        else
        {
            spriteRenderer.sprite = sprClose;
            spriteRenderer.sortingOrder = 2;
            isOpen = false;
            float scaleDelta = Mathf.MoveTowards(transform.localScale.x, 0.45f, Time.deltaTime * 0.07f);
            transform.localScale = new Vector3(scaleDelta, scaleDelta, scaleDelta);
        }
    }

    public void HookUpFish(Transform trans)
    {
        isGet = true;
        timer = 1f;
        hook = trans;
        spriteRenderer.DOFade(0f, 1f);
    }
}
