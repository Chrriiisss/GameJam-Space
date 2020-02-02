using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;

public static Coroutine ExecuteLater(this MonoBehaviour behaviour, float delay, System.Action fn)
{
return behaviour.StartCoroutine(_realExecute(delay, fn));
}

public class WindowsVoice : MonoBehaviour
{
[DllImport("WindowsVoice")]
public static extern void initSpeech();
[DllImport("WindowsVoice")]
public static extern void destroySpeech();
[DllImport("WindowsVoice")]
public static extern void addToSpeechQueue(string s);
[DllImport("WindowsVoice")]
public static extern void clearSpeechQueue();
[DllImport("WindowsVoice")]
public static extern void statusMessage(StringBuilder str, int length);
public static WindowsVoice theVoice = null;
void OnEnable()
{
if (theVoice == null)
{
theVoice = this;
initSpeech();
}
}
public void test()
{
speak("Testing");
}
public static void speak(string msg, float delay = 0f)
{
if (Timeline.theTimeline.QReprocessingEvents)
return;

if (delay == 0f)
addToSpeechQueue(msg);
else
theVoice.ExecuteLater(delay, () = &amp; amp; amp; amp; gt; speak(msg));
}
void OnDestroy()
{
if (theVoice == this)
{
Debug.Log("Destroying speech");
destroySpeech();
Debug.Log("Speech destroyed");
theVoice = null;
}
}
public static string GetStatusMessage()
{
StringBuilder sb = new StringBuilder(40);
statusMessage(sb, 40);
return sb.ToString();
}
}