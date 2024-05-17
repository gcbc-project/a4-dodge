using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    protected void OnTriggerEnter2D(Collider2D collision);
}
