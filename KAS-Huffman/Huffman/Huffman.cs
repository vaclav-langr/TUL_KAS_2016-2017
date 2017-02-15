using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KAS_Huffman
{
    class Huffman
    {
        #region Variables
        /// <summary>
        /// How many times a byte is in a file
        /// </summary>
        protected SortedList<byte, ulong> counts = new SortedList<byte, ulong>();
        /// <summary>
        /// Code of a byte
        /// </summary>
        protected Dictionary<byte, BitArray> encoding = new Dictionary<byte, BitArray>();
        /// <summary>
        /// Huffman tree, used for decoding
        /// </summary>
        Node tree;
        /// <summary>
        /// Powers to convert bits to byte
        /// </summary>
        byte[] powers = { 1, 2, 4, 8, 16, 32, 64, 128 };
        /// <summary>
        /// Queue for sequantial saving to a file
        /// </summary>
        Queue<bool> bit_queue = new Queue<bool>();
        /// <summary>
        /// Queue to save data from a file
        /// </summary>
        Queue<byte> byte_queue;
        /// <summary>
        /// BinaryWriter for saving to a file
        /// </summary>
        BinaryWriter bw;
        /// <summary>
        /// BinaryReader for reading a file
        /// </summary>
        BinaryReader br;
        #endregion
        #region Encode
        /// <summary>
        /// Function to encode input file to output file
        /// </summary>
        /// <param name="input_file">Input file name</param>
        /// <param name="output_file">Output file name</param>
        public Dictionary<byte, BitArray> encode(string input_file, string output_file)
        {
            BitArray ba;
            load_file(input_file);
            prepare_encoding();
            int unused_bits = count_unused_bits();

            write_counts_unused(output_file, unused_bits);
            while (byte_queue.Count > 0)
            {
                ba = encoding[byte_queue.Dequeue()];
                for (int i = 0; i < ba.Length; i++)
                {
                    bit_queue.Enqueue(ba[i]);
                }
                while (bit_queue.Count > 8) {
                    write_byte_to_file();
                }
            }
            for (int i = 0; i < unused_bits; i++ )
            {
                bit_queue.Enqueue(false);
            }
            write_byte_to_file();

            bw.Flush();
            bw.Close();
            return encoding;
        }
        /// <summary>
        /// Counts unused bits
        /// </summary>
        /// <returns>Total number of unused bits</returns>
        private int count_unused_bits()
        {
            ulong count = 0;
            int unused_bits;
            foreach (byte key in encoding.Keys)
            {
                count += counts[key] * (uint)encoding[key].Count;
            }
            unused_bits = (int)(8 - (count % 8));
            if (unused_bits == 8)
            {
                unused_bits = 0;
            }
            return unused_bits;
        }
        /// <summary>
        /// Reads file by bytes and counts their probability
        /// </summary>
        /// <param name="input_file">Input file name</param>
        private void load_file(string input_file)
        {
            br = new BinaryReader(File.OpenRead(input_file), Encoding.GetEncoding(1252));
            byte[] b = br.ReadBytes((int)new FileInfo(input_file).Length);
            for(int i = 0; i < b.Length; i++)
            {
                if (!counts.ContainsKey(b[i]))
                {
                    counts[b[i]] = 0;
                }
                counts[b[i]]++;
            }
            byte_queue = new Queue<byte>(b);
            br.Close();
        }
        /// <summary>
        /// Writes a byte from queue to file. Saves memory for another usage.
        /// </summary>
        private void write_byte_to_file()
        {
            byte b = 0;
            for (int j = 7; j >= 0; j--)
            {
                if (bit_queue.Dequeue())
                {
                    b += powers[j];
                }
            }
            bw.Write(b);
        }
        /// <summary>
        /// Writes bytes probabilities and total number of unused bits to output file.
        /// </summary>
        /// <param name="output_file">Output file name</param>
        /// <param name="unused_bits">Total number of unused bits</param>
        private void write_counts_unused(string output_file, int unused_bits)
        {
            bw = new BinaryWriter(File.Open(output_file, FileMode.Create), Encoding.GetEncoding(1252));
            for (int i = 0; i < 256; i++)
            {
                if (!counts.Keys.Contains((byte)i))
                {
                    bw.Write((ulong)0);
                }
                else
                {
                    bw.Write(counts[(byte)i]);
                }
            }
            bw.Write((Int32)unused_bits);
        }
        #endregion
        #region Functions
        /// <summary>
        /// Prepares encoding dictionary for faster encoding
        /// </summary>
        private void prepare_dictionary()
        {
            foreach(byte b in counts.Keys)
            {
                string s = encode_char(b, tree);
                encoding[b] = new BitArray(s.Length);
                for (int i = 0; i < s.Length; i++)
                {
                    encoding[b].Set(i, s[i] == '1');
                }
            }
        }
        /// <summary>
        /// Calculates encoding of a byte from a node
        /// </summary>
        /// <param name="b">Byte to be encoded</param>
        /// <param name="n">Current possition in Huffman tree</param>
        /// <returns>String of 0/1s</returns>
        private string encode_char(byte b, Node n)
        {
            StringBuilder s = new StringBuilder();
            while (n.is_leaf())
            {
                if (n.left.bytes.Contains(b))
                {
                    s.Append("0");
                    n = n.left;
                }
                else
                {
                    s.Append("1");
                    n = n.right;
                }
            }
            return s.ToString();
        }
        /// <summary>
        /// Gets node with lowest probability from list
        /// </summary>
        /// <param name="nodes">List of nodes sorted by their probability</param>
        /// <returns>Node with lowest probability</returns>
        private KeyValuePair<Node, ulong> get_lowest_probability(SortedList<ulong, Stack<Node>> nodes)
        {
            KeyValuePair<Node, ulong> result;
            result = new KeyValuePair<Node, ulong>(nodes[nodes.Keys[0]].Pop(), nodes.Keys[0]);
            if (nodes[result.Value].Count == 0)
            {
                nodes.Remove(result.Value);
            }
            return result;
        }
        /// <summary>
        /// Creates huffman encoding and encoding dictionary
        /// </summary>
        private void prepare_encoding()
        {
            SortedList<ulong, Stack<Node>> nodes = new SortedList<ulong, Stack<Node>>();
            foreach (byte b in counts.Keys)
            {
                if (!nodes.ContainsKey(counts[b]))
                {
                    nodes[counts[b]] = new Stack<Node>();
                }
                nodes[counts[b]].Push(new Node(b));
            }
            while (nodes.Count != 1 || nodes[nodes.Keys[0]].Count != 1)
            {
                KeyValuePair<Node, ulong> lowest = get_lowest_probability(nodes);
                KeyValuePair<Node, ulong> low = get_lowest_probability(nodes);
                Node n = new Node(lowest.Key, low.Key);
                if (!nodes.ContainsKey(lowest.Value + low.Value))
                {
                    nodes[lowest.Value + low.Value] = new Stack<Node>();
                }
                nodes[lowest.Value + low.Value].Push(n);
            }
            tree = nodes[nodes.Keys[0]].Pop();
            prepare_dictionary();
        }
        #endregion
        #region Decode
        /// <summary>
        /// Decodes input file to output file
        /// </summary>
        /// <param name="input_file">Input file name</param>
        /// <param name="output_file">Output file name</param>
        public Dictionary<byte, BitArray> decode(string input_file, string output_file)
        {
            bw = new BinaryWriter(File.Open(output_file, FileMode.Create), Encoding.GetEncoding(1252));
            int unused_bits = load_encoded_file(input_file);

            prepare_encoding();
            while (byte_queue.Count > 0 || bit_queue.Count > 0)
            {
                bw.Write(decode_char(unused_bits));
            }
            bw.Flush();
            bw.Close();
            return encoding;
        }
        /// <summary>
        /// Calculates next character by queue, if necessary reads next byte from data
        /// </summary>
        /// <param name="unused_bits">Total number of unused bits</param>
        /// <returns>Calculated character</returns>
        private byte decode_char(int unused_bits)
        {
            Node current = tree;
            do {
                while(bit_queue.Count == 0) {
                    read_next_byte(unused_bits);
                }
                if(bit_queue.Dequeue()){
                    current = current.right;
                } else {
                    current = current.left;
                }
            } while (current.is_leaf());
            return current.bytes[0];
        }
        /// <summary>
        /// Reads next byte from queue and saves as bits to queue, if necessary removes unused bits from last byte
        /// </summary>
        /// <param name="unused_bits">Total number of unused bites</param>
        private void read_next_byte(int unused_bits)
        {
            if (byte_queue.Count > 0) {
                byte b = byte_queue.Dequeue();
                int min = 0;
                if (byte_queue.Count == 0)
                {
                    min = unused_bits;
                }
                for (int i = 7; i >= min; i--)
                {
                    if (b >= powers[i])
                    {
                        bit_queue.Enqueue(true);
                        b -= powers[i];
                    }
                    else
                    {
                        bit_queue.Enqueue(false);
                    }
                }
            }
        }
        /// <summary>
        /// Reads data from input file and saves to variables
        /// </summary>
        /// <param name="input_file">Input file name</param>
        /// <returns>Total number of unused bits</returns>
        private int load_encoded_file(string input_file)
        {
            br = new BinaryReader(File.OpenRead(input_file), Encoding.GetEncoding(1252));
            read_probs();
            int unused = br.ReadInt32();
            byte_queue = new Queue<byte>(br.ReadBytes((int)new FileInfo(input_file).Length - 2052));
            br.Close();
            return unused;
        }
        /// <summary>
        /// Reads and parses probabilities of bytes
        /// </summary>
        private void read_probs()
        {
            for (int i = 0; i < 256; i++)
            {
                ulong c = br.ReadUInt64();
                if (c != 0)
                {
                    counts[(byte)i] = c;
                }
            }
        }
        #endregion
    }
}