using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private int Score = 0;

    public Text ScoreDisplay; 
    public int GetScore() { return Score;  }

    private void Start()
    {
        ScoreDisplay.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        if(collision.CompareTag("Enemy"))
        {
            Score += collision.GetComponent<Enemy>().GetScoreValue();
            ScoreDisplay.text = Score.ToString();
        }

    }
}
