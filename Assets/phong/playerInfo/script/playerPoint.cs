using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerInfo : MonoBehaviour
{
    public int points;
    public int attempts;
}

public class PlayerPoint : MonoBehaviour
{
    string filePath;
    PlayerInfo data = new PlayerInfo();

    void Awake()
    {
        // Use persistent path so it works in builds too
        filePath = Path.Combine(Application.dataPath, "phong/playerInfo/info.json");
        Load();

        // Each time game starts, increase attempt count
        data.attempts++;
        Save();

    }

    public void AddPoints(int amount)
    {
        data.points += amount;
        Save();
        Debug.Log($"Saved new points: {data.points}");
    }

    void Save()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<PlayerInfo>(json);
        }
        else
        {
            // Create default player data if file doesn’t exist
            data = new PlayerInfo { points = 0, attempts = 0 };
            Save();
        }
    }
}
