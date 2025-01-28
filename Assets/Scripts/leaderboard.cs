using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;

    void Start()
    {
        // Lade die verbleibende Zeit und konvertiere sie in Minuten:Sekunden
        float remainingTime = Timer.finalTime;
        int min = Mathf.FloorToInt(remainingTime / 60);
        int sec = Mathf.FloorToInt(remainingTime % 60);

        // Setze den Text auf die gespeicherte Zeit
        resultText.text = string.Format("Deine Zeit: {0:00}:{1:00}", min, sec);
    }
}
