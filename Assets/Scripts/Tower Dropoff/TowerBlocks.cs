using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TowerBlocks : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject towerParent;
    private int ScoreValue;
    private int HighScoreValue;
    private Collider collider;
    public int lose = 0;


    private void Start()
    {
        collider = this.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckForGameOver();
        UpdateScores();
    }

   void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lose++;
        }
    }

    private void CheckForGameOver()
    {
        if (lose > 1){
            ScoreText.text = "0";
            UIPanel.SetActive(true);
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }

    private void UpdateScores()
    {
        int count = towerParent.transform.childCount;
        if (count < HighScoreValue) //Lower than the Highscore
        {
            ScoreValue = count;
            ScoreText.text = ScoreValue.ToString();
        }
        else
        {
            ScoreValue = count;
            HighScoreValue = count;
            ScoreText.text = ScoreValue.ToString();
            HighScoreText.text = HighScoreValue.ToString();
        }
    }

    public void RetryGame()
    {
        foreach (Transform child in towerParent.transform)
        {
            Destroy(child.gameObject);
        }
        UIPanel.SetActive(false);
        ScoreValue = 0;
        ScoreText.text = ScoreValue.ToString();
        lose = 0;
        Time.timeScale = 1f;

    }
}
