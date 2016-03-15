using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateMoneyCounter : MonoBehaviour {
    private Text moneyText;

    void Start() {
        moneyText = GetComponent<Text>();
    }
    
    //Make this more fancy later!!
	void Update () {
        moneyText.text = "$" + PlayerPrefs.GetInt("money");
	}
}
