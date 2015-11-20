using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] Ships;
	public Transform[] positionsShips;

	void Start(){
		StartRound ();
	}

	public void StartRound() {

			for(int i = 0, f = 0; i < 8; i++, f++)
			{
			if(i.Equals(0) || i.Equals(2)|| i.Equals(4)|| i.Equals(6)|| i.Equals(8)) Instantiate(Ships[0], positionsShips[f].position, Quaternion.identity);
			
				else Instantiate(Ships[1], positionsShips[f].position, Quaternion.identity);

			}
	}
}
