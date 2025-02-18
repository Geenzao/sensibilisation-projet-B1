using UnityEngine;
using System;
using System.Collections.Generic;

public class ShapeReceptacle : IChallenge
{

  public ShapeType _shapeType;
  private bool _isCompleted;

  private List<Collision> _collidedShapesList = new List<Collision>();
  override public bool IsCompleted
  {
    get => _isCompleted;
  }
  public bool CheckShape(ShapeType shape)
  {
    return shape == _shapeType;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.TryGetComponent(out Shape shape) && CheckShape(shape.ShapeType))
    {
      _collidedShapesList.Add(collision);
      _isCompleted = true;
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    if (_collidedShapesList.Contains(collision))
    {
      _collidedShapesList.Remove(collision);
      if (_collidedShapesList.Count == 0)
      {
        _isCompleted = false;
      }
    }

  }
}
