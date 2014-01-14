using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// 1 - Designer variables

	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);

	/// <summary>
	/// Object direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	// 2 - Private variables

	private Vector2 movement;
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
