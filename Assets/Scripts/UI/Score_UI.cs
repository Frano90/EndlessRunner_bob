using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_UI : MonoBehaviour
{
    private Text score;
    private int scoreAmount;
    void Start()
    {
        score = GetComponent<Text>();
        Coin.OnGetCoin += AddScore;
    }

    private void AddScore()
    {
        scoreAmount++;
        score.text = " x " + scoreAmount;
    }

   
}
