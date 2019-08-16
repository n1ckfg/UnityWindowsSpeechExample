// https://developer.microsoft.com/en-us/windows/mixed-reality/voice_input_in_unity
// Keyword recognition is fastest and easiest if you know the commands you need in advance.
// It's available in Windows 7, 8, 10, and on UWP devices like HoloLens.
// It doesn't require internet access or any special permissions.
// It's designed to run continually, listening for keywords.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechKeyword : MonoBehaviour {

    public enum ConfidenceLevel { HIGH, MEDIUM, LOW };
    public ConfidenceLevel confidenceLevel = ConfidenceLevel.MEDIUM;
    public AudioSource sound;
    public bool setupKeywordsOnStart = false;

    [HideInInspector] public Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private KeywordRecognizer keywordRecognizer;
    
    private void Start() {
        if (setupKeywordsOnStart) setupKeywords();
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
        startListening();
    }

    public void startListening() {
        keywordRecognizer.Start();
    }

    public void stopListening() {
        keywordRecognizer.Stop();
    }

}
