using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 BottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool GameStarted;
    public GameObject getReady;
    public GameObject score;
    public static int gameScore;

    private void Awake() // Start tan önce çalışmasını istiyoruz.
    {
        BottomLeft = Camera.main.ScreenToViewportPoint(new Vector2(0,0)); //Sol alt köşe
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("Game");
    }
    void Start()
    {
        gameOver = false;
        GameStarted = false;
    }

    public void GameHasStarted()
    {
        GameStarted = true;
        getReady.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
}
