using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;

   
    public void AddScore(int AddedScore)
    {
        score += AddedScore;
    }

    private void Update()
    {
        string jotdownscore = score.ToString();
        scoreUI.text = "Score " + jotdownscore;

    }
}
