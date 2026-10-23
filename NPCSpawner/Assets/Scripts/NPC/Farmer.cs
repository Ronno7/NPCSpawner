using UnityEngine;

public class Farmer : INPC
{
    public string DisplayName => "Farmer";
    public string Dialogue => "You reap what you sow!";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
