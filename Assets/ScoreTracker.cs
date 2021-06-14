using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private int Score = 0;

    public Text ScoreDisplay; 
    public int GetScore() { return Score;  }

    private void Start()
    {
        ScoreDisplay.text = "Score: " + Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Score += collision.GetComponent<Enemy>().GetScoreValue();
            ScoreDisplay.text =  "Score: " + Score.ToString();
        }

    }
}
