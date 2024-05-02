using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private const string GameSaveKey = "GameSaveData";

    public static void Save(Game game)
    {
        string json = JsonUtility.ToJson(game, true);
        PlayerPrefs.SetString(GameSaveKey, json);
        PlayerPrefs.Save(); // Ensure data is written to disk immediately
    }

    public static Game Load()
    {
        Game game = new Game();

        if (PlayerPrefs.HasKey(GameSaveKey))
        {
            string json = PlayerPrefs.GetString(GameSaveKey);
            game = JsonUtility.FromJson<Game>(json);
        }
        else
        {
            Save(game); // Initialize and save default game data if nothing is saved yet
        }

        return game;
    }

    [System.Serializable]
    public class Game
    {
        public int JugglingLevel;
        public float Money;
        public int Energy;
        public List<int> UnlockingLvl = new List<int>();
        public bool TutorialSlot = true;
        public bool TutorialMenu = true;
        public bool TutorialChess = true;
        public bool TutorialJuggling = true;

        public float MenuSounds = 0.5f;
        public float MenuMusic = 0f;
        public float GameSounds = 0.5f;
        public float GameMusic = 0.5f;
        public float ButtonsGame = 0f;

        public Game()
        {
            JugglingLevel = 0;
            Money = 200;
            Energy = 1;
        }
    }
}