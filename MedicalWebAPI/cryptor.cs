using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HRMS.Infrastructure.Utilities
{
    public static class Cryptor
    {
        private const string _alg = "HmacSHA256";
        private const string _salt = "947wM9yxgpFlR7trG8ky";
        private const string _aesKey = "HTKL7REMLO56482";
        private static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });
            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }
        /// <summary>
        /// Method for hasing password
        /// pass salt as null for alogirthm to auto generate a salt
        /// </summary>
        /// <param name="RawData"></param>
        /// <param name="Salt"></param>
        /// <returns></returns>
        public static dynamic Hash(string RawData, string Salt)
        {
            int MaxSaltlength = 16;
            int MinSaltlength = 4;
            byte[] SaltBytes = null;
            if (Salt != null)
            {
                SaltBytes = Convert.FromBase64String(Salt);
            }
            else
            {
                Random random = new Random();
                int Saltlength = random.Next(MinSaltlength, MaxSaltlength);
                SaltBytes = new byte[Saltlength];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(SaltBytes);
                rng.Dispose();

            }
            byte[] PlainData = ASCIIEncoding.UTF8.GetBytes(RawData);
            byte[] DataAndSalt = new byte[PlainData.Length + SaltBytes.Length];
            for (int i = 0; i < PlainData.Length; i++)
            {
                DataAndSalt[i] = PlainData[i];
            }
            for (int j = 0; j < SaltBytes.Length; j++)
            {
                DataAndSalt[PlainData.Length + j] = SaltBytes[j];
            }
            SHA256Managed sha256 = new SHA256Managed();
            byte[] HashValue = sha256.ComputeHash(DataAndSalt);
            dynamic result = new ExpandoObject();
            result.Hash = Convert.ToBase64String(HashValue);
            result.Salt = Convert.ToBase64String(SaltBytes);
            return result;
        }

        public static string GenerateToken(string MilitaryId, string password, string role, long ticks, string name, int UserId)
        {

            string hash = string.Join(":", new string[] { MilitaryId, role, "ip", "userAgent", ticks.ToString() });
            string hashLeft = string.Empty;
            string hashRight = string.Empty;
            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(password);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { MilitaryId, role, ticks.ToString(), name, UserId.ToString() });
            }
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", new string[] { hashLeft, hashRight })));
            return token;
        }

        public static string Encrypt(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
                return rawData;
            byte[] rawDataBytes = Encoding.Unicode.GetBytes(rawData);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_aesKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rawDataBytes, 0, rawDataBytes.Length);
                        cs.Close();
                    }
                    rawData = Convert.ToBase64String(ms.ToArray());
                }
            }
            return rawData;
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                if (string.IsNullOrEmpty(cipherText))
                    return cipherText;
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_aesKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception)
            {
                return cipherText;
            }
        }

        public static string Mask(string data, int startPosition, int numberofChars, char maskChar = '*')
        {
            if (string.IsNullOrEmpty(data) || data.Length < startPosition)
                return data;
            StringBuilder sb = new StringBuilder(data);
            int endposition = startPosition + numberofChars;
            while (startPosition < endposition && startPosition < sb.Length)
            {
                sb[startPosition] = maskChar;
                startPosition++;
            }
            return sb.ToString();
        }
    }
}
