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
        Brain Brain;
        
        public Creature(GameObject controlling)
        {
            
            this.Controlling = controlling;

            this.Controlling.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1));
        }

        public void Move()
        {
            Rigidbody2D R = Controlling.GetComponent<Rigidbody2D>();
            R.AddForceAtPosition(new Vector2(0,0.5f),new Vector2(0.1f,0));
            R.AddForceAtPosition(new Vector2(0, -0.5f), new Vector2(-0.1f, 0));
        }
    }
}
