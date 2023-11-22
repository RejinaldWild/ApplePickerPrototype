using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
   
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i< numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY*i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAplleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAplleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if(basketList.Count == 0)
        {
            FindObjectOfType<AudioManager>().Play("LooseGame");
            //some waiting 
            SceneManager.LoadScene("_Scene_0");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("LooseBasket");
        }
    }
}
