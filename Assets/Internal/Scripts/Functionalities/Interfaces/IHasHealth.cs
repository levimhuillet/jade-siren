using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{
    public interface IHasHealth
    {
        void HandleHealthZero(object sender, EventArgs args);
    }
}
