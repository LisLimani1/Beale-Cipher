using System;
using System.IO;
using System.Linq;
namespace Beale_Cipher_Algorithm_CLI
{
    class Program
    {
        //  method that prints the usage information(how to use the tool)
        public static void usage()
        {
            Console.WriteLine("Usage:  Beale_Cipher-CLI <operation> <text> <path\\to\\source-book>");
            Console.WriteLine("\toperation\t \t encrypt/decrypt");
            Console.WriteLine("\ttext\t \t \t plaintext/hash");
            Console.WriteLine("EXAMPLES:");
            Console.WriteLine("\tBeale_Cipher-CLI encrypt \"example text\" res/file.txt");
            Console.WriteLine("\tBeale_Cipher-CLI decrypt \"20 12 7 4 2 1 2 4 2\" res/file.txt");
        }

        // error logging system
        public static void Error(string msg)
        {
            Console.WriteLine("ERROR:::" + msg);
            usage();
            // return -1;
            System.Environment.Exit(1);
        }

        static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Error("Bad number of arguments");
                return 1;
            }

            Beale B1 = new Beale(args[0], args[1], args[2]);

            switch (args[0])
            {
                case "encrypt":
                    B1.encrypt();
                    break;
                case "decrypt":
                    B1.decrypt();
                    break;
                default:
                    Error("second argument should be \"encrypt\" or \"decrypt\"");
                    break;

            }
            return 0;
        }
    }

    class Beale
    {
        public Beale(string operation, string plainTxt, string sourceBook)
        {
            this.MPath = sourceBook;
            this.MBuffer = plainTxt;
            this.MOperation = operation;

            mBook = File.ReadAllText(sourceBook);
            if (mBook.Length == 0)
            {
                Program.Error("Empty File!");
            }

        }

        public int encrypt()
        {
            Random r = new Random();
            Console.Write("Encrypted text : ");
            for (int i = 0; i < MBuffer.Length; i++)
            {
                for (int j = 0; j < mBook.Length; j++)
                {
                    j = r.Next(0, mBook.Length);
                    if (MBuffer[i] == mBook[j])
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
            string[] ssize = mBuffer.Split(null);
            Console.Write("Decrypted text: ");
            for (int i = 0; i < ssize.Length; i++)
            {
                Console.Write("{0}", mBook[Convert.ToInt32(ssize[i])]);
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
                    Program.Error("Source book does not exist");
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
                    Program.Error("Source book does not exist");
                }
            }
        }

        private string mBuffer = null;          // Buffer that hold plaintext/encoded text(hash)
        private string MBuffer                  // set/get propert of mBuffer
        {
            get { return mBuffer; }
            set { mBuffer = value; }
        }

        private string mOperation = null;       // operation to do with the text
        private string MOperation               // set/get propert mOperation
        {
            get { return mOperation; }
            set { mOperation = value; }
        }

        private string mBook;            // Source book content

    }

}
