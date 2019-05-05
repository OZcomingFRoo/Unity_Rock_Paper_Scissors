using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains Scene's unique identification data.
/// You can use that data to load that scene
/// </summary>
[CreateAssetMenu(fileName = "Scene",menuName = "NextSceneToLoad")]
public class NextSceneToLoad : ScriptableObject
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private int sceneBuildIndex;

    public string SceneName { get { return sceneName; } }
    public int SceneBuildIndex { get { return sceneBuildIndex; } }
}
