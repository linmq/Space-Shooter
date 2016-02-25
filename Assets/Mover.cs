using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed = 20f;

	// Use this for initialization
	void Start () 
	{
		this.rigidbody.velocity = this.transform.forward * speed;
	}
}
