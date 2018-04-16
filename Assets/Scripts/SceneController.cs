using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	[SerializeField] private CardReveal originalCard;
	[SerializeField] private Sprite [] images;

	public const int gridRows = 2;
	public const int gridColumns = 4;
	public const float offsetX = 3f;
	public const float offsetY = 2.5f;

	private CardReveal _firstRevealed;
	private CardReveal _secondRevealed;
		
	void Start () {
		Vector3 startPos = originalCard.transform.position;

		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
		numbers = ShuffleArray (numbers);

		for (int i = 0; i < gridColumns; i++) {
			for (int j = 0; j < gridRows; j++) {
				CardReveal card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as CardReveal;
				}

				int index = j * gridColumns + i;
				int id = numbers [index];
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x; // set the position of the new card
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}	 
	}

	private int[] ShuffleArray (int [] numbers) { // Implementation of Knuth shuffle algorithm
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int temp = newArray [i];
			int replace = Random.Range (i, newArray.Length);
			newArray [i] = newArray [replace];
			newArray [replace] = temp;
		}
		return newArray;
	}

	public bool canReveal {
		get { return _secondRevealed == null; } // getter function that returns false if there is card already revealed 
	}

	public void CardRevealed (CardReveal card) {
	}
}
