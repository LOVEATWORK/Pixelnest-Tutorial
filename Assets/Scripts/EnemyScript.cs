using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private WeaponScript [] weapons;
	private bool hasSpawn;
	private MoveScript moveScript;

	void Awake () {

		weapons = GetComponentsInChildren<WeaponScript> ();
		moveScript = GetComponent<MoveScript> ();

	}

	void Start() {

		hasSpawn = false;

		// Disable everything at the start
		collider2D.enabled = false;
		moveScript.enabled = false;

		foreach (WeaponScript weapon in weapons) {
				
			weapon.enabled = false;

		}

	}

	// Update is called once per frame
	void Update () {
	
		// Check if the enemy has spawned
		if (hasSpawn == false) {
		
			if (renderer.IsVisibleFrom (Camera.main)) {
				Spawn ();
			}
		
		} else {

			foreach (WeaponScript weapon in weapons) {
				
				// Auto fire
				if (weapon != null && weapon.CanAttack) {
					weapon.Attack(true);		
				}
				
			}

			if (renderer.IsVisibleFrom(Camera.main) == false) {
				Destroy(gameObject);
			}
		}
	}

	private void Spawn ()
	{
		hasSpawn = true;

		collider2D.enabled = true;
		moveScript.enabled = true;

		foreach (WeaponScript weapon in weapons) {
			
			weapon.enabled = true;

		}
	}
}
