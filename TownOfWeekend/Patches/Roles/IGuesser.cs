using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TownOfWeekend.Roles;

public interface IGuesser
{
    public Dictionary<byte, (GameObject, GameObject, GameObject, TMP_Text)> Buttons { get; set; }
}