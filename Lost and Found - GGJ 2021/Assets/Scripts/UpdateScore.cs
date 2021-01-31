using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{

    
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    void score(int scoreValue)
    {
        
        scoreText.text = "Score: " + scoreValue;
    }

   
    private void OnEnable()
    {
        ScoreManager.instance.onScoreChanged += score;
    }

    private void OnDisable()
    {
        ScoreManager.instance.onScoreChanged -= score;
    }
}
