using UnityEngine;

// 
// Summary: 
//    Generic singleton base for manager creation
//
// Note: Do not just spawn random singletons. Con of using singletons is that they create a lot of dependencies
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static bool debug = false;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    SetupInstance();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            instance = gameObj.AddComponent<T>();

            DontDestroyOnLoad(gameObj);
        }
    }

    public void RemoveDuplicates()
    {
        if (instance == null)
        {
            instance = this as T;

            if (debug)
            {
                Debug.Log("Set as instance: " + gameObject.name);
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (debug)
            {
                Debug.Log("Removing duplicates: Destroy " + gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}