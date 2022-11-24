using UnityEngine;
using UnityEngine. UI; // UI ile ilgili çalışma yapmadan önce bu namespace i ekle

public class Score : MonoBehaviour
{
    private int _score;
    private Text _scoreText;
    private int _highScore;
    public Text panelScore;
    public Text panelHighScore;
    
    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString(); //Çünkü score int türünde
        panelScore.text = _score.ToString();
        _highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = _highScore.ToString();

    }
    public void Scored()
    {
        _score++;
        _scoreText.text = _score.ToString();
        panelScore.text = _score.ToString();

        if (_score > _highScore)
        {
            _highScore = _score;
            panelHighScore.text = _highScore.ToString();
            PlayerPrefs.SetInt("highscore", _highScore);
        }
    }
    public int GetScore()
    {
        return _score;
    }
}
