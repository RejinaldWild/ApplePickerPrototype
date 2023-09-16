using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI text = this.GetComponent<TextMeshProUGUI>();
        text.text = "HighScore: " + score;

        if(score> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
}
