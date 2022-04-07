using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestruction : MonoBehaviour {

	public int attackDamage = 1;
	GameObject PlayerObject;
	PlayerHealth player_Health;

    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == PlayerObject)
		{
			player_Health.TakeDamage (attackDamage);
			Destroy (gameObject);
		}
	}


}