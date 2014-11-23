using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardScript : MonoBehaviour {

	public bool debug = false;
	public TextMesh debugText;
	public GameObject mesh;

	public CardType cardType;
	public CardType CardType {
				get {
						return cardType;
				}
				set {
						cardType = value;
						this.Color = cardType.Color;						
				}
		}

	public CardType.ColorType Color {
		get {
			return CardType.ColorType.Red;
		}
		set {
			var materiaColorByCardTypeColor = new Dictionary<string, Color>();

			materiaColorByCardTypeColor.Add(CardType.ColorType.Green.ToString(), UnityEngine.Color.green);
			materiaColorByCardTypeColor.Add(CardType.ColorType.Purple.ToString(), UnityEngine.Color.magenta);
			materiaColorByCardTypeColor.Add(CardType.ColorType.Red.ToString(), UnityEngine.Color.red);

			mesh.renderer.material.color = materiaColorByCardTypeColor[value.ToString()];

//			if (value == CardType.ColorType.Red) 
//				mesh.renderer.material.color = Color.blue;
//			
//			if (value == CardType.ColorType.Purple) 
//				mesh.renderer.material.color = Color.magenta;
//
//			
//			if (value == CardType.ColorType.Green) 
//				mesh.renderer.material.color = Color.green;
		}
	}

	// Use this for initialization
	void Start () {
		if (debug) {
			debugText.text = this.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public string ToString() {

		return (cardType == null) ? "no data" : cardType.ToString();
	}
}
