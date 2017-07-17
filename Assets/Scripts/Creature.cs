using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Creature
    {

        GameObject Controlling;

        public Creature(GameObject controlling)
        {
            this.Controlling = controlling;

            this.Controlling.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1));
        }

        public void Move()
        {

        }

    }
}
