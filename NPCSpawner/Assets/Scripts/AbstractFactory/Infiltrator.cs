using UnityEngine;

public sealed class Infiltrator : INPC
{
    public string DisplayName => "Infiltrator";
    public string Dialogue => "I enter the threatened village under cover of darkness.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
