using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PeronalMessage : MonoBehaviour {
    public Texture[] textures;
    public float[] showAfter;
    public float[] hideAfter;

    private float timer = 0f;
    private int index = 0;
	
	void Update () {
        timer += Time.deltaTime;
        if(index < textures.Length){
            if(timer >= showAfter[index]) {
                showTexture(textures[index]);
            }
            if (timer >= hideAfter[index]) {
                hideTexture();
                timer = 0f;
                index++;
            }
        }
	}

    void showTexture(Texture texture) {
        RawImage ri = GetComponent<RawImage>();
        ri.texture = texture;
        ri.color = new Color(255f, 255f, 255f, 255f);
    }

    void hideTexture() {
        RawImage ri = GetComponent<RawImage>();
        ri.color = new Color(0f, 0f, 0f, 0f);
    }
}
