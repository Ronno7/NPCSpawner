using UnityEngine;

public class Guard : INPC
{
    public string DisplayName => "Guard";
    public string Dialogue => "I patrol the village and keep it safe.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
