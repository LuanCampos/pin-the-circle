using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovementScript : MonoBehaviour
{
	//[SerializeField]
	//private GameObject needleBody;
	
	private bool canFireNeedle;
	private bool touchedCircle;
	private float forceY = 5f;
	private Rigidbody2D myBody;
	
    void Awake()
	{
		Initialize();
	}
	
	void Initialize()
	{
		//needleBody.SetActive(false);
		myBody = GetComponent<Rigidbody2D>();
	}
	
	void Start()
	{
		FireTheNeedle();
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
		//needleBody.SetActive(true);
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
			}
		}
	}
	
}
