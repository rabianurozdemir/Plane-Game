using UnityEngine;

public class PressButton : MonoBehaviour
{
    public Plane plane;
    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            plane.rb.velocity = new Vector2(plane.rb.velocity.x, plane._speed);
            
        }
    }
}
