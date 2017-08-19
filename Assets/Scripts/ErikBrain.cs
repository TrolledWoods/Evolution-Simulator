using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class ErikBrain : Brain
    {
        int InputAmount;
        int OutputAmount;
        int NeuronAmount;
        Neuron[] InputNeurons;
        Neuron[] BrainNeurons;
        Neuron[] OutputNeurons;
        Synaps[] Synapses;
        System.Random Rnd = WorldController.Rnd;
        ErikBrain()
        {
            InputAmount = 2;
            OutputAmount = 2;
            NeuronAmount = 3;
        }
        public void setInputs(float[] Inputs)
        {
            for (int i = 0; i < InputAmount; i++)
            {
                InputNeurons[i] = new Neuron();
            }
        }
        public void update()
        {

        }
        public float[] getOutputs()
        {
            return new float[4];
        }
        class Neuron
        {
            public float Input;//-1 <= x <= 1
            public float Scalar;//scales the input
            public float Output;//0 <= x <= 1
            public float Value;//same as output but is kept between frames
            public Neuron()
            {

            }
            public void update()
            {

            }

        }
        class Synaps
        {
            public Neuron Input;
            public Neuron Output;
            public float Scalar;//-1 <= x <= 1
            public Synaps(Neuron Input, Neuron Output)
            {
                this.Input = Input;
                this.Output = Output;
            }
            public void Update()
            {
                Output.Input += Input.Output * Scalar;
            }
        }
    }
}
