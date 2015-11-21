using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HighScoreManager : MonoBehaviour {

	public GameObject nameScore;
	public GameObject pointScore;
	private string link;
	void Start()
	{
		Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;
		link = "http://defensordofeudorecord.16mb.com/index1.php";
		StartCoroutine(GetHighScore(link));

	}
	
	IEnumerator GetHighScore(string url)
	{
		WWW u = new WWW(url);
		new WaitForSeconds(1f);
		yield return u;
		string[] opa = u.text.Split ('/','>');
		string pao = string.Join (";",opa);
		pao = pao.Replace (";", string.Empty);
		opa = pao.Split ('.');
		for (int i = 0, f = 1; f < opa.Length; i += 2, f += 2) 
		{
			nameScore.GetComponent<Text> ().text = nameScore.GetComponent<Text> ().text + opa [i] + "\n";
			pointScore.GetComponent<Text> ().text = pointScore.GetComponent<Text> ().text + opa [f] + "\n";
		}
	}
}

