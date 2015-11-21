using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GetRegistros : MonoBehaviour {
	private string[] logins = new string[100];
	private string[] senhas = new string[100];
	public Text login;
	public InputField senha;
	private string link;
	public GameObject mensage;
	void Start()
	{
		Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;
		link = "http://www.defensordofeudorecord.16mb.com/index1.php";
		StartCoroutine(GetLoginAndSenha(link));
	}
	public void CompareAndValida()
	{
		for (int i = 0; i < 100; i ++) 
		{

			if(login.text == logins[i] && senha.text == senhas[i])
			{
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Login Realizado com Sucesso.";
				mensage.GetComponent<Text>().color = Color.green;
				break;
			}
			
			else
			{ 
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Registre-se.";
				mensage.GetComponent<Text>().color = Color.yellow;

			}
		}
		
	}
	public void GetRegistro()
	{
		StartCoroutine(GetLoginAndSenha(link));
		
	}

	IEnumerator GetLoginAndSenha(string url)
	{
		WWW u = new WWW(url);
		new WaitForSeconds(1f);
		yield return u;
		if(u.error == null){
			string[] opa = u.text.Split ('/','>');
			string pao = string.Join (";",opa);
			pao = pao.Replace (";", string.Empty);
			opa = pao.Split ('.');

			for (int i = 0,z = 0,h = 0, f = 1; f < opa.Length; i += 2, f += 2,z ++) 
			{
				logins[z] = opa [i];
				senhas[z] = opa [f];
			}
		}
		else
		{

			mensage.SetActive(true);
			mensage.GetComponent<Text>().text = "Verifique sua internet.";
			mensage.GetComponent<Text>().color = Color.red;
		}

	}
}

