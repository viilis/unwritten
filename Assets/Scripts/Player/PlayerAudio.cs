using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip footStep;

    private CharacterController _cc;

    private void Awake()
    {
        _cc = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_cc.velocity != Vector3.zero)
        {
            Transform _footposition = this.transform;
            _footposition.position = new Vector3(_footposition.position.x, _footposition.position.y - 1f, _footposition.position.z);

            try
            {
                //SoundManager.Instance.PlaySoundFX(footStep, _footposition);
            }
            catch (Exception err)
            {
                Debug.LogException(err);
            }
        }
    }
}