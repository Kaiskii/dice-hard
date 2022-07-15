using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T :Singleton<T>
{
    public static T Instance { get; private set; }

    void Awake () {
        /***
        * Enforce Singleton Pattern described above.
        ***/
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = (T)this;
        Setup();
    }

    protected virtual void Setup()
    {

    }
}