using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
	
	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private int howManygameNeedles;
	
	private Button shootButton;
	private GameObject[] gameNeedles;
	private float needleDistance = .6f;
	private int needleIndex;
	
    void Awake()
    {
        if (instance == null)
		{
			instance = this;
		}
		
		GetButton();
    }


    void Start()
    {
        CreateNeedles();
    }
	
	void GetButton()
	{
		shootButton = GameObject.Find("Shoot Button").GetComponent<Button>();
		shootButton.onClick.AddListener(() => ShootTheNeedle());
	}
	
	public void ShootTheNeedle()
	{
		gameNeedles[needleIndex].GetComponent<NeedleMovementScript>().FireTheNeedle();
		needleIndex ++;
		
		if (needleIndex >= gameNeedles.Length)
		{
			Debug.Log("The game is finished.");
			shootButton.interactable = false;
		}
	}
	
	void CreateNeedles()
	{
		gameNeedles = new GameObject[howManygameNeedles];
		Vector3 temp = transform.position;
		
		for (int i = 0; i < gameNeedles.Length; i++)
		{
			gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
			temp.y -= needleDistance;
		}
		
	}
	
	public void InstantiateNeedle()
	{
		Instantiate(needle, transform.position, Quaternion.identity);
	}
	
	
}
