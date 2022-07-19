using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using Android.App;

public class TextToSpeechImplementation : Java.Lang.Object, TextToSpeech.IOnInitListener
{
    TextToSpeech speaker;
    string toSpeak;

    public TextToSpeechImplementation() { }

    public void Speak(string text)
    {
        var ctx = Application.Context; // useful for many Android SDK features
        toSpeak = text;
        if (speaker == null)
        {
            speaker = new TextToSpeech(ctx, this);
        }
        else
        {
            var p = new Dictionary<string, string>();
            speaker.Speak(toSpeak, QueueMode.Flush, p);
        }
    }

    public bool IsSpeaking
    {
        get { return speaker != null && speaker.IsSpeaking; }
    }

    #region IOnInitListener implementation
    public void OnInit(OperationResult status)
    {
        if (status.Equals(OperationResult.Success))
        {
            var p = new Dictionary<string, string>();
            speaker.Speak(toSpeak, QueueMode.Flush, p);
        }
    }
    #endregion
}