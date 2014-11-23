using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dealer : MonoBehaviour {

	public int numberOfCardsInRound = 12;
	public List<GameObject> cards;

	public GameObject cardPrefab;

	// Use this for initialization
	void Start () {
		cards = MakeAllCards ();

		var roundOfCards = GetNumberOfRandomCards (numberOfCardsInRound);
		LayoutCards (roundOfCards);
	}
	
	// Update is called once per frame
	void Update () {
		// debug: 
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			var roundOfCards = GetNumberOfRandomCards (numberOfCardsInRound);
			LayoutCards (roundOfCards);		}
	}

	List<GameObject> MakeAllCards ()
	{
		int numCards = 81;
		var cards = new List<GameObject>(numCards);

		for (int i = 0; i < numCards; i++) {
			var go = (GameObject) Instantiate(cardPrefab); // added to the scene
			go.transform.position = new Vector3( i * 4f , 40f );
			cards.Add(go);
			
			// data
			CardType cardType = new CardType(i);			
			
			var cardTypeScript = go.GetComponent<CardScript>();
			cardTypeScript.cardType = cardType;
			cardTypeScript.Color = cardType.Color;
		}
		return cards;
	}


	List<GameObject> GetNumberOfRandomCards(int numCards) {
		var roundOfCards = new List<GameObject>();
//		roundOfCards.Find
		for (int i = 0; i<numCards; i++) {
			roundOfCards.Add(cards[ (int)Mathf.Floor(Random.value * cards.Count) ]);		
		}
		return roundOfCards;
	}

	void LayoutCards(List<GameObject> cards, int cols = 3, int rows = 4) {
		int i = cards.Count;
		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				Transform card = cards[--i].transform;
				card.transform.position = new Vector3(x * (3f + 3f), y * (3f + 3f));
			}
		}
	}
}
