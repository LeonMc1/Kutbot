using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{
    public Text leaderboardText; // UI-Text zur Anzeige des Leaderboards
    private List<PlayerScore> scores = new List<PlayerScore>();

    void Start()
    {
        LoadLeaderboard();
        DisplayLeaderboard();
    }

    // Füge einen neuen Eintrag zum Leaderboard hinzu
    public void AddScore(string playerName, float remainingTime)
    {
        scores.Add(new PlayerScore(playerName, remainingTime));
        // Sortiere die Liste basierend auf verbleibender Zeit (je weniger Zeit, desto besser)
        scores.Sort((a, b) => a.remainingTime.CompareTo(b.remainingTime));
        SaveLeaderboard();
        DisplayLeaderboard();
    }

    // Speichert die Leaderboard-Daten lokal
    void SaveLeaderboard()
    {
        for (int i = 0; i < scores.Count && i < 10; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, scores[i].name);
            PlayerPrefs.SetFloat("PlayerTime" + i, scores[i].remainingTime);
        }
    }

    // Lädt das Leaderboard aus den gespeicherten Daten
    void LoadLeaderboard()
    {
        scores.Clear();
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("PlayerName" + i))
            {
                string name = PlayerPrefs.GetString("PlayerName" + i);
                float time = PlayerPrefs.GetFloat("PlayerTime" + i);
                scores.Add(new PlayerScore(name, time));
            }
        }
    }

    // Zeigt das Leaderboard an
    void DisplayLeaderboard()
    {
        leaderboardText.text = "Leaderboard:\n";
        foreach (var score in scores)
        {
            leaderboardText.text += $"{score.name}: {score.remainingTime:F2} Sekunden\n";
        }
    }
}

// Hilfsklasse für Spieler-Scores
[System.Serializable]
public class PlayerScore
{
    public string name; // Name des Spielers
    public float remainingTime; // Verbleibende Zeit in Sekunden

    public PlayerScore(string name, float remainingTime)
    {
        this.name = name;
        this.remainingTime = remainingTime;
    }
}
