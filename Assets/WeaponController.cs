using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1.5f;
	public float delay = .5f;

	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire () 
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audio.Play ();
	}
}
