using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetRegistro : MonoBehaviour {
	private string url;
	public Text login;
	public InputField senha;
	public GameObject mensage;

	
	
	
	void Start () {
		url = "http://defensordofeudorecord.16mb.com/Conexao.php";

	}

	
	public void SetRegistroToData()
	{
		if(senha.text != "" && login.text != ""){
			WWWForm rada = new WWWForm();
			rada.AddField("senha", senha.text);
			
			rada.AddField("login", login.text);
			
			WWW www = new WWW(url,rada);
			if(www.error == null)
			{
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Cadastro Realizado com Sucesso.";
				mensage.GetComponent<Text>().color = Color.green;
			}
			else 
			{
				mensage.SetActive(true);
				mensage.GetComponent<Text>().text = "Verifique sua internet.";
				mensage.GetComponent<Text>().color = Color.yellow;
			}
		}
		else
		{ 
			mensage.GetComponent<Text>().text = "Preencha todos os dados.";
			mensage.GetComponent<Text>().color = Color.red;
			mensage.SetActive(true);
		}
		
	}
}
