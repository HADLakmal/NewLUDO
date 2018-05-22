using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paymentwall;
using UnityEngine.UI;
public class Buymoney : MonoBehaviour {

	public Text value;
	public void paypalPay(Text pay){
		int k = payTypeIdentify(pay.text);
		print (pay.text.Substring (k, pay.text.Length - k));
		StartCoroutine (paypal (pay.text.Substring(0,k),pay.text.Substring(k,pay.text.Length-k)));

	}
	public void paytmPay(Text pay){
		int k = payTypeIdentify(pay.text);
		StartCoroutine (paytm (pay.text.Substring(0,k),pay.text.Substring(k,pay.text.Length-k)));

	}

	int payTypeIdentify(string text){
		int k=0;
		for (int i = 0; i < text.Length; i++) {
			float payf;
			print (text [i]);
			if (float.TryParse (text[i]+"", out payf)){
				k=i;
				break;
			}else{
				continue;
			}
		}
		return k;
	}
	IEnumerator paypal(string paytype,string payment){
		WWWForm form = new WWWForm ();

		string id = PlayerPrefs.GetString ("unique_id");
		form.AddField ("id", id);
		form.AddField ("amountpay", payment);
		var headers = form.headers;
		form.headers["content-type"] = "application/x-www-form-urlencoded";

		WWW www = new WWW (BaseURL.base_url + "paypal", form);
		yield return www;


		if (www.error != null) {
			Debug.Log (www.error);

		} else {

			print (www.text);
			Application.OpenURL (www.text);
		}
	}

	IEnumerator paytm(string paytype,string payment){
		WWWForm form = new WWWForm ();

		string id = PlayerPrefs.GetString ("unique_id");
		form.AddField ("id", id);
		form.AddField ("amounttm", payment);

		var headers = form.headers;
		form.headers["content-type"] = "application/x-www-form-urlencoded";

		WWW www = new WWW (BaseURL.base_url + "generate", form);
		yield return www;


		if (www.error != null) {
			Debug.Log (www.error);

		} else {

			print (www.text);
			Application.OpenURL (www.text);
		}
	}
	public void updateText(Text value){
		this.value.text = value.text;
	}
}
