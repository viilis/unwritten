using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class InteractablePage : MonoBehaviour, IInteractable
{
    [SerializeField]
    private PageBase pageBase;

    private Outline _outline;
    private float _outlineWidth;

    [SerializeField]
    private GameObject pageCanvasPrefab;

    private GameObject prefabClone;
    private bool _state = false;

    public void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        //hide until first interaction;
        _outline.OutlineWidth = 0f;
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;

        //Debug.Log(pageBase.pageText.Substring(0, 10) + "...");
    }

    public void Interact()
    {
        _state = !_state;

        if (!_state)
        {
            InputManager.Instance.EnableMouse();
            InputManager.Instance.EnableMovement();
            Destroy(prefabClone);
        }
        else
        {

            InputManager.Instance.DisableMouse();
            InputManager.Instance.DisableMovement();

            // Create clone of prefab ui, init page data.
            prefabClone = Instantiate(pageCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            prefabClone.GetComponent<DiaryCanvas>().InitDiaryCanvas(pageBase);
        }
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }
}