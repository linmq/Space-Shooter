using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	public float lifetime = 2f;

	void Start () 
	{
		Destroy (this.gameObject, lifetime);
	}
}
