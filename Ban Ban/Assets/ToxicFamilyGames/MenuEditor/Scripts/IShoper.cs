using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames.MenuEditor
{
    public interface IShoper
    {
        public abstract void OnSelect(GameObject selectedItem);
    }
}