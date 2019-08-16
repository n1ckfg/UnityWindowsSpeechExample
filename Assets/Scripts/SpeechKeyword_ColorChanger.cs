using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechKeyword_ColorChanger : MonoBehaviour
{

    public SpeechKeyword speech;

    private Material mat;

    private void Awake() {
        mat = GetComponent<Renderer>().sharedMaterial;
    }

    private void Start() {
        mat.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));

        setupKeywords();
    }

    private void setupKeywords() {
        speech.keywords.Clear();

        speech.keywords.Add("red", () => {
            mat.SetColor("_Color", new Color(1f, 0f, 0f));
        });

        speech.keywords.Add("green", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 0f));
        });

        speech.keywords.Add("blue", () => {
            mat.SetColor("_Color", new Color(0f, 0f, 1f));
        });

        speech.keywords.Add("orange", () => {
            mat.SetColor("_Color", new Color(1f, 0.5f, 0f));
        });

        speech.keywords.Add("yellow", () => {
            mat.SetColor("_Color", new Color(1f, 1f, 0f));
        });

        speech.keywords.Add("pink", () => {
            mat.SetColor("_Color", new Color(1f, 0f, 1f));
        });

        speech.keywords.Add("purple", () => {
            mat.SetColor("_Color", new Color(0.5f, 0f, 1f));
        });

        speech.keywords.Add("teal", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 1f));
        });

        speech.keywords.Add("cyan", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 1f));
        });

        speech.keywords.Add("white", () => {
            mat.SetColor("_Color", new Color(1f, 1f, 1f));
        });

        speech.keywords.Add("black", () => {
            mat.SetColor("_Color", new Color(0f, 0f, 0f));
        });

        speech.keywords.Add("gray", () => {
            mat.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
        });

        speech.init();
    }

}
