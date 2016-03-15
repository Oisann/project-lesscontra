using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour {
    public PlayerStats ps;
    public RectTransform LoseScreen;
    public RectTransform WinScreen;
    public float deathScreenCooldown = .7f;
    public int rewardMoney = 1000;

    private float deathScreenTimer = 0f;
    private bool gaveReward = false;

    void Update() {
        if(PlayerPrefs.GetInt("wonAlltogether") == 1) {
            WinScreen.gameObject.SetActive(true);
            if(!gaveReward) {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + rewardMoney);
                gaveReward = true;
            }
        }
        if(ps.health <= 0f) {
            deathScreenTimer += Time.deltaTime;
            if(deathScreenTimer >= deathScreenCooldown) {
                LoseScreen.gameObject.SetActive(true);
            }
        }
    }
}
