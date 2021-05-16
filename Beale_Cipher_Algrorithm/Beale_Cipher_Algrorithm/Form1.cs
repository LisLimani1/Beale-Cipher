using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Beale_Cipher_Algrorithm
{
    public enum MsgBox_Codes
    {
        Error,
        Information,
        Question
    }


    public partial class Form1 : Form
    {
        Beale B1 = new Beale();
        public static void SendMsg(string msg, MsgBox_Codes code)
        {
            switch (code)
            {
                case MsgBox_Codes.Error:
                    MessageBox.Show(msg,"Something went wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                    break;
                case MsgBox_Codes.Information:
                    MessageBox.Show(msg, "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MsgBox_Codes.Question:
                    MessageBox.Show(msg, "Question message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        

        private void bookbtn_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog opdObj = new OpenFileDialog();
            if (opdObj.ShowDialog() == DialogResult.OK)
            {
               filePath = opdObj.FileName;
               Form1.SendMsg(filePath, MsgBox_Codes.Information);
                var fileStream = opdObj.OpenFile();
                StreamReader reader = new StreamReader(fileStream);
                B1.MBook = reader.ReadToEnd();
            }

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            B1.MBuffer = textBox1.Text;
            B1.encrypt();
            B1.decrypt();


        }
    }

    class Beale
    {
        public Beale()
        {
        }

        public int encrypt()
        {
            Random r = new Random();
            Console.Write("Encrypted text : ");
            for (int i = 0; i < MBuffer.Length; i++)
            {
                for (int j = 0; j < MBook.Length; j++)
                {
                    j = r.Next(0, MBook.Length);
                    if (MBuffer[i] == MBook[j])
                    {
                        Console.Write("{0} ", j);
                        break;
                    }
                }
            }
            return 0;
        }

        public int decrypt()
        {
            string[] ssize = MBuffer.Split(null);
            Console.Write("Decrypted text: ");
            for (int i = 0; i < ssize.Length; i++)
            {
                Console.Write("{0}", MBook[Convert.ToInt32(ssize[i])]);
            }
            return 0;
        }

        private string mPath = null;            // Path to source book variable
        private string MPath                    // get/set mPath property with error checking
        {
            get
            {
                if (File.Exists(mPath))
                {
                    Console.Write("File exists");
                    return mPath;
                }
                else
                {
                    Form1.SendMsg("Source book does not exist",MsgBox_Codes.Error);
                    return null;
                }
            }
            set
            {
                if (File.Exists(value))
                {
                    Console.WriteLine("File exists");
                    mPath = value;
                }
                else
                {
                    mPath = null;
                    Form1.SendMsg("Source book does not exist",MsgBox_Codes.Error);
                }
            }
        }
        private string mBuffer = null;          // Buffer that hold plaintext/encoded text(hash)
        public string MBuffer                  // set/get propert of mBuffer
        {
            get { return mBuffer; }
            set { mBuffer = value; }
        }

        private string mOperation = null;       // operation to do with the text
        public string MOperation               // set/get propert mOperation
        {
            get { return mOperation; }
            set { mOperation = value; }
        }

        private string mBook;            // Source book content
        public string MBook              // set/get property mBook
        {
            get { return mBook; }
            set { mBook = value; }
        }

    }

}
