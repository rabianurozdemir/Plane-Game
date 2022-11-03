using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Rigidbody2D _rb;
    
    [SerializeField] // If our variable is private, we have to use this to organise variable on editor.
    private float _speed;

    int angle;
    int maxAngle = 20;
    int minAngle = -50;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // We assigned the component of the plane object to our variable.

    }

    // Update is called once per frame
    void Update()
    {
        PlaneFly();
        PlaneRotation();
    }

    void PlaneFly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.zero; // We want to see same effect very time we clicked on the plane.
            _rb.velocity = new Vector2(_rb.velocity.x, _speed); // The plane will bounce upwards when we clicked mouse and then fall downwards. There will be no change in the x-axis.
        }
    }

    void PlaneRotation()
    {
        if (_rb.velocity.y > 0) // up
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2) // down, to soften to downturn
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }
        
        transform.rotation = Quaternion.Euler(0, 0, angle); // To give angular rotation
    }
}
