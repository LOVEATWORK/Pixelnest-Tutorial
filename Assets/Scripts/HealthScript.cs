using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// 1 - Designer variables
	public int hp = 2;
	public bool isEnemy = true;

	void OnTriggerEnter2D(Collider2D collider) {

		// is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript> ();

		if (shot != null) {

			// Avoid friendly fire		
			if (shot.isEnemeyShot != isEnemy) {
			
				hp -= shot.damage;

				// Destroy the shot
				Destroy(shot.gameObject);

				if (hp <= 0) {
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					Destroy(gameObject);
				}

			}
			
		}

	}
}
