using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSaveGameManager : MonoBehaviour
{

    public static WorldSaveGameManager Instance { get; private set; }
    [SerializeField] int worldSceneIndex = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadNewGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(worldSceneIndex);
        yield return new WaitUntil(() => asyncLoad.isDone);
    }

    public int GetWorldSceneIndex()
    {
        return worldSceneIndex;
    }
}
