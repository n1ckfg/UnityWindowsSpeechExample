// https://developer.microsoft.com/en-us/windows/mixed-reality/voice_input_in_unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechKeyword : MonoBehaviour {

    public enum ConfidenceLevel { HIGH, MEDIUM, LOW };
    public ConfidenceLevel confidenceLevel = ConfidenceLevel.MEDIUM;
    public AudioSource sound;
    public bool initOnStart = false;

    [HideInInspector] public Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private KeywordRecognizer keywordRecognizer;
    
    private void Start() {
        if (initOnStart) {
            setupKeywords();
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        System.Action keywordAction;

        sound.Play();

        Debug.Log("Heard keyword: \"" + args.text + "\"");

        if (keywords.TryGetValue(args.text, out keywordAction)) { // if the keyword recognized is in our dictionary, call that Action.
            keywordAction.Invoke();
        }
    }

    public void setupKeywords() {
        keywords.Clear();

        keywords.Add("red", () => { // Create keyword for keyword recognizer
            // action to be performed when this keyword is spoken
        });

        init();
    }
    
    public void init() {
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray(), (UnityEngine.Windows.Speech.ConfidenceLevel) confidenceLevel);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    
}
