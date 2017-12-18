using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformAttack : MonoBehaviour {
	public float cooldown = 0.1f;
	float cooldownRemaining = 0;
	public float range = 100.0f;
	public GameObject debrisPrefab;
	public Vector3 effectSpawn;
	public GameObject sparkEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		if (Input.GetMouseButton(0)&& cooldownRemaining<=0) {
			cooldownRemaining = cooldown;
			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			if (Physics.Raycast(ray, out hitInfo, range)){
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				//Debug.Log("Hit Object: "+go.name);
				//Debug.Log("Hit Point: "+ hitPoint);

				HasHealth h =go.GetComponent<HasHealth>();
				if (h != null) {
					h.RecieveDamage(50f);
				}

				if(debrisPrefab != null){
					Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
					//effectSpawn = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z);
					Instantiate(sparkEffect, hitPoint, Quaternion.identity);
				}
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") {
			//Debug.Log(col);
			print(col.transform.position);

			Destroy(gameObject);
		}

	}
}

