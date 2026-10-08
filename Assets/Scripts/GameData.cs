using UnityEngine;
public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public int score = 0;
    public int currentLevelScore = 2;
    public int failCount = 0;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}