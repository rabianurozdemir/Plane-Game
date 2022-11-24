using UnityEngine;

public class Plane : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] // If our variable is private, we have to use this to organise variable on editor.
    public float _speed;

    private int _angle;
    private int _maxAngle = 10;
    private int _minAngle = -20;
    private bool _touchedMountain;
    public Vector2 _playerDirection;

    public Score score;
    public GameManager gameManager;
    public Sprite planeDied;
    private SpriteRenderer _sp;
    private Animator _anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource hit, point;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // We assigned the component of the plane object to our variable.
        rb.gravityScale = 0; // Biz tıklamadığımız sürece uçak havada kalacak.
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

    public void PlaneFly()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if (GameManager.GameStarted == false)
            {
                rb.gravityScale = 2f;
                rb.velocity = new Vector2(rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
        }

        // else if (buttonRestart.name == "restart")
        // {
        //     buttonRestart.onClick.addlistener(RestartBtn)   
        //     gameManager.RestartBtn();
        // }
    }
    
    void PlaneRotation()
    {
        if (rb.velocity.y > 0) // up
        {
            if (_angle <= _maxAngle)
            {
                _angle = _angle + 4;
            }
        }
        else if (rb.velocity.y < -1.2) // down, to soften to downturn
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
            point.Play();
        }
        else if (col.CompareTag("Column") && GameManager.gameOver == false)
        {
            gameManager.GameOver();
            GameOver();
            PlaneDieSoundEffect();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Mountain"))
        {
            if (GameManager.gameOver == false)
            {
                PlaneDieSoundEffect();
                gameManager.GameOver();
            }
            
            GameOver();
        }
    }
    void GameOver()
    {
        _touchedMountain = true;
        _minAngle = -90;
        _sp.sprite = planeDied;
        _anim.enabled = false;
    }

    private void PlaneDieSoundEffect()
    {
        hit.Play();
        
    }
}