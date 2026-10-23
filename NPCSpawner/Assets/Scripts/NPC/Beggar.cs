using UnityEngine;

public class Beggar : INPC
{
    public string DisplayName => "Beggar";
    public string Dialogue => "Do you have some change to spare?";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
