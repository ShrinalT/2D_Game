using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    private GameManager _gameManager;
    void Start()
    {
        
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateScore(int pscore)
    {
        _scoreText.text = "Score: " + pscore.ToString();
    }
    public void UpdateLives(int clives)
    {
        _livesImage.sprite = _lives[clives];
    }
    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameoverFlickerRoutine());
        _gameManager.GameOver();
        

    }

    IEnumerator GameoverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = " Game Over";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "  ";
            yield return new WaitForSeconds(0.5f);
        }
    }
}

