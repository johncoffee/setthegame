using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractWithCardsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log(42);
			Debug.Log (Input.mousePosition );

			if ( Input.GetMouseButtonDown(0)){
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 100.0f )) {
					GameObject card = hit.collider.gameObject;
					card.transform.position = card.transform.position + new Vector3(10f, 0f, 0f);
				}
			}
//			r.direction
		}
	}

	void Validate(CardType[] cardsOnHand, CardType[] cardsOnTable) {
		if (cardsOnHand.Length != 3) {
			Debug.LogWarning ("wat");
		}
		if (cardsOnTable.Length != 9) {
			Debug.LogWarning ("wat");
		}

		bool validHand = false;

		for (int i = cardsOnHand.Length; --i > 0;) {
			int attrSum = 0;
			for (int j = cardsOnHand.Length; j < 4; j++) {
				attrSum += cardsOnHand[j].Color;
			}
			if (attrSum % 3 == 0) {
				validHand = true;
			}
		}
	}
}
