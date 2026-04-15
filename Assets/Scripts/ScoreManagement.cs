using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int newScore)
    {
        score += newScore;
        text.text = "Score: " + score;
    }
}
