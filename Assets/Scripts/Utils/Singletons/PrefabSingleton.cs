﻿using UnityEngine;
namespace Utils
{
    /*
     * http://answers.unity.com/answers/1408687/view.html
     */
    public class PrefabSingleton<T>: MonoBehaviour where T : PrefabSingleton<T>
    {
        private const string m_AssetPath = "Singletons/";
        private static T m_Instance = null;
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();
                    if (m_Instance == null)
                    {
                        var prefab = Resources.Load<T>(m_AssetPath + typeof(T).Name);
                        if (prefab == null)
                            Debug.LogError("Singleton prefab missing: " + m_AssetPath + typeof(T).Name);
                        else
                            m_Instance = Instantiate(prefab);
                    }
                    DontDestroyOnLoad(m_Instance.gameObject);
                }
                return m_Instance;
            }
        }
    }
}