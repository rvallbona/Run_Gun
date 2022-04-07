using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour {

	public int attackDamage = 1;
	GameObject EnemyObject;
	EnemyHealth enemy_Health;

	void Awake()
	{
		EnemyObject = GameObject.FindGameObjectWithTag ("Enemy");
		enemy_Health = EnemyObject.GetComponent <EnemyHealth> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
        {
			EnemyHealth otherHP;
			otherHP = other.GetComponent<EnemyHealth>();
			otherHP.TakeDamage(attackDamage);
			Destroy(gameObject);
		}
	}


}
