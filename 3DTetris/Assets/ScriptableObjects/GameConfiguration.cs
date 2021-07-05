using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[InlineEditor]
[CreateAssetMenu(fileName = "GameConfiguration", menuName = "Configurations/GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    public FloatVariable RegularDropFrequency;
    public FloatVariable HighDropFrequency;
}
