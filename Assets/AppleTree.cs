using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenAppleDrops = 10f;

    
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
        FindObjectOfType<AudioManager>().Play("LooseApple");
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed*Time.deltaTime;
        transform.position = pos;

        if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
}
