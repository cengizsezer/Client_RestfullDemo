using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T I;

    public virtual void Awake()
    {
        I = this as T;
    }

}
