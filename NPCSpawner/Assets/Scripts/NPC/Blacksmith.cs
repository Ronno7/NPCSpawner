using UnityEngine;

public class Blacksmith : INPC
{
    public string DisplayName => "Blacksmith";
    public string Dialogue => "I forge tools and repair equipment.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
