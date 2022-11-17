using UnityEngine;

public class Plane : MonoBehaviour
{
    Rigidbody2D _rb;
    
    [SerializeField] // If our variable is private, we have to use this to organise variable on editor.
    private float _speed;

    private int _angle;
    private int _maxAngle = 20;
    private int _minAngle = -50;
    private bool _touchedMountain;

    public Score score;
    public GameManager gameManager;
    public Sprite planeDied;
    private SpriteRenderer _sp;
    private Animator _anim;
    public ObstacleSpawner obstacleSpawner;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // We assigned the component of the plane object to our variable.
        _rb.gravityScale = 0; // Biz tıklamadığımız sürece uçak havada kalacak.
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();

    }

    void Update()
    {
        PlaneFly();
    }

    private void FixedUpdate()
    {
        PlaneRotation(); // yukarı aşağı hareketi daha gerçekçi olsun diye (cihazdan ve işlem gücünden bağımsız aynı sonuçları almak için)
    }

    void PlaneFly()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if (GameManager.GameStarted == false)
            {
                _rb.gravityScale = 2f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero; // We want to see same effect very time we clicked on the plane.
                _rb.velocity = new Vector2(_rb.velocity.x, _speed); // The plane will bounce upwards when we clicked mouse and then fall downwards. There will be no change in the x-axis.
            }
            
        }
    }

    void PlaneRotation()
    {
        if (_rb.velocity.y > 0) // up
        {
            if (_angle <= _maxAngle)
            {
                _angle = _angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2) // down, to soften to downturn
        {
            if (_angle > _minAngle)
            {
                _angle = _angle - 2;
            }
        }

        if (_touchedMountain == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
        
        transform.rotation = Quaternion.Euler(0, 0, _angle); // To give angular rotation
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (col.CompareTag("Column"))
        {
            gameManager.GameOver();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Mountain"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        _touchedMountain = true;
        transform.rotation = Quaternion.Euler(0,0,-90);
        _sp.sprite = planeDied;
        _anim.enabled = false;
    }
}
