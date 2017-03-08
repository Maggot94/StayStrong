using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player : MonoBehaviour {

	public int life = 100;
	public int damage = 10;
	public Image vida; 
	public float maxTime; 
	public float minSwipeDist;
	public int direcction; 
	public bool defense = false; 
	public float defensetime = 2f;

	private Animator Dodge; 

	public Enemigo ene; 

	float startTime; 
	float endTime;

	Vector3 starPos;
	Vector3 endPos; 

	float SwipeDistance; 
	float SwipeTime;


	// Use this for initialization
	void Start () {
		
		Dodge = GetComponent<Animator> (); 

	}
	
	// Update is called once per frame
	void Update () {

		if (defense == true) {

			defensetime -= Time.deltaTime;

			if (defensetime <= 0) {

				Dodge.SetInteger ("Dodge", 0);
				defensetime = 2f;
				defense = false;

			}
		}
		if (ene.Idamge == true && defense == false) {

			life = life - 10; 
			ene.Idamge = false; 
		} 
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) 
			{
				startTime = Time.time;
				starPos = touch.position; 
			}

			else if (touch.phase == TouchPhase.Ended)
			{
				endTime = Time.time;
				endPos = touch.position;

				SwipeDistance = (endPos - starPos).magnitude;
				SwipeTime = endTime - startTime;
				if (SwipeTime < maxTime && SwipeDistance > minSwipeDist) {

					Swipe ();

				}
	         }
          }
	   }

	void Swipe ()
	{
		Vector2 distance = endPos - starPos;
		if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y) )
		{
			Debug.Log ("Horizonal Swipe");
			if (distance.x > 0) {
				Debug.Log ("Defensa Derecha"); 

				Dodge.SetInteger ("Dodge", 1);
				defense = true; 
			}
			if (distance.x < 0) {
				Debug.Log ("Defensa Izquierda"); 
				Dodge.SetInteger ("Dodge", 2);
				defense = true; 
				//Instantiate (Block, SpawnPoint.position, SpawnPoint.rotation);
			}
		}
    }
}
