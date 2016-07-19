using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;
using xFid.BLL;
using xFid.Data;
using xFid.Models;

namespace xFid.Tests
{
    [TestFixture]
    public class EncryptionTests
    {
        public CipherOperations Ops = new CipherOperations();
        public StandardKernel Kernel = new StandardKernel();

        [Test]
        public void EncryptionTest()
        {
            var encrypt = new Encryption();
            string result = encrypt.Encrypt("Hello", Ops.Repo.GetCipher("default"));
            string expected = "JnË× ";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DecryptionTest()
        {
            var decrypt = new Encryption();
            string result = decrypt.Decrypt("JnË× ", Ops.Repo.GetCipher("default"));
            string expected = "Hello";
            Assert.AreEqual(expected, result);
        }
    }
}
