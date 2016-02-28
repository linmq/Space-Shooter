using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		this.transform.position = startPosition + Vector3.forward * newPosition;
	}
}
