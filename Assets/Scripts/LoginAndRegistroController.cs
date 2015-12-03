using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LoginAndRegistroController : MonoBehaviour {
	
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

	}
	public void CompareAndValida()
	{
		StartCoroutine (CheckLogin(login.text, senha.text));
	
	}

	IEnumerator CheckLogin(string user, string pass)
	{
			yield return new WaitForSeconds (0f);
			WWW w = new WWW (link + "?service=login&user=" + user + "&pass=" + pass);
			yield return w;
			if (!string.IsNullOrEmpty (w.error)) {
				print (w.error);
			} else {
				switch(w.text)
				{
					case "0":
						mensage.SetActive(true);
						mensage.GetComponent<Text>().text = "Senha incorreto.";
						mensage.GetComponent<Text>().color = Color.red;
						break;
					case "-1":
						mensage.SetActive(true);
						mensage.GetComponent<Text>().text = "Usuario nao existe.";
						mensage.GetComponent<Text>().color = Color.red;
						break;
					case "1":
						mensage.SetActive(true);
						mensage.GetComponent<Text>().text = "Login Realizado com Sucesso.";
						mensage.GetComponent<Text>().color = Color.green;
						Application.LoadLevel("Game");
						break;

					default:
						Debug.LogError (w.text);
						break;
				}
			}
		}

	
	IEnumerator SetRegistro(string user, string pass)
	{
			yield return new WaitForSeconds (0f);
			WWW w = new WWW (link + "?service=cadastro&user=" + user + "&pass=" + pass);
			yield return w;
			if (!string.IsNullOrEmpty (w.error)) {
				print (w.error);
			} else {
				switch(w.text)
				{
				case "New login created successfully":
					mensage.SetActive(true);
					mensage.GetComponent<Text>().text = "Usuario cadastrado com Sucesso.";
					mensage.GetComponent<Text>().color = Color.red;
					break;
				case "Error":
					mensage.SetActive(true);
					mensage.GetComponent<Text>().text = "Erro ao cadastrar.";
					mensage.GetComponent<Text>().color = Color.red;
					break;
					
				default:
					Debug.LogError (w.text);
					break;
				}
			}
		}
	
	
	public void SetRegistroToData()
	{
		StartCoroutine (SetRegistro(login.text, senha.text));
	}
	
}