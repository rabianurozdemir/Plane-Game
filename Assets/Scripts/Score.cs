using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI; // UI ile ilgili çalışma yapmadan önce bu namespace i ekle

public class Score : MonoBehaviour
{
    private int _score;
    private Text _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _score = 0;
        _scoreText.text = _score.ToString(); //Çünkü score int türünde
    }

    public void Scored()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
