using System;
using System.Collections;

namespace KAS_Hamming
{
    class Hamming
    {
        #region Variables
        BitArray[] H;
        BitArray[] G;
        BitArray[] R;
        BitArray[] encode_table = new BitArray[256];
        Node decode_tree = new Node();
        byte[] temp_value = new byte[1];
        public int one_error, two_error;
        #endregion
        #region Runs on another thread
        public Hamming()
        {
            #region H
            H = new BitArray[5];
            H[0] = new BitArray(new bool[] { false, true, false, true, false, true, false, true, false, true, false, true, false });               //s1
            H[1] = new BitArray(new bool[] { false, false, true, true, false, false, true, true, false, false, true, true, false });               //s2
            H[2] = new BitArray(new bool[] { false, false, false, false, true, true, true, true, false, false, false, false, true });              //s4
            H[3] = new BitArray(new bool[] { false, false, false, false, false, false, false, false, true, true, true, true, true });              //s8
            H[4] = new BitArray(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, });                     //sx
            #endregion
            #region G
            G = new BitArray[13];
            G[0] = new BitArray(new bool[] { false, false, false, false, false, false, false, false });                                            //px
            G[1] = new BitArray(new bool[] { true, true, false, true, true, false, true, false });                                                 //p1
            G[2] = new BitArray(new bool[] { true, false, true, true, false, true, true, false });                                                 //p2
            G[3] = new BitArray(new bool[] { true, false, false, false, false, false, false, false });                                             //d1

            G[4] = new BitArray(new bool[] { false, true, true, true, false, false, false, true });                                                //p4
            G[5] = new BitArray(new bool[] { false, true, false, false, false, false, false, false });                                             //d2
            G[6] = new BitArray(new bool[] { false, false, true, false, false, false, false, false });                                             //d3
            G[7] = new BitArray(new bool[] { false, false, false, true, false, false, false, false });                                             //d4

            G[8] = new BitArray(new bool[] { false, false, false, false, true, true, true, true });                                                //p8
            G[9] = new BitArray(new bool[] { false, false, false, false, true, false, false, false });                                             //d5
            G[10] = new BitArray(new bool[] { false, false, false, false, false, true, false, false });                                            //d6
            G[11] = new BitArray(new bool[] { false, false, false, false, false, false, true, false });                                            //d7

            G[12] = new BitArray(new bool[] { false, false, false, false, false, false, false, true });                                            //d8
            #endregion
            #region R
            R = new BitArray[8];
            R[0] = new BitArray(new bool[] { false, false, false, true, false, false, false, false, false, false, false, false, false });          //d1
            R[1] = new BitArray(new bool[] { false, false, false, false, false, true, false, false, false, false, false, false, false });          //d2
            R[2] = new BitArray(new bool[] { false, false, false, false, false, false, true, false, false, false, false, false, false });          //d3
            R[3] = new BitArray(new bool[] { false, false, false, false, false, false, false, true, false, false, false, false, false });          //d4

            R[4] = new BitArray(new bool[] { false, false, false, false, false, false, false, false, false, true, false, false, false });          //d5
            R[5] = new BitArray(new bool[] { false, false, false, false, false, false, false, false, false, false, true, false, false });          //d6
            R[6] = new BitArray(new bool[] { false, false, false, false, false, false, false, false, false, false, false, true, false });          //d7
            R[7] = new BitArray(new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, true });          //d8
            #endregion
            for (int i = 0; i < 256; i++ )
            {
                encode_table[i] = encode((byte)i);
            }
            gen_tree(decode_tree, 0, new BitArray(13));
        }
        private void gen_tree(Node n, int layer, BitArray ba)
        {
            if (layer < 13) {
                n.right = new Node();
                ba.Set(layer, true);
                gen_tree(n.right, layer + 1, ba);

                n.left = new Node();
                ba.Set(layer, false);
                gen_tree(n.left, layer + 1, ba);
            }
            else
            {
                n.symptoms = compute_symptoms(ba);
                n.compute_repair();
                mat_vec_mul(R, ba).CopyTo(temp_value, 0);
                n.value = temp_value[0];
            }
        }
        private BitArray mat_vec_mul(BitArray[] mat, BitArray vec)
        {
            BitArray output = new BitArray(mat.Length);

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    output[i] ^= (mat[i].Get(j) & vec[j]);
                }
            }

            return output;
        }
        private BitArray encode(byte input)
        {
            BitArray output = mat_vec_mul(G, new BitArray(new byte[]{input}));
            for (int i = 1; i < output.Length; i++)
            {
                output[0] ^= output[i];
            }
            return output;
        }
        private BitArray compute_symptoms(BitArray input)
        {
            return mat_vec_mul(H, input);
        }
        #endregion
        #region Encode
        public byte[] array_to_bytes(BitArray[] b)
        {
            bool[] temp_bools = new bool[1 + 3 * 13];
            b[0].CopyTo(temp_bools, 0);
            b[1].CopyTo(temp_bools, 13);
            b[2].CopyTo(temp_bools, 26);
            BitArray temp = new BitArray(temp_bools);
            byte[] output = new byte[5];
            temp.CopyTo(output, 0);
            return output;
        }
        public BitArray[] encode(params byte[] input)
        {
            BitArray[] output = new BitArray[input.Length];
            for(int i = 0; i < input.Length; i++) {
                output[i] = new BitArray(encode_table[input[i]]);
            }
            return output;
        }
        #endregion
        #region Decode
        public byte[] decode(BitArray input)
        {
            byte[] output = new byte[3];
            Node n;
            for (int i = 0; i < 3; i++ )
            {
                n = get_node(input, i * 13);
                    if (n.symptoms[n.symptoms.Length - 1])
                    { //Sx = 1
                        if (n.possible_repair == -1)
                        { //S = 0
                            one_error++;
                            input[i * 13] = !input[i * 13];
                            n = get_node(input, i * 13);
                        }
                        else
                        { //S > 0
                            one_error++;
                            input[i * 13 + n.possible_repair + 1] = !input[i * 13 + n.possible_repair + 1];
                            n = get_node(input, i * 13);
                        }
                    }
                    else
                    { //Sx = 0
                        if (n.possible_repair > -1)
                        { //S > 0
                            two_error++;
                            //throw new Exception("Dvoj a vicenasobna chyba");//dvoj a vícenásobná chyba
                        } //jinak bez chyby
                    }
                    output[i] = n.value;
                
            }
            return output;
        }
        private Node get_node(BitArray ba, int index)
        {
            Node current = decode_tree;
            do {
                if (ba.Get(index))
                {
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }
                index++;
            } while(current.symptoms == null);
            return current;
        }
        #endregion
    }
}
