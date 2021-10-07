using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int CurrentScore = 0;
    [SerializeField] int PointPerBlockDestroyed = 25;
    [SerializeField] TextMeshProUGUI scoreText;
    [Range(0.1f,10f)] [SerializeField] float gameSpeed= 1f;

  private void Awake()
    {
        int gameSatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameSatusCount > 1)
        {
           gameObject.SetActive(false);
           Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        }
    
    private void Start()
    {
        scoreText.text = CurrentScore.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddScore()
    {
        CurrentScore = CurrentScore + PointPerBlockDestroyed;
        scoreText.text = CurrentScore.ToString();
    }
   public void ResetGame()
    {
        Destroy(gameObject);
    }
}
