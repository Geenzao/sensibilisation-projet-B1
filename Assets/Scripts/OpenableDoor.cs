using System;
using UnityEngine;
using UnityEngine.Audio;

public class OpenableDoor : MonoBehaviour
{
  private Animator _animator;
  private AudioSource _audioSource;
  [SerializeField] private AudioClip _openDoorSound;
  [SerializeField] private AudioClip _closeDoorSound;
  private bool _isOpen = false;

  void Start()
  {
    _animator = GetComponent<Animator>();
    if (_animator == null)
      Debug.LogError("No animator found");
    _audioSource = GetComponent<AudioSource>();
    if (_audioSource == null)
      Debug.LogError("No audio source found");
  }

  public void OpenDoor()
  {
    if (!_isOpen)
    {
      _animator.SetTrigger("Open");
      if (_audioSource.isPlaying && _audioSource.clip == _openDoorSound)
        _audioSource.Stop();
      _audioSource.PlayOneShot(_openDoorSound);
      _isOpen = true;
    }
  }

  public void CloseDoor()
  {
    if (_isOpen)
    {
      _animator.SetTrigger("Close");
      _audioSource.Stop();
      _audioSource.PlayOneShot(_closeDoorSound);
      _isOpen = false;
    }
  }
}
