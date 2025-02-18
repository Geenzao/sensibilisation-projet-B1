using System.Collections.Generic;
using UnityEngine;

public class DoorChallenge : MonoBehaviour
{
  private OpenableDoor _door;
  [SerializeReference] private IChallenge[] _challenges;
  private bool _isSuccess;

  private AudioSource _audioSource;
  [SerializeField] private AudioClip _sucessSound;

  private void Start()
  {
    TryGetComponent<OpenableDoor>(out _door);
    if (_door == null)
      Debug.LogError("No OpenableDoor component");
    _audioSource = GetComponent<AudioSource>();
    if (_audioSource == null)
      Debug.LogError("No audio source found");
  }

  private void FixedUpdate()
  {
    if (CheckChallenges() && !_isSuccess)
    {
      _isSuccess = true;
      _door.OpenDoor();
      _audioSource.PlayOneShot(_sucessSound);
    }
    else if (!CheckChallenges() && _isSuccess)
    {
      _isSuccess = false;
      _door.CloseDoor();
    }
  }

  private bool CheckChallenges()
  {
    foreach (var challenge in _challenges)
    {
      if (!challenge.IsCompleted)
      {
        return false;
      }
    }
    return true;
  }

}
