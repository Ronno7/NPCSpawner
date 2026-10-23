using UnityEngine;

public class Farmer : INPC
{
    public string DisplayName => "Farmer";
    public string Dialogue => "I grow crops for the village.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
