using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET_ThermalDet : MonoBehaviour {

	float lifespan = 3.0f;
	public GameObject fireEffect;
	public Vector3 effectSpawnLoc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			print("explode");
			Explode();
		}		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") {
			//col.gameObject.tag = "Dead";
			print(col.transform.position);
			effectSpawnLoc = new Vector3 (col.transform.position.x, col.transform.position.y -2f, col.transform.position.z);
			Instantiate(fireEffect, effectSpawnLoc, Quaternion.identity);
			Destroy(gameObject);
		}

	}
		
	void Explode()
	{
		Destroy(gameObject);
	}
}
