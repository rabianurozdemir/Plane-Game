using UnityEngine;
using UnityEngine.UIElements;

public class Medals : MonoBehaviour
{
    public Sprite bronzeMedal, silverMedal, goldMedal;
    private Image _img;
    
    void Update()
    {
        _img = GetComponent<Image>();
        
        int gameScore = GameManager.gameScore;
        
        if (gameScore > 0 && gameScore <= 1)
        {
            _img.sprite = bronzeMedal;
            
        }
        else if (gameScore > 1 && gameScore <= 20)
        {
            _img.sprite = silverMedal;
        }
        else if (gameScore > 20)
        {
            _img.sprite = goldMedal;
        }
    }
}
