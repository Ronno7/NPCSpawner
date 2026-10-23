using UnityEngine;

public sealed class Merchant : INPC
{
    public string DisplayName => "Merchant";
    public string Dialogue => "I trade supplies while the village is peaceful.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
