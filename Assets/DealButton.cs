using UnityEngine;
using System.Collections;

public class DealButton : MonoBehaviour {

	public Dealer dealer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if ( Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit, 100.0f )) {
				GameObject go = hit.collider.gameObject;
				if (go.GetComponent<DealButton>() != null) {
					dealer.DealRound();
				}
			}
		}
	}
}
