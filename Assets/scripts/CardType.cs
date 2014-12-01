using System;
using System.Collections.Generic;
using UnityEngine;

public class CardType
{

	ColorType color;
	public ColorType Color {
		get {
			return color;
		}
	}

	ShapeType shape;
	public ShapeType Shape {
		get {
			return shape;
		}
	}

	FillType fill;
	public FillType Fill {
				get {
						return fill;
				}
		}

	NumberType number;
	public NumberType Number {
		get {
			return number; 
		}
	}

	public Dictionary<AttributeType, int> AttributesSumByTypeName;

//	public int Type {
//		get {
//			return type;
//		}
//		set {
//			setType(value);
//		}
//	}

	public CardType (int index)
	{
		setType(index);
	}

	void setType(int i) {
		float colorSpace = 27f;
		float fillSpace = 9f;
		float shapeSpace = 3f;
		float numberSpace = 1f;

		int colorIndex = (int)(i / colorSpace);
		float remainder = i % colorSpace;
		int fillIndex = (int)(remainder/fillSpace);

		remainder = remainder%fillSpace;
		int shapeIndex = (int)( remainder/shapeSpace);

		remainder = remainder%shapeSpace;
		int numberIndex = (int)(remainder/numberSpace);


		var colorByInt = new Dictionary<int, ColorType>();
		colorByInt.Add (0, ColorType.Red);
		colorByInt.Add (1, ColorType.Green);
		colorByInt.Add (2, ColorType.Purple);

		var shapeByInt = new Dictionary<int, ShapeType> ();
		shapeByInt.Add (0, ShapeType.Circle);
		shapeByInt.Add (1, ShapeType.Diamond);
		shapeByInt.Add (2, ShapeType.Es);

		var fillByInt = new Dictionary<int, FillType> ();
		fillByInt.Add (0, FillType.Empty);
		fillByInt.Add (1, FillType.Striped);
		fillByInt.Add (2, FillType.Solid);

		var numberByInt = new Dictionary<int, NumberType> ();
		numberByInt.Add (0, NumberType.One);
		numberByInt.Add (1, NumberType.Two);
		numberByInt.Add (2, NumberType.Three);

		color = colorByInt [colorIndex];
		fill = fillByInt [fillIndex];
		shape = shapeByInt [shapeIndex];
		number = numberByInt [numberIndex];

		AttributesSumByTypeName = new Dictionary<AttributeType, int> ();
		AttributesSumByTypeName.Add(AttributeType.Color, colorIndex);
		AttributesSumByTypeName.Add(AttributeType.Fill, fillIndex);
		AttributesSumByTypeName.Add(AttributeType.Shape, shapeIndex);
		AttributesSumByTypeName.Add(AttributeType.Number, numberIndex);
	}

	public override String ToString() {
		return
			//color.ToString () +"\n" +
			fill.ToString () +"\n"+ shape.ToString () +"\n"+ number.ToString();
	}

	public enum AttributeType {
		Color,
		Shape,
		Fill,
		Number,
	}
	public enum ColorType {
		Red, 
		Green,
		Purple
	}
	public enum ShapeType {
		Diamond,
		Circle,
		Es
	}
	public enum FillType {
		Empty,
		Striped,
		Solid
	}

	public enum NumberType {
		One,
		Two,
		Three,
	}
}


