using UnityEngine;

public class Guard : INPC
{
    public string DisplayName => "Guard";
    public string Dialogue => "I keep the village safe.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
