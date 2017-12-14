using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour {
	public float hitPoints = 100f;

	public void RecieveDamage(float amt)
	{
		hitPoints -= amt;
		if (hitPoints <= 0) {
			Die();

		}
	}

	void Die()
	{
		Destroy(gameObject);
	}

}