using System;
using System.IO;

namespace Beale_Cipher_Algorithm_CLI
{
    class Program
    {
        public static void usage()
        {
            Console.WriteLine("Usage:  Beale_Cipher-CLI <operation> <text> <path\\to\\source-book>");
            Console.WriteLine("\toperation\t \t encrypt/decrypt");
            Console.WriteLine("\ttext\t \t \t plaintext/hash");
            Console.WriteLine("EXAMPLES:");
            Console.WriteLine("\tBeale_Cipher-CLI encrypt \"example text\" res/file.txt");
            Console.WriteLine("\tBeale_Cipher-CLI decrypt \"20 12 7 4 2 1 2 4 2\" res/file.txt");
        }

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
                    B1.encrypt("bisha");
                    break;
                case "decrypt":
                    B1.decrypt("bisha");
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

        }


        public int encrypt(string plainTxt)
        {
            Console.WriteLine("Encrypt text");
            return 0;
        }

        public int decrypt(string plainTxt)
        {
            Console.WriteLine("Decrypt text");
            return 0;
        }

        private string mPath = null;
        private string MPath
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

        private string mBuffer = null;
        private string MBuffer
        {
            get { return mBuffer; }
            set { mBuffer = value; }
        }

        private string mOperation = null;

        private string MOperation
        {
            get { return mOperation; }
            set { mOperation = value; }
        }


    }

}
