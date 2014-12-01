using UnityEngine;
using System.Collections;

public class RandomCoasterScript : MonoBehaviour {

	public float mag = 0.2f;
	public float rotMag = 100f;

	// Use this for initialization
	void Start () {
		transform.position += new Vector3 (mag + Random.value * mag/2f, mag + Random.value * mag/2f);
//		transform.localRotation = Quaternion.Euler (new Vector3 (transform.rotation.x, rotMag + Random.value * rotMag / 2f, transform.rotation.z));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
