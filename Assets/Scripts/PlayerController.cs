using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed = 10f;
	public Boundary boundary;
	public float tilt = 4f;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		this.rigidbody.velocity = movement * speed;

		this.rigidbody.position = new Vector3
		(
			Mathf.Clamp(this.rigidbody.position.x, boundary.xMin, boundary.xMax),
			0f,
			Mathf.Clamp(this.rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		this.rigidbody.rotation = Quaternion.Euler (0f, 0f, this.rigidbody.velocity.x * tilt);
	}
}
