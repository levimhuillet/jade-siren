using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{
    public interface IAffectsMovement
    {
        void MovementEffect(MovementAffectable toMove);
    }
}