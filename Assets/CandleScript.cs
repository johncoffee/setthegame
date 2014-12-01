using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {

	float i = 0f;

	public float offset = 1.2f;
	public float changeSpeed = 0.067f;
	
	// Update is called once per frame
	void Update () {
		i += changeSpeed;
		var n = Mathf.PerlinNoise(i, 1.9f);
		this.GetComponent<Light> ().intensity = offset * n;
	}
}
