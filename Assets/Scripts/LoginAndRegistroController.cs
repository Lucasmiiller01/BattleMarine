using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LoginAndRegistroController : MonoBehaviour {
	private string[] logins = new string[100];
	private string[] senhas = new string[100];
	public Text login;
	public InputField senha;
	private string link;
	public GameObject mensage;
	private string url;
	void Start()
	{
		Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;
		link = "http://www.defensordofeudorecord.16mb.com/index1.php";

		url = "http://defensordofeudorecord.16mb.com/Conexao.php";
		StartCoroutine(GetLoginAndSenha(link));
	}
	public void CompareAndValida()
	{
		for (int i = 0; i < 100; i ++) 
		{
			
			if(login.text == logins[i] && senha.text == senhas[i] && login.text != "")
			{
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Login Realizado com Sucesso.";
				mensage.GetComponent<Text>().color = Color.green;
				break;
			}
			
			else
			{ 
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Usuario ou senha incorreta.";
				mensage.GetComponent<Text>().color = Color.red;
				
			}
		}
		
	}
	public void GetRegistro()
	{
		StartCoroutine(GetLoginAndSenha(link));
		
	}
	public void SetRegistroToData()
	{
		for (int i = 0; i < 100; i ++) 
		{
			if(logins[i] != login.text)
			{
				if(senha.text != "" && login.text != "" && i > 98){

					mensage.SetActive(true);
					mensage.GetComponent<Text>().text = "Cadastro Realizado com Sucesso.";
					mensage.GetComponent<Text>().color = Color.green;
					
					WWWForm rada = new WWWForm();
					rada.AddField("senha", senha.text);
					rada.AddField("login", login.text);
					WWW www = new WWW(url,rada);
					print(i);
					break;
				}
				else
				{ 
					mensage.GetComponent<Text>().text = "Preencha todos os dados.";
					mensage.GetComponent<Text>().color = Color.red;
					mensage.SetActive(true);
				}
			}
			else 
			{
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Usuario ja cadastrado.";
				mensage.GetComponent<Text>().color = Color.red;
				break;
			}

		}

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

