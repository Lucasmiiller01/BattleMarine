using UnityEngine;
using System.Collections;

public class TileIntegrationManager : MonoBehaviour {

	public string[] chars = new string[10];

	private GameObject[,] tiles = new GameObject[10,10];

	void Start () 
	{
		GetTiles ();
	}

	void GetTiles()
	{
		for(int j = 0; j < 10; j++)
		{
			for(int i = 0, f = 1; i < 10; i++, f++)
			{
				tiles[j,i] = GameObject.Find("Map/" + this.gameObject.name + "/" + chars[j] + "/" + f); 
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
