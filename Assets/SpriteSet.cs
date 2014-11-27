using UnityEngine;
using System.Collections;

public class SpriteSet : MonoBehaviour
{
	public SpriteRenderer maskCapsule;
	public SpriteRenderer maskDiamond;
	public SpriteRenderer maskSquiggly;

	public SpriteRenderer outlineCapsule;
	public SpriteRenderer outlineDiamond;
	public SpriteRenderer outlineSquiggly;

	public SpriteRenderer solid;
	public SpriteRenderer stripes;

	public void Setup(CardType cardType)
	{
		Setup(cardType.Color, cardType.Fill, cardType.Number, cardType.Shape);
	}

	public void Setup(CardType.ColorType color, CardType.FillType fill, CardType.NumberType number, CardType.ShapeType shape)
	{
		maskCapsule.enabled = false;
		maskDiamond.enabled = false;
		maskSquiggly.enabled = false;
		outlineCapsule.enabled = false;
		outlineDiamond.enabled = false;
		outlineSquiggly.enabled = false;
		solid.enabled = false;
		stripes.enabled = false;

		Color rgba = Color.white;
		switch (color) {
		case CardType.ColorType.Green:
			rgba = Color.green;
			break;
		case CardType.ColorType.Purple:
			rgba = Color.magenta;
			break;
		case CardType.ColorType.Red:
			rgba = Color.red;
			break;
		}

		SpriteRenderer mask = null;
		SpriteRenderer outline = null;
		switch (shape) {
		case CardType.ShapeType.Circle:
			mask = maskCapsule;
			outline = outlineCapsule;
			break;
		case CardType.ShapeType.Diamond:
			mask = maskDiamond;
			outline = outlineDiamond;
			break;
		case CardType.ShapeType.Es:
			mask = maskSquiggly;
			outline = outlineSquiggly;
			break;
		}

		solid.enabled = true;
		solid.color = (fill == CardType.FillType.Solid) ? rgba : Color.white;

		stripes.enabled = (fill == CardType.FillType.Striped);
		stripes.color = rgba;

		outline.enabled = true;
		outline.color = rgba;

		mask.enabled = true;
		mask.color = Color.white;
	}

	public void Place(CardType.NumberType number, int index) 
	{
		float deltaPosition = 0;
		switch (number) 
		{
			case CardType.NumberType.One:
				return;
			case CardType.NumberType.Two:
				deltaPosition = (float) index - 0.5f;
				break;
			case CardType.NumberType.Three:
				deltaPosition = (float) index - 1f;
				break;
		}

		transform.localPosition += new Vector3(deltaPosition, 0, 0);
	}

}
