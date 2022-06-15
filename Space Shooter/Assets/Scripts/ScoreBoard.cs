using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreCounter;
    int score;

    void Update() 
    {
        scoreCounter.text = score.ToString();    
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score = score + amountToIncrease;
    }


}
