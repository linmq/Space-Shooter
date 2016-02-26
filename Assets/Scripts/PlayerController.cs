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

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = .25f;
	private float nextFire = 0f;

	public GUIText scoreText;
	private int score;

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

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

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}
}
