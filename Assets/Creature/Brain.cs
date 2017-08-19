using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    interface Brain
    {
        void setInputs(float[] Inputs);
        void update();
        float[] getOutputs();
    }
}
