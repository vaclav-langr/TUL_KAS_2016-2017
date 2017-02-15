using System;
using System.Security.Cryptography;
using System.IO;

namespace KAS_AES
{
    class Rijndael_KAS
    {
        private byte[] key;
        private SymmetricAlgorithm s;
        public Rijndael_KAS(byte[] key)
        {
            this.key = key;
            s = Rijndael.Create();
            s.KeySize = 128;
            s.BlockSize = 128;
            s.Mode = CipherMode.ECB;
            s.Padding = PaddingMode.None;
            s.Key = this.key;
        }

        internal void encrypt(string input, string output)
        {
            MemoryStream stream = new MemoryStream();
            BinaryReader br = new BinaryReader(File.Open(input, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(File.Open(output, FileMode.Create));
            CryptoStream cs = new CryptoStream(stream, s.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] plain = br.ReadBytes((int)(new FileInfo(input)).Length);
            byte unused = (byte)(plain.Length % 16);
            bw.Write((byte)(16 - unused));

            long length = (unused == 0 ? plain.Length / 16 : (plain.Length - unused) / 16);
            byte[] temp = new byte[16];
            int i;
            for (i = 0; i < length; i++) {
                Array.Copy(plain, i * 16, temp, 0, 16);
                cs.Write(temp, 0, 16);
            }
            if (unused != 0) {
                temp = new byte[16];
                Array.Copy(plain, i * 16, temp, 0, unused);
                cs.Write(temp, 0, 16);
            }
            cs.Flush();
            bw.Write(stream.ToArray());
            bw.Flush();
            cs.Close();
            bw.Close();
            br.Close();
        }

        internal void decrypt(string input, string output)
        {
            MemoryStream stream = new MemoryStream();
            BinaryReader br = new BinaryReader(File.Open(input, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(File.Open(output, FileMode.Create));
            CryptoStream cs = new CryptoStream(stream, s.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] ciphered = br.ReadBytes((int)(new FileInfo(input)).Length);
            byte unused = ciphered[0];
            byte[] temp = new byte[16];

            for (int i = 0; i < (ciphered.Length - 1) / 16; i++ ) {
                Array.Copy(ciphered, i * 16 + 1, temp, 0, 16);
                cs.Write(temp, 0, 16);
            }
            cs.Flush();
            stream.SetLength(stream.Length - unused);
            bw.Write(stream.ToArray());
            bw.Flush();
            cs.Close();
            bw.Close();
            bw.Close();
        }
    }
}
