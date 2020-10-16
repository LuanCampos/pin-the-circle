using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovementScript : MonoBehaviour
{	
	private bool canFireNeedle;
	private bool touchedCircle;
	private float forceY = 20f;
	private Rigidbody2D myBody;
	
    void Awake()
	{
		Initialize();
	}
	
	void Initialize()
	{
		myBody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if (canFireNeedle)
		{
			myBody.velocity = new Vector2(0, forceY);
		}
    }
	
	public void FireTheNeedle()
	{
		canFireNeedle = true;
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (touchedCircle)
		{
			return;
		}
		
		else
		{
			if (target.tag == "Circle")
			{
				canFireNeedle = false;
				touchedCircle = true;
				myBody.velocity = new Vector2(0, 0);
				gameObject.transform.SetParent(target.transform);
				
				if (ScoreManager.instance != null)
				{
					ScoreManager.instance.SetScore();
				}
			}
			
			else if (target.tag == "NeedleHead" && transform.position.y > 0)
			{
				Debug.Log("Game Over.");
				Time.timeScale = 0f;
			}
		}
	}
	
}
