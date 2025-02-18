using System.Collections.Generic;
using UnityEngine;

public class DoorChallenge : MonoBehaviour
{
  private OpenableDoor _door;
  [SerializeReference] private IChallenge[] _challenges;

  private void Start()
  {
    TryGetComponent<OpenableDoor>(out _door);
    if (_door == null)
      Debug.LogError("No OpenableDoor component");
  }

  private void FixedUpdate()
  {
    if (CheckChallenges())
    {
      _door.OpenDoor();
    }
    else
    {
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
