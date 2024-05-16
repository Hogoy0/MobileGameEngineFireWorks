using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : UnityEngine.Component
{
    private static T singleton = null;

    public static T Singleton
    {
        get
        {
            if (null == singleton)
            {
                string strID = (typeof(T)).ToString();
                Singleton = new GameObject(strID).AddComponent<T>();
            }
            return singleton;
        }
        protected set
        {
            if (null != singleton) return;
            singleton = value;
            DontDestroyOnLoad(singleton.gameObject);
        }
    }
}