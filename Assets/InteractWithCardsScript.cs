using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractWithCardsScript : MonoBehaviour {

	public List<GameObject> selectedCards;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {

			
			CardType[] cardsOnHand = new CardType[3];
			cardsOnHand[0] = new CardType(0);
			cardsOnHand[1] = new CardType(1);
			cardsOnHand[2] = new CardType(2);
			
			var isValid =  Validate (cardsOnHand);	
			Debug.Log ("should be true: " + isValid);

			cardsOnHand = new CardType[3];
			cardsOnHand[0] = new CardType(1);
			cardsOnHand[1] = new CardType(2);
			cardsOnHand[2] = new CardType(3);
			
			isValid =  Validate (cardsOnHand);		
			Debug.Log ("should be false: " + isValid);
		}

		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100.0f )) {
				GameObject card = hit.collider.gameObject;

				if (card.GetComponent<CardScript>() != null) {
										
					bool exists = false;
					for (int j = 0; j < selectedCards.Count; j++) {
						if (selectedCards[j] == card) {
							exists = true;
							break;
						}
					}

					if (!exists) {
						selectedCards.Add(card);						
						card.transform.position = card.transform.position + new Vector3(0, 0, -4f);					
					}					
					
					if (selectedCards.Count == 3) {
						CardType[] cardsOnHand = new CardType[3];
						for (int i = 0; i < 3; i++ ) {
							var selectedCard = selectedCards[i];
							cardsOnHand[i] = selectedCard.GetComponent<CardScript>().CardType;
							
							selectedCard.transform.position = selectedCard.transform.position + new Vector3(0, 0, 4f);
						}
						var isValid = Validate(cardsOnHand); 
						Debug.Log(isValid);
						selectedCards.Clear();
					}
				}
			}
		}
	}

	bool Validate(CardType[] cardsOnHand) {
		if (cardsOnHand.Length != 3) {
			Debug.LogWarning ("wat");
		}
//		if (cardsOnTable.Length != 9) {
//			Debug.LogWarning ("wat");
//		}

//		var intValueByAtributeName = new Dictionary<string, int>
//		{
//	 		{CardType.ColorType.Red.ToString(),    0},	
//			{CardType.ColorType.Green.ToString(),  1},
//			{CardType.ColorType.Purple.ToString(), 2},
//			{CardType.ShapeType.Circle.ToString(), 0},
//			{CardType.ShapeType.Diamond.ToString(),1},
//			{CardType.ShapeType.Es.ToString(),     2},//			
//			{CardType.FillType.Empty, 0},
//			{CardType.FillType.Striped,1},
//			{CardType.FillType.Solid , 2},//			
//			{CardType.NumberType.One, 0},
//			{CardType.NumberType.Two, 1},
//			{CardType.NumberType.Three, 2},
//		};

		var attributes = new List<CardType.AttributeType>() {
			CardType.AttributeType.Color,
			CardType.AttributeType.Fill,
			CardType.AttributeType.Shape,
			CardType.AttributeType.Number,
		};
		foreach (CardType.AttributeType attribute in attributes) {
			int cardsAttributesSum = 0;

			for (int j = 0; j < cardsOnHand.Length; j++) {			
				cardsAttributesSum += cardsOnHand[j].AttributesSumByTypeName[attribute];
			}

			if (cardsAttributesSum % 3 != 0) 
				return false;
		}

		return true;
	}
}
