using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    private float _timer;
    public float maxY;
    public float minY;
    private float _randomY;

    void Update()
    {
        if (GameManager.gameOver == false && GameManager.GameStarted == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= maxTime)
            {
                _randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                _timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, _randomY);
    }
}
