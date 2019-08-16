// https://developer.microsoft.com/en-us/windows/mixed-reality/voice_input_in_unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechControl : MonoBehaviour {

    public Renderer ren;
    public AudioSource sound;

    private Material mat;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    
    private void Start() {
        mat = ren.sharedMaterial;
        mat.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));

        setupKeywords();

        init();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        System.Action keywordAction;

        sound.Play();

        Debug.Log("Heard keyword: \"" + args.text + "\"");

        if (keywords.TryGetValue(args.text, out keywordAction)) { // if the keyword recognized is in our dictionary, call that Action.
            keywordAction.Invoke();
        }
    }

    private void setupKeywords() {
        keywords.Add("red", () => { // Create keyword for keyword recognizer
            mat.SetColor("_Color", new Color(1f, 0f, 0f)); // action to be performed when this keyword is spoken
        });

        keywords.Add("green", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 0f));
        });

        keywords.Add("blue", () => {
            mat.SetColor("_Color", new Color(0f, 0f, 1f));
        });

        keywords.Add("orange", () => {
            mat.SetColor("_Color", new Color(1f, 0.5f, 0f));
        });

        keywords.Add("yellow", () => {
            mat.SetColor("_Color", new Color(1f, 1f, 0f));
        });

        keywords.Add("pink", () => {
            mat.SetColor("_Color", new Color(1f, 0f, 1f));
        });

        keywords.Add("purple", () => {
            mat.SetColor("_Color", new Color(0.5f, 0f, 1f));
        });

        keywords.Add("teal", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 1f));
        });

        keywords.Add("cyan", () => {
            mat.SetColor("_Color", new Color(0f, 1f, 1f));
        });

        keywords.Add("white", () => {
            mat.SetColor("_Color", new Color(1f, 1f, 1f));
        });

        keywords.Add("black", () => {
            mat.SetColor("_Color", new Color(0f, 0f, 0f));
        });

        keywords.Add("gray", () => {
            mat.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
        });
    }
    
    public void init() {
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    
}
