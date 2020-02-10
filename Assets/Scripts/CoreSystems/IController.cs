using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    CharacterAttackSystem GetAttackSystem();
    CharacterStatsSystem GetStatsSystem();

}
