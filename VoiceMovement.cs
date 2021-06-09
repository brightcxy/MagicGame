using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
    //adding words to dictionary
        actions.Add("forward", Forward);
        actions.Add("Create", Create);
        actions.Add("Destroy", Destroy);
        actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

//call the voice function when speat the word
    private void Forward()
    {
        transform.Translate(1, 0, 0);

    }

    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Create()
    {
        transform.Translate(0, 10, 0);
    }

    private void Destroy()
    {
        transform.Translate(0, -10, 0);
    }
}
