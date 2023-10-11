using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField]
    private Text _GameOverText;

    private GameManager _gameManager;


    [SerializeField] private Text _RestartLevelText;
    
    void Start()
    {
        _GameOverText.gameObject.SetActive(false);
        _RestartLevelText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

    }
    
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];
    }

    public void GameOver()
    {
        _gameManager.GameOver();
        _GameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
    }

    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _RestartLevelText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _RestartLevelText.gameObject.SetActive(false);
        }
    }
    
}
