using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static void Save(Game game)
    {
        string json = JsonUtility.ToJson(game, true);
        File.WriteAllText(GetSavePath(), json);
    }

    public static Game Load()
    {
        Game game = new Game();

        string path = GetSavePath();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            game = JsonUtility.FromJson<Game>(json);   
        }

        else
        {
            Save(game);
        }
        return game;
    }
    //public static Game Load()
    //{
    //    string path = GetSavePath();
    //    var formatter = new BinaryFormatter();
    //    Game result = new Game();

    //    if (File.Exists(path))
    //        using (var fileStream = new FileStream(path, FileMode.Open))
    //        {
    //            try
    //            {
    //                result = (Game)formatter.Deserialize(fileStream);
    //            }
    //            catch (Exception e)
    //            {
    //                Debug.LogError(e);
    //            }
    //        }

    //    else
    //        Save(result);

    //    return result;
    //}

    //public static void Save(Game game)
    //{
    //    var formatter = new BinaryFormatter();
    //    using (var fileStream = new FileStream(GetSavePath(), FileMode.OpenOrCreate))
    //        formatter.Serialize(fileStream, game);

    //}

    public static string GetSavePath()
    {
        string path = $"{Application.dataPath}/Save/Main.json";
        return path;
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
