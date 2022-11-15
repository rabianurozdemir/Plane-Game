using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    // Start is called before the first frame update


    private void Awake() // Start tan önce çalışmasını istiyoruz.
    {
        bottomLeft = Camera.main.ScreenToViewportPoint(new Vector2(0,0)); //Sol alt köşe
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
