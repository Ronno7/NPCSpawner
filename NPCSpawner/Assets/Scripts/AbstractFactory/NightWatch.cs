using UnityEngine;

public sealed class NightWatch : INPC
{
    public string DisplayName => "Night Watch";
    public string Dialogue => "I watch the streets during peaceful nights.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
