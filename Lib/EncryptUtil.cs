using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Math;
using System.Xml;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;

namespace Lib;

public class EncryptUtil
{
    public static class AES
    {
        public static string Encrypt(string Source, string Key)//, string Iv)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] key = Encoding.ASCII.GetBytes(Key);
                //byte[] iv = Encoding.ASCII.GetBytes(Iv);
                byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

                //aes.KeySize = Key.Length * 8;
                aes.Key = key;
                //aes.IV = iv;
                string encrypt = "";
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
                return encrypt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static byte[] EncryptByte(string Source, string Key)//, string Iv)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] key = Encoding.ASCII.GetBytes(Key);
                //byte[] iv = Encoding.ASCII.GetBytes(Iv);
                byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

                //aes.KeySize = Key.Length * 8;
                aes.Key = key;
                //aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static string Decrypt(string Encrypt, string Key)//, string Iv)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                byte[] key = Encoding.ASCII.GetBytes(Key);
                //byte[] iv = Encoding.ASCII.GetBytes(Iv);
                //aes.KeySize = Key.Length * 8;
                aes.Key = key;
                //aes.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(Encrypt);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// EBGS ECB加密 (轉為Hex String)
        /// Add by ted 2021
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="keyText"></param>
        /// <param name="ivText"></param>
        /// <returns></returns>
        public static string EBGSEncryptToHexString(string sourceText, string keyText)
        {
            string encrypt = string.Empty;

            try
            {
                byte[] sourceTextBytes = Encoding.UTF8.GetBytes(sourceText);

                RijndaelManaged rijnadeManage = new RijndaelManaged();
                rijnadeManage.Mode = CipherMode.ECB;
                rijnadeManage.Padding = PaddingMode.PKCS7;
                rijnadeManage.Key = Encoding.UTF8.GetBytes(keyText);
                ICryptoTransform crypt = rijnadeManage.CreateEncryptor();
                byte[] cipherBytes = crypt.TransformFinalBlock(sourceTextBytes, 0, sourceTextBytes.Length);
                encrypt = BToHex(cipherBytes);
                return encrypt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string EBGSDecrypt(string sourceText, string keyText)
        {
            try
            {
                byte[] sourceTextBytes = HexStringToByteArray(sourceText);

                RijndaelManaged rijnadeManage = new RijndaelManaged();
                rijnadeManage.Mode = CipherMode.ECB;
                rijnadeManage.Padding = PaddingMode.PKCS7;
                rijnadeManage.Key = Encoding.UTF8.GetBytes(keyText);
                ICryptoTransform crypt = rijnadeManage.CreateDecryptor();
                byte[] resultByte = crypt.TransformFinalBlock(sourceTextBytes, 0, sourceTextBytes.Length);
                return Encoding.UTF8.GetString(resultByte);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EBGS CBC加密 (轉為Hex String)
        /// Add by ted 2021
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="keyText"></param>
        /// <param name="ivText"></param>
        /// <returns></returns>
        public static string EBGSCBCEncryptToHexString(string sourceText, string keyText, string ivText)
        {
            string encrypt = string.Empty;

            try
            {
                byte[] sourceTextBytes = Encoding.UTF8.GetBytes(sourceText);

                RijndaelManaged rijnadeManage = new RijndaelManaged();
                rijnadeManage.Mode = CipherMode.CBC;
                rijnadeManage.Padding = PaddingMode.PKCS7;
                rijnadeManage.Key = HexStringToByteArray(keyText);
                rijnadeManage.IV = HexStringToByteArray(ivText);
                ICryptoTransform crypt = rijnadeManage.CreateEncryptor();
                byte[] cipherBytes = crypt.TransformFinalBlock(sourceTextBytes, 0, sourceTextBytes.Length);
                encrypt = BToHex(cipherBytes);
                return encrypt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string BToHex(byte[] Bdata)
        {
            return BitConverter.ToString(Bdata).Replace("-", "");
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
    public static class AESCBC
    {
        public static string Encrypt(string Source, string Key, string Iv)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                byte[] key = Encoding.ASCII.GetBytes(Key);
                byte[] iv = Encoding.ASCII.GetBytes(Iv);
                byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

                aes.KeySize = Key.Length * 8;
                aes.Key = key;
                aes.IV = iv;
                string encrypt = "";
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = BToHex(ms.ToArray()); //Convert.ToBase64String(ms.ToArray());
                }
                return encrypt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static byte[] EncryptByte(string Source, string Key, string Iv)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                byte[] key = Encoding.ASCII.GetBytes(Key);
                byte[] iv = Encoding.ASCII.GetBytes(Iv);
                byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

                //aes.KeySize = Key.Length * 8;
                aes.Key = key;
                aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static byte[] HexToByte(string hexString)
        {
            //運算後的位元組長度:16進位數字字串長/2
            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2)
            {
                //每2位16進位數字轉換為一個10進位整數
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteOUT;
        }

        public static string BToHex(byte[] Bdata)
        {
            return BitConverter.ToString(Bdata).Replace("-", "");
        }

        public static string Decrypt(string Encrypt, string Key, string Iv)
        {
            try
            {

                var encryptBytes = HexToByte(Encrypt);// Convert.FromBase64String(Encrypt);
                var aes = new RijndaelManaged();
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(Iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = aes.CreateDecryptor();

                return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    public static class RSA
    {

        public static string Encrypt222(string data, string publicKey)
        {

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            byte[] pubKeyBytes = Convert.FromBase64String(publicKey);
            rsa.ImportCspBlob(pubKeyBytes);
            byte[] resultBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
            String result = Convert.ToBase64String(resultBytes);

            return result;
        }
        public static string Encrypt(string data, string publicKey)
        {
            //string s = RsaEncryptWithPublic(data, publicKey);
            //return s;

            var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(RSAKeyConvert.RSAPublicKeyJava2DotNet(publicKey));
            var s = Convert.ToBase64String(rsa.Encrypt(Encoding.Default.GetBytes(data), false));
            return s;


            //var rsaParam = new RSAParameters();
            //rsaParam.Modulus = Convert.FromBase64String(publicKey);
            //rsaParam.Exponent = new byte[] { 1, 0, 1 }; ;
            //using (var rsa = new RSACryptoServiceProvider(2048))
            //{
            //    rsa.ImportParameters(rsaParam);
            //    byte[] dataEncoded = Encoding.UTF8.GetBytes(data);
            //    using (var ms = new MemoryStream())
            //    {
            //        var buffer = new byte[encryptionBufferSize];
            //        int pos = 0;
            //        int copyLength = buffer.Length;
            //        while (true)
            //        {
            //            if (pos + copyLength > dataEncoded.Length)
            //            {
            //                copyLength = dataEncoded.Length - pos;
            //            }
            //            buffer = new byte[copyLength];
            //            Array.Copy(dataEncoded, pos, buffer, 0, copyLength);
            //            pos += copyLength;
            //            ms.Write(rsa.Encrypt(buffer, false), 0, decryptionBufferSize);
            //            Array.Clear(buffer, 0, copyLength);
            //            if (pos >= dataEncoded.Length)
            //            {
            //                break;
            //            }

            //        }

            //        var res = Convert.ToBase64String(ms.ToArray());
            //        return res;
            //    }
            //}

            //var privatekey = "MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC+O6p3ahOL/cZfGerTTjI1gQicpYf56oDb+KkAZ4Kj+C+1kA9aBjqIbRMjiejr+/iT3efgjBBP/Q/cxs27pmVs1gx0m76Wp8SKcwxnjU6Z/mRXGOgl6PIKZ2rywCv2on00GlkHEFR30v8X0xBssKL67MS7qJPzSfI9ahQfUxoGeezlJ537RoDy5hen5us32h44CfNbOf5nE5MruvIjstsDlCAJX7XnCz/fCPl63jw18koD9xTBJZVnV5Ui9mQ1mOKcF9ORCd77PZK+Xw4ajqlADr1drke60W6fT3BWN2ETRb+KR/DMu/2AxeCt7Akzi9mEk5Aiv2KjGJmyOz6nAPHvAgMBAAECggEBAJd3AFqGHjwnekv8YcmPCFErhQTck7C8M49xpHZK9GzDzpDcvCxsqyw21LdGNiu2+wwY8mgKfW6Cyp95txNDAJywrUgnPY/M0qN9yRGmJEBemdvzW9vbZuQ7xZ60vgxpAhF7LQl/yhGB8VQx3HD+DzaFUHsuVWavqO2XSaBLVXxzMy6Cy0t98ECg1cYmtD1QYbyOzMHsEbSJyJ8AC/0X9TWfnYg8N0OjFpphMRvDDCwK2ZwFQw+h6rYdzuXtXjZqhwW4mEACf821fABrefRHUEcGoDPG4Y45bwonTTczW38P3rgj+iwAUr8YhCwyi+W61RtQL1OkL7xEBwJllRr93+ECgYEA/Mc7D0RcQ2EmOZSolkIEQ3jTVZbzWi6y1bbeyB2uxXBvo34gPuBDSmnrJw4yxxsIzMVJ00qNmDcGYBiSRheP26C3xwt2v4c8FF47cZg+OZU1oEyXkS1Y7OskW+yaYX7z1sOFalcrepPr7KVrXhP245PIWL2TYWLxaIJftVrrM78CgYEAwKhcl4O0fJlN5izPq5NdLmyI6HE6X5eU0kYRdoboGpc8KD1uH5tw5A76vx/gGCBMerRDsWJlU/YERC1JQbEZSx2A0jYD7Ctx1mtJwPE0BdfheOUxv5lI0GrsyBKeBTHXC2NgJ0rxkq5kTRfenOyOTxi8roJDD61LCzjkOi9lDdECgYBPf0zosUQfALen1kPq9ZonqiE0wsOH8jXWFqwb3ZHwkDrb/Teg7qDbD1KgNsvraGotFELyi3jajTuZD0E5gAGDPhluJQHUnHBdq4EgaZPwQifaYRwt0UgtQoptyoyG6wk+2sDjv8RxyYGiLCgHL1ovGnQgzIZEU3y+tHnrLEvaOwKBgQCWZBb7c6V1ylqD/qESJ5QKxFDPWmwd6P8Ucfv50W/oKfyc0O9hHv8uF/9nKOPPEY+CDav2EYBV3WsRKWTRMgUznNFNxzqipntTzSaixec9VHs+23NNRMQRZhZ2TAoste5PhoCty5PuU9IaWDK/vu2MExxfAXKGD1nQZdXLEepJsQKBgFGCiSLz4vvX/xPhgYaH5rY4aGqEBQEufKxKTVoNFePeQdLIpeW3gHDXmLoz/7fnDmmbfP/Fl5SObH/zFjUVLxtZ1H6r8JiWl9bjRwEszrsoiuN+NdBwYDRecw4yhPbBYqEL/GtuGKZIcsJLyZckgRrZ4WLYuovmfK0KaUX7wE0J";
            // return s;
        }
        //public static string pemtoder(string publicKey)
        //{
        //    bool success;
        //    string result;
        //    Chilkat.Dsa dsa = new Chilkat.Dsa();

        //    success = dsa.UnlockComponent("Anything for 30-day trial");
        //    if (success != true)
        //    {
        //        //MessageBox.Show(dsa.LastErrorText);
        //        result="";
        //    }

        //    //  Load a PEM private key.
        //    //pemPrivateKey = dsa.LoadText("dsa_priv.pem");
        //    //  Import the unencrypted PEM into the DSA object.
        //    success = dsa.FromPem(publicKey);
        //    result=Convert.ToBase64String(dsa.ToDer());
        //    return result;


        //}
        public static string Decrypt2(string data, string privateKey)
        {
            var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(PEMtoXMLPrivate(privateKey));
            return Convert.ToBase64String(rsa.Decrypt(Encoding.Default.GetBytes(data), false));

        }

        public static string Decrypt(string encryptContent, string privateKey, int decryptionBufferSize = 128)
        {
            try
            {
                var data = Convert.FromBase64String(encryptContent);
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKey);
                using (var ms = new MemoryStream(data.Length))
                {
                    byte[] buffer = new byte[decryptionBufferSize];
                    int pos = 0;
                    int copyLength = buffer.Length;
                    while (true)
                    {
                        Array.Copy(data, pos, buffer, 0, copyLength);
                        pos += copyLength;
                        byte[] resp = rsa.Decrypt(buffer, false);
                        ms.Write(resp, 0, resp.Length);
                        Array.Clear(resp, 0, resp.Length);
                        Array.Clear(buffer, 0, copyLength);
                        if (pos >= data.Length)
                        {
                            break;
                        }
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            catch (CryptographicException ce)
            {
                throw ce;
            }
        }

        private static string PEMtoXML(string pem)
        {
            pem = "-----BEGIN PUBLIC KEY-----\n" + pem + "\n-----END PUBLIC KEY-----";
            StreamReader reader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(pem)));
            AsymmetricKeyParameter keyPair = (AsymmetricKeyParameter)new PemReader(reader).ReadObject();
            //AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            //AsymmetricKeyParameter privateKey = keyPair.Private;
            System.Security.Cryptography.RSA rsa = DotNetUtilities.ToRSA((RsaKeyParameters)keyPair);
            string xmlRsa = rsa.ToXmlString(false);
            return xmlRsa;
        }
        private static string PEMtoXMLPrivate(string pem)
        {
            pem = "-----BEGIN RSA PRIVATE KEY-----\n" + pem + "\n-----END RSA PRIVATE KEY-----";
            StreamReader reader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(pem)));
            AsymmetricKeyParameter keyPair = (AsymmetricKeyParameter)new PemReader(reader).ReadObject();
            //AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            //AsymmetricKeyParameter privateKey = keyPair.Private;
            System.Security.Cryptography.RSA rsa = DotNetUtilities.ToRSA((RsaKeyParameters)keyPair);
            string xmlRsa = rsa.ToXmlString(false);
            return xmlRsa;
        }

        public static string RsaEncryptWithPublic(string clearText, string publicKey)
        {
            string pem = "-----BEGIN PUBLIC KEY-----\n" + publicKey + "\n-----END PUBLIC KEY-----";
            var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);

            var encryptEngine = new Pkcs1Encoding(new RsaEngine());

            using (var txtreader = new StringReader(pem))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                encryptEngine.Init(true, keyParameter);
            }

            var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
            return encrypted;

        }




        /// <summary>
        /// RSA密钥格式转换
        /// </summary>
        public class RSAKeyConvert
        {
            /// <summary>    
            /// RSA私钥格式转换，java->.net    
            /// </summary>    
            /// <param name="privateKey">java生成的RSA私钥</param>    
            /// <returns></returns>   
            public static string RSAPrivateKeyJava2DotNet(string privateKey)
            {
                RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
                return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                 Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
            }
            /// <summary>    
            /// RSA私钥格式转换，.net->java    
            /// </summary>    
            /// <param name="privateKey">.net生成的私钥</param>    
            /// <returns></returns>   
            public static string RSAPrivateKeyDotNet2Java(string privateKey)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(privateKey);
                BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
                BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
                BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
                BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
                BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
                BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
                BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
                BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));
                RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);
                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
                byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
                return Convert.ToBase64String(serializedPrivateBytes);
            }
            public static string RSAPublicKeyJava2DotNet(string publicKey)
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
                return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                    Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                    Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
            }
            /// <summary>    
            /// RSA公钥格式转换，.net->java    
            /// </summary>    
            /// <param name="publicKey">.net生成的公钥</param>    
            /// <returns></returns>   
            public static string RSAPublicKeyDotNet2Java(string publicKey)
            {
                XmlDocument doc = new XmlDocument(); doc.LoadXml(publicKey);
                BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
                BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
                RsaKeyParameters pub = new RsaKeyParameters(false, m, p);
                SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pub);
                byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
                return Convert.ToBase64String(serializedPublicBytes);
            }
        }
    }

}
