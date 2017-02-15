using System;
using System.Collections;

namespace KAS_Hamming
{
    class Node
    {
        public Node left, right;
        public BitArray symptoms;
        public int possible_repair = -1;
        public byte value;
        public Node(){}
        public void compute_repair()
        {
            for (int i = 0; i < symptoms.Length - 1; i++)
            {
                possible_repair += (symptoms[i] ? (int)Math.Pow(2, i) : 0);
            }
        }
    }
}
