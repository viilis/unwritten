using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject pgText;

    [SerializeField]
    private GameObject bgImage;

    private TMP_Text _text;
    private RawImage _bgImage;

    void Awake()
    {
        // get these before rendering and do stuff
        _text = pgText.GetComponent<TMP_Text>();
        _bgImage = bgImage.GetComponent<RawImage>();
    }

    public void SetPageTextTo(string newText)
    {
        _text.text = newText;
    }

    public void SetPaperImageTo(Texture2D newImage)
    {
        _bgImage.texture = newImage;
    }

    public void InitDiaryCanvas(PageBase pb)
    {
        SetPageTextTo(pb.pageText);
        SetPaperImageTo(pb.image);
    }
}