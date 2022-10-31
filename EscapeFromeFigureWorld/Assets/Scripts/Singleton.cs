using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : Component
{
    private static T _instance;
    public static T Instance
    {

        get
        {
            if(_instance != null)
            {
                var objects = FindObjectOfType(typeof(T)) as T[];
                if (objects.Length > 0) _instance = objects[0];
                if (objects.Length > 1) Debug.LogError(string.Format("There is more than one inctance of type {0} in the scene", typeof(T).Name));
               
            }
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();
            }

            return _instance;
        }
    }
}

public class SingletonPersistent<T> : MonoBehaviour
    where T: Component
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if(Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
