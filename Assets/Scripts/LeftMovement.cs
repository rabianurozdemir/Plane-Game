using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    private BoxCollider2D _box;
    private float _groundWidth;
    private float _obstacleWidth;
    void Start()
    {
        if (gameObject.CompareTag("Mountain"))
        {
            _box = GetComponent<BoxCollider2D>();
            _groundWidth = _box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; //Yukardakiyle aynı ama yukarıdaki daha güzel
        }
        
    }

    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
        if (gameObject.CompareTag("Mountain"))
        {
            if (transform.position.x <= -_groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2* _groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.BottomLeft.x - 100*_obstacleWidth)
            {
                Destroy(gameObject); // Belli bir süre sonra engelleri yok etmek istiyoruz.
            }
        }
        
    }
}
