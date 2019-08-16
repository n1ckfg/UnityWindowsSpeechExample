// https://developer.microsoft.com/en-us/windows/mixed-reality/voice_input_in_unity
// Dictation recognition is slower than keyword recognition, for when you don't know keywords in advance.
// It's only available in Windows 10 and on UWP devices like HoloLens.
// It requires internet access and must be enabled here:
//   Settings > Privacy > Speech > Online Speech Recognition
// It's designed to be triggered, analyze input, and then stop listening.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechDictation : MonoBehaviour {

    public enum ConfidenceLevel { HIGH, MEDIUM, LOW };
    public ConfidenceLevel confidenceLevel = ConfidenceLevel.MEDIUM;
    public string result = "";
    public bool listenOnStart = false;
    public bool runContinuously = false;
    public bool lastWordOnly = true;
    public AudioSource sound;

    private DictationRecognizer dictationRecognizer;

    private void Start() {
        init();

        if (listenOnStart) {
            startListening();
        }
    }

    public void init() {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.DictationResult += (text, confidence) => {
            if ((int)confidence <= (int)confidenceLevel) {
                sound.Play();

                if (lastWordOnly) {
                    string[] resultArray = text.Split(' ');
                    result = resultArray[resultArray.Length - 1];
                } else {
                    result = text;
                }

                Debug.Log("Dictation result: " + text + " " + confidence);
            } else {
                Debug.Log("Dictation confidence too low: " + text + " " + confidence);
            }

            if (!runContinuously) stopListening();
        };

        dictationRecognizer.DictationHypothesis += (text) => {
            Debug.Log("Dictation hypothesis: " + text);
        };

        dictationRecognizer.DictationComplete += (completionCause) => {
            if (completionCause != DictationCompletionCause.Complete) Debug.Log("Dictation error: " + completionCause);
        };

        dictationRecognizer.DictationError += (error, hresult) => {
            Debug.Log("Dictation error: " + error + " " + hresult);
        };
    }

    public void startListening() {
        dictationRecognizer.Start();
    }

    public void stopListening() {
        dictationRecognizer.Stop();
    }

}
