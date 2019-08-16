using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechKeyword_ColorChanger : MonoBehaviour
{

    public Renderer ren;

    private SpeechKeyword speech;
    private Material mat;

    private void Awake() {
        speech = GetComponent<SpeechKeyword>();
        mat = ren.sharedMaterial;
    }

    private void Start() {
        mat.SetColor("_Color", Color.gray);

        setupKeywords();
    }

    private void setupKeywords() {
        speech.keywords.Clear();

        speech.keywords.Add("red", () => {
            mat.SetColor("_Color", Color.red);
        });

        speech.keywords.Add("green", () => {
            mat.SetColor("_Color", Color.green);
        });

        speech.keywords.Add("blue", () => {
            mat.SetColor("_Color", Color.blue);
        });

        speech.keywords.Add("orange", () => {
            mat.SetColor("_Color", new Color(1f, 0.5f, 0f));
        });

        speech.keywords.Add("yellow", () => {
            mat.SetColor("_Color", Color.yellow);
        });

        speech.keywords.Add("pink", () => {
            mat.SetColor("_Color", Color.magenta);
        });

        speech.keywords.Add("magenta", () => {
            mat.SetColor("_Color", Color.magenta);
        });

        speech.keywords.Add("purple", () => {
            mat.SetColor("_Color", new Color(0.5f, 0f, 1f));
        });

        speech.keywords.Add("teal", () => {
            mat.SetColor("_Color", Color.cyan);
        });

        speech.keywords.Add("cyan", () => {
            mat.SetColor("_Color", Color.cyan);
        });

        speech.keywords.Add("white", () => {
            mat.SetColor("_Color", Color.white);
        });

        speech.keywords.Add("black", () => {
            mat.SetColor("_Color", Color.black);
        });

        speech.keywords.Add("gray", () => {
            mat.SetColor("_Color", Color.gray);
        });

        speech.init();
    }

}
