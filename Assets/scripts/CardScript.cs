using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardScript : MonoBehaviour {

	public bool debug = false;
	public TextMesh debugText;

	public GameObject one, two, three;

	public GameObject shape1, shape2, shape3;

	CardType cardType;
	public CardType CardType {
		get {
			return cardType;
		}
		set {
			cardType = value;
			this.Color = cardType.Color;						
			this.Number = cardType.Number;		
			this.Shape = cardType.Shape;
		}
	}

	public CardType.NumberType Number {
		set {
			one.SetActive(false);
			two.SetActive(false);
			three.SetActive(false);
			if (value == CardType.NumberType.One) {
				one.SetActive(true);
			}
			else if (value == CardType.NumberType.Two) {
				two.SetActive(true);
			}
			else if (value == CardType.NumberType.Three) {
				three.SetActive(true);
			}
		}
	}

	public CardType.ShapeType Shape {
		set {
			shape1.SetActive(false);
			shape2.SetActive(false);
			shape3.SetActive(false);
			if (value == CardType.ShapeType.Circle) {
				shape1.SetActive(true);
			}
			else if (value == CardType.ShapeType.Es) {
				shape2.SetActive(true);
			}
			else if (value == CardType.ShapeType.Diamond) {
				shape3.SetActive(true);
			}
		}
	}

	public CardType.ColorType Color {
		set {
			var materiaColorByCardTypeColor = new Dictionary<string, Color>();
			materiaColorByCardTypeColor.Add(CardType.ColorType.Green.ToString(), UnityEngine.Color.green);
			materiaColorByCardTypeColor.Add(CardType.ColorType.Purple.ToString(), UnityEngine.Color.magenta);
			materiaColorByCardTypeColor.Add(CardType.ColorType.Red.ToString(), UnityEngine.Color.red);
			shape1.renderer.material.color = materiaColorByCardTypeColor[value.ToString()];
			shape2.renderer.material.color = materiaColorByCardTypeColor[value.ToString()];
			shape3.renderer.material.color = materiaColorByCardTypeColor[value.ToString()];
		}
	}

//	public CardType.FillType {
//		set {
//
//		}
//	}

	// Use this for initialization
	void Start () {
		debugText.gameObject.SetActive (debug);
		if (debug) {
			debugText.text = this.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public override string ToString() {

		return (cardType == null) ? "no data" : cardType.ToString();
	}
}
