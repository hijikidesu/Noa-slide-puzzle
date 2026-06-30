using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data",menuName = "Detail_StoryData")]
public class Detail_StoryData : ScriptableObject
{
    public List<Story> stories = new List<Story>();
   
}

[System.Serializable]
public class Story
{
    [TextArea]
    public string StoryText;
    
}

