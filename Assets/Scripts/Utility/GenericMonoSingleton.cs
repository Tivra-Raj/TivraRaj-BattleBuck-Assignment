using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Someone Creating a Duplicte to of this singleton");
            Destroy(gameObject);
        }
    }
}