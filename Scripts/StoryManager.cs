using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private Detail_StoryData[] storyDatas;
    [SerializeField] private TextMeshProUGUI storytext;
    [SerializeField] private AudioClip audioClip;

    //ストーリーのエレメント配列番号が必要なのでプロパティを
    public int storyIndex { get; private set; }
    public int textIndex { get; private set; }
    private bool finishText = false;
    //Startで呼び出す
    void Start()
    {
        SetStoryElement(storyIndex, textIndex);    
    }

    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        var storyElement = storyDatas[_storyIndex].stories[_textIndex];
        //storytext.text = storyElement.StoryText;
        StartCoroutine(TypeSentence(_storyIndex, _textIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && finishText)
        {
            textIndex++; //インデックスを増やす
            finishText = false;
            //テキスト部を初期化
            storytext.text ="";
            ProgressionStory(storyIndex);

        }
    }

    private void ProgressionStory(int _storyIndex)
    {
        //ストーリーインデックスよりも大きいテキストは存在しないのでチェックして対応
        //最後まで行ったら次に進めたい
        if(textIndex < storyDatas[_storyIndex].stories.Count)
        {
            SetStoryElement(storyIndex, textIndex);
        }
        else
        {
            SceneManager.LoadScene("StartScene");
        }
    }

    //文字を１文字ずつ表示するコルーチン
    private IEnumerator TypeSentence(int _storyIndex, int _textIndex)
    {
        //１文字ずつ文字を分割した状態にする
        foreach(var letter in storyDatas[_storyIndex].stories[_textIndex].StoryText.ToCharArray())
        {
            storytext.text += letter;//1文字表示
            yield return new WaitForSeconds(0.03f);
        }
        finishText = true;
    }
}
