using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserAcount : MonoBehaviour {

	public Text realmoney;

	void Start()
	{
		getUserAmount ();
	}


	public void getUserAmount(){
		StartCoroutine (requestAmount ());
	}


	IEnumerator requestAmount()
	{


		WWWForm form = new WWWForm ();
		string id = PlayerPrefs.GetString ("unique_id");
		form.AddField ("id", id);

		var headers = form.headers;
		form.headers["content-type"] = "application/x-www-form-urlencoded";

		WWW www = new WWW (BaseURL.base_url + "getUserAmount", form);
		yield return www;


		if (www.error != null) {
			Debug.Log (www.error);

		} else {

			realmoney.text = www.text;
		}



		yield break;
	}
}
