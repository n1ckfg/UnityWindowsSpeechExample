using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechDictation_ColorChanger : MonoBehaviour {

    public Renderer ren;

    private SpeechDictation speech;
    private Material mat;
    private string lastResult = "";

    private void Awake() {
        speech = GetComponent<SpeechDictation>();
        mat = ren.sharedMaterial;
    }

    private void Start() {
        mat.SetColor("_Color", Color.gray);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            speech.startListening();
        }

        if (speech.result != lastResult) {
            setColor(speech.result);
        }
    }

    private void setColor(string s) {
        switch (s) {
            case ("red"):
                mat.SetColor("_Color", Color.red);
                break;

            case ("green"):
                mat.SetColor("_Color", Color.green);
                break;

            case ("blue"):
                mat.SetColor("_Color", Color.blue);
                break;

            case ("orange"):
                mat.SetColor("_Color", new Color(1f, 0.5f, 0f));
                break;

            case ("yellow"):
                mat.SetColor("_Color", Color.yellow);
                break;

            case ("pink"):
                mat.SetColor("_Color", Color.magenta);
                break;

            case ("magenta"):
                mat.SetColor("_Color", Color.magenta);
                break;

            case ("purple"):
                mat.SetColor("_Color", new Color(0.5f, 0f, 1f));
                break;

            case ("teal"):
                mat.SetColor("_Color", Color.cyan);
                break;

            case ("cyan"):
                mat.SetColor("_Color", Color.cyan);
                break;

            case ("white"):
                mat.SetColor("_Color", Color.white);
                break;

            case ("black"):
                mat.SetColor("_Color", Color.black);
                break;

            case ("gray"):
                mat.SetColor("_Color", Color.gray);
                break;
        }

        lastResult = speech.result;
    }

}
