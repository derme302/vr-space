using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    // Private Variables
    private float counter;
    private int frames;
    private float fps;

    // GUI Sytles
    private static GUIStyle whiteStyle;
    private static GUIStyle blackStyle;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // FPS 
        counter += Time.deltaTime;
        frames += 1;

        if (counter >= 1.0f) {
            fps = (float)frames / counter;

            counter = 0.0f;
            frames = 0;
        }	
	}

    protected virtual void OnGUI() {

        if (fps > 0.0f) {
            DrawText("FPS: " + fps.ToString("0"), TextAnchor.UpperLeft);
        }
    }

    private static void DrawText(string text, TextAnchor anchor, int offsetX = 15, int offsetY = 15) {
        if (string.IsNullOrEmpty(text) == false) {
            if (whiteStyle == null || blackStyle == null) {
                whiteStyle = new GUIStyle();
                whiteStyle.fontSize = 20;
                whiteStyle.fontStyle = FontStyle.Bold;
                whiteStyle.wordWrap = true;
                whiteStyle.normal = new GUIStyleState();
                whiteStyle.normal.textColor = Color.white;

                blackStyle = new GUIStyle();
                blackStyle.fontSize = 20;
                blackStyle.fontStyle = FontStyle.Bold;
                blackStyle.wordWrap = true;
                blackStyle.normal = new GUIStyleState();
                blackStyle.normal.textColor = Color.black;
            }

            whiteStyle.alignment = anchor;
            blackStyle.alignment = anchor;

            var sw = (float)Screen.width;
            var sh = (float)Screen.height;
            var rect = new Rect(0, 0, sw, sh);

            rect.xMin += offsetX;
            rect.xMax -= offsetX;
            rect.yMin += offsetY;
            rect.yMax -= offsetY;

            rect.x += 1;
            GUI.Label(rect, text, blackStyle);

            rect.x -= 2;
            GUI.Label(rect, text, blackStyle);

            rect.x += 1;
            rect.y += 1;
            GUI.Label(rect, text, blackStyle);

            rect.y -= 2;
            GUI.Label(rect, text, blackStyle);

            rect.y += 1;
            GUI.Label(rect, text, whiteStyle);
        }
    }
}
