using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile from front of GameObject
/// </summary>
public class WeaponScript : MonoBehaviour {

	// 1 - Designer variables
	public Transform shotPrefab;
	public float shootingRate = 0.25f;

	private float shotCooldown;

	// Use this for initialization
	void Start () {
	
		shotCooldown = 0f;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (shotCooldown > 0) {
			shotCooldown -= Time.deltaTime;		
		}

	}

	// 2 - Shooting from another script

	public void Attack(bool isEnemy) {

		if (CanAttack) {
			shotCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// The isEnemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

			if (shot != null) {
				shot.isEnemeyShot = isEnemy;
			}

			// Make the weapon shoot towards target
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

			if (move != null) {
				move.direction = this.transform.right; // Towards in 2D space is to the right of the sprite
			}

		}

	}

	public bool CanAttack {
		get {
			return shotCooldown <= 0f;
		}
	}

}
