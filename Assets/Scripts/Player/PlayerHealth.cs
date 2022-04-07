using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;                         
	public int currentHealth;                                  
	public Slider healthSlider;  


	Animator anim;

	void Start () {

		anim = GetComponent<Animator> ();

	}


	void Awake ()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		anim.SetTrigger ("Die");
		Destroy (gameObject, 1.4f);
	}       


} 