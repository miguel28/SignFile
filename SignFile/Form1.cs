using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace SignFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            byte[] buffer = new byte[] { 0x00, 0x00, 0x00 };

            RSACryptoServiceProvider csp = RSASignatures.ReadRSAPrivateKeyPem("private.pem");
            string signature = RSASignatures.Sign(buffer , csp);

            buffer = new byte[] { 0x00, 0x00, 0x01 };

            RSACryptoServiceProvider cspDec = RSASignatures.ReadRSAPublicKeyPem("public.pem");
            bool a = RSASignatures.Verify(buffer, signature, cspDec);
        }
    }
}
