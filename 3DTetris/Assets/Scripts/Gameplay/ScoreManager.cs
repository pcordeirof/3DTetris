using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public FloatVariable score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score.Value = 0f;
        scoreText.text = score.Value.ToString();
    }

    public void UpdateScore()
    {
        score.Value++;
        scoreText.text = score.Value.ToString();
    }
}
