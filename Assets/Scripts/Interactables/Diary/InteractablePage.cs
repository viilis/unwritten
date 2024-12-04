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

    private GameObject canvasPrefabClone;
    private bool _state = false;

    private AudioPerAction _apa;

    public void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        //hide until first interaction;
        _outline.OutlineWidth = 0f;

        _apa = new AudioPerAction(pageBase.interactFX, this.transform, SoundManager.Instance.globalVolume);
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
    }

    public void Interact()
    {
        _state = !_state;

        if (!_state)
        {
            InputManager.Instance.EnableMouse();
            InputManager.Instance.EnableMovement();
            Destroy(canvasPrefabClone);

            this.gameObject.SetActive(false);

            DayManager.Instance._pages.Remove(this.gameObject);
            DayManager.Instance.PagesRead++;
        }
        else
        {
            _apa.PlayOnce();

            InputManager.Instance.DisableMouse();
            InputManager.Instance.DisableMovement();

            // Create clone of prefab ui, init page data.
            canvasPrefabClone = Instantiate(pageCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            canvasPrefabClone.GetComponent<DiaryCanvas>().InitDiaryCanvas(pageBase);
        }
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }
}