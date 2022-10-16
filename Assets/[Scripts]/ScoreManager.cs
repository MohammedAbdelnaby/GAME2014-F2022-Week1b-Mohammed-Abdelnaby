using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreLabel();
    }
    public int getScore() { return score; }
    public void setScore(int NewScore)
    {
        score = NewScore;
        UpdateScoreLabel();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        scoreLabel.text = $"Score: {score}"; 
    }
}
