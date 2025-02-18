using System;
using UnityEngine;

public class OpenableDoor : MonoBehaviour
{
  private Animator _animator;
  private AudioSource _audioSource;
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
      _isOpen = true;
    }
  }

  public void CloseDoor()
  {
    if (_isOpen)
    {
      _animator.SetTrigger("Close");
      _isOpen = false;
    }
  }
}
