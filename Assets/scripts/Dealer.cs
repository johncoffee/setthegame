using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dealer : MonoBehaviour {

	public int numberOfCardsInRound = 12;
	public List<GameObject> cards;

	public int cols = 4, rows = 3;

	public GameObject cardPrefab;

	// Use this for initialization
	void Start () {
		cards = MakeAllCards ();

		DealRound ();
	}
	
	// Update is called once per frame
	void Update () {
		// debug: 
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			DealRound();
		}
	}

	public void DealRound() {
		PositionCardsOffCamera (cards, 4f);		
		var roundOfCards = GetNumberOfRandomCards (numberOfCardsInRound);
		LayoutCards (roundOfCards);		
	}

	List<GameObject> MakeAllCards ()
	{
		int numCards = 81;
		var cards = new List<GameObject>(numCards);

		for (int i = 0; i < numCards; i++) {
			var go = (GameObject) Instantiate(cardPrefab); // added to the scene
			cards.Add(go);
			
			// data
			CardType cardType = new CardType(i);			
			
			var cardTypeScript = go.GetComponent<CardScript>();
			cardTypeScript.CardType = cardType;
		}

		return cards;
	}

	void PositionCardsOffCamera(List<GameObject> cards, float offsetX) {
		for (int i = 0; i < cards.Count; i++) {
			var go = cards[i];
			go.transform.position = new Vector3( i * offsetX, 40f );
		}
	}


	List<GameObject> GetNumberOfRandomCards(int numCards) {
		var result = new List<GameObject>();
//		roundOfCards.Find
		while (result.Count < numCards) {
			int index = (int)Mathf.Floor(Random.value * cards.Count);
//			Debug.Log(index);
			var card = cards[ index ];

			int idxof = result.IndexOf(card);
//			Debug.Log("is found " + idxof);
			if (idxof == -1) {
				result.Add(card);
			}
		}
		return result;
	}

	void LayoutCards(List<GameObject> cards) {
		int i = cards.Count;
		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				Transform card = cards[--i].transform;
				card.transform.position = new Vector3(x * (3f + 3f), y * (3f + 3f));
			}
		}
	}
}
