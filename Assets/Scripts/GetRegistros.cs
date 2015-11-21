using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GetRegistros : MonoBehaviour {

	private string link;
	void Start()
	{
		Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;
		link = "http://defensordofeudorecord.16mb.com/index1.php";
		StartCoroutine(GetHighScore(link));
		
	}
	
	public IEnumerator GetHighScore(string url)
	{
		WWW u = new WWW(url);
		new WaitForSeconds(1f);
		yield return u;
		string[] opa = u.text.Split ('/','>');
		string pao = string.Join (";",opa);
		pao = pao.Replace (";", string.Empty);
		opa = pao.Split ('.');


	}
}

