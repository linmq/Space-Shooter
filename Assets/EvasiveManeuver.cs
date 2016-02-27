using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour 
{
	public float smoothing = 7.5f;
	public Boundary boundary;
	public float tilt = 10f;

	public float dodge = 5f;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	void Start()
	{
		currentSpeed = this.rigidbody.velocity.z;
		StartCoroutine (Evade());
	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) 
		{
			targetManeuver = Random.Range( 1f, dodge * -Mathf.Sign(transform.position.x));
			yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate()
	{
		float newManeuver = Mathf.MoveTowards (this.rigidbody.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		this.rigidbody.velocity = new Vector3 ( newManeuver, 0f, currentSpeed );

		this.rigidbody.position = new Vector3
		(
			Mathf.Clamp( rigidbody.position.x, boundary.xMin, boundary.xMax ),
			0f,
			Mathf.Clamp( rigidbody.position.z, boundary.zMin, boundary.zMax )
		);

		this.rigidbody.rotation = Quaternion.Euler(0f, 0f, this.rigidbody.velocity.z * -tilt);
	}
}
