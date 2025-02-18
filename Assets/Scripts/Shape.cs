using UnityEngine;

public enum ShapeType
{
  Circle,
  Square,
  Triangle
}

public class Shape : MonoBehaviour
{
  [SerializeField] private ShapeType _shapeType;

  public ShapeType ShapeType
  {
    get => _shapeType;
  }
}
