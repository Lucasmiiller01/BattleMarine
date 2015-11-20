using UnityEngine;
using System.Collections;

public class ShipSelectController : MonoBehaviour {

	public GameObject father;

	private int select;

	void OnMouseDown()
	{
		if(select.Equals(0))
		{
			this.GetComponent<SpriteRenderer> ().color = Color.blue;
			select = 1;
			TileLightsManager.shipSelect = this.gameObject;
		}
		else if (select.Equals(1)) 
		{
			this.GetComponent<SpriteRenderer> ().color = Color.green;
			select = 2;
			TileLightsManager.shipSelect = null;
		}
	}

	void Update()
	{
		if(select.Equals(1) && Input.GetAxis("Horizontal") > 0)
		{
			father.transform.rotation = new Quaternion(0,0,-90,90);
		}
		if(select.Equals(1) && Input.GetAxis("Horizontal") < 0)
		{
			father.transform.rotation = new Quaternion(0,0,0,0);
		}
	}

	public void SetPosition(Vector3 position)
	{
		if(select.Equals(1))
			father.transform.position = position;
	}
}
