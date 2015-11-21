using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetRegistro : MonoBehaviour {
	private string url;
	public Text login;
	public Text senha;
	public GameObject Registrado;
	
	
	
	void Start () {
		url = "http://defensordofeudorecord.16mb.com/Conexao.php";

	}
	
	
	
	public void SetRegistroToData()
	{
		if(senha.text != "" || login.text != ""){
			WWWForm rada = new WWWForm();
			rada.AddField("senha", senha.text);
			
			rada.AddField("login", login.text);
			
			WWW www = new WWW(url,rada);
			Registrado.SetActive(true);
			Registrado.GetComponent<Text>().text = "Login Realizado com Sucesso.";
			Registrado.GetComponent<Text>().color = Color.green;
		}
		else{ 
			Registrado.GetComponent<Text>().text = "Preencha todas as informaçoes.";
			Registrado.GetComponent<Text>().color = Color.red;
			Registrado.SetActive(true);
		}
		
	}
}
