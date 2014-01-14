using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	// 1 - Designer variables
	public int damage = 1;
	public bool isEnemeyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20);
	}
}
