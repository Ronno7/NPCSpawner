using System.Collections.Generic;
using UnityEngine;

// Visuals are separate from the plain C# NPCs created by the factory.
[RequireComponent(typeof(NPCSpawner))]
public class NPCDemoView : MonoBehaviour
{
    public GameObject villagerPrefab;
    private NPCSpawner spawner;
    private readonly List<GameObject> figures = new List<GameObject>();
    private GUIStyle heading, label, dialogue, button;

    private void Awake() => spawner = GetComponent<NPCSpawner>();
    private void OnEnable() => spawner.VillagersSpawned += ShowVillagers;
    private void OnDisable() => spawner.VillagersSpawned -= ShowVillagers;

    private void ShowVillagers()
    {
        foreach (GameObject figure in figures) Destroy(figure);
        figures.Clear();
        for (int i = 0; i < spawner.Villagers.Count; i++)
        {
            float x = (i - (spawner.Villagers.Count - 1) * .5f) * 2.4f;
            GameObject figure = Instantiate(villagerPrefab, new Vector3(x, 1, 0), Quaternion.identity, transform);
            figure.name = spawner.Villagers[i].DisplayName;
            figures.Add(figure);
        }
    }

    private void OnGUI()
    {
        if (heading == null)
        {
            heading = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };
            label = new GUIStyle(GUI.skin.label) { fontSize = 18, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
            dialogue = new GUIStyle(GUI.skin.label) { fontSize = 15, wordWrap = true, alignment = TextAnchor.UpperCenter };
            button = new GUIStyle(GUI.skin.button) { fontSize = 18 };
        }
        float scale = Mathf.Min(Screen.width / 1000f, Screen.height / 600f);
        Vector2 offset = new Vector2((Screen.width - 1000 * scale) / 2, (Screen.height - 600 * scale) / 2);
        Matrix4x4 previous = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(offset, Quaternion.identity, Vector3.one * scale);
        GUI.Label(new Rect(40, 30, 920, 44), "NPC Spawner", heading);
        GUI.Label(new Rect(40, 80, 920, 30), "Factory pattern demonstration");
        for (int i = 0; i < figures.Count; i++)
        {
            Vector3 screen = Camera.main.WorldToScreenPoint(figures[i].transform.position);
            float x = (screen.x - offset.x) / scale;
            GUI.Label(new Rect(x - 90, 365, 180, 30), spawner.Villagers[i].DisplayName, label);
            GUI.Label(new Rect(x - 85, 405, 170, 80), spawner.Villagers[i].Dialogue, dialogue);
        }
        if (figures.Count == 0)
            GUI.Label(new Rect(250, 270, 500, 40), "Spawn villagers to see the factory's output.", dialogue);
        if (GUI.Button(new Rect(400, 510, 200, 44), "Spawn villagers", button))
            spawner.SpawnVillagers();
        GUI.Label(new Rect(350, 565, 300, 28), "Keyboard shortcut: S", dialogue);
        GUI.matrix = previous;
    }
}
