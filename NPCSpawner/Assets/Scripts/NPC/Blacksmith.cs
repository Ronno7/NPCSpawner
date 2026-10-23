using UnityEngine;

public class Blacksmith : INPC
{
    public string DisplayName => "Blacksmith";
    public string Dialogue => "Bring me iron and I will forge you a tool.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
