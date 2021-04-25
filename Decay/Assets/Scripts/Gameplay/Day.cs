using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{
    public int maxPlacesToVisit = 2;
    public List<BuildingType> placesVisited { get; private set; } = new List<BuildingType>();
}
