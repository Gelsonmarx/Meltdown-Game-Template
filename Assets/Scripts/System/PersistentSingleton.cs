
using UnityEngine;

public class PersistentSingleton<T> : Singleton<T> where T : Component
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }
}