using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {

	public float offset = 0.2f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Light> ().intensity += (Random.value < 0.5 ? 1 : -1) *
			offset * Random.value;
	}
}
