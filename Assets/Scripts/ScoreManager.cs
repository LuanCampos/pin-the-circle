using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	
	private TextMeshProUGUI scoreText;
	private int score;

    void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
		
		if (instance == null)
		{
			instance = this;
		}
		
    }

    public void SetScore()
    {
        score ++;
		scoreText.text = "" + score;
    }
	
}
