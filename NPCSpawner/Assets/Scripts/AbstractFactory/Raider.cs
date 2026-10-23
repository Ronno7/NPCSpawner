using UnityEngine;

public sealed class Raider : INPC
{
    public string DisplayName => "Raider";
    public string Dialogue => "I attack the village in daylight.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
