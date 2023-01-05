using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class CryptCommand : CommandBase
    {
        private static readonly object myLock = new object();


        

        public override void Execute(object parameter)
        {

                int ThreadsNmbr = Process.GetCurrentProcess().Threads.Count;
                string[] FilePaths = Directory.GetFiles(@"C:\Users\Nico0\Desktop\oui\oui");
                Console.WriteLine("nombres de fichier " + FilePaths.Length + "\n\nnombres de threads " + ThreadsNmbr);
                Process[] myProcess = new Process[FilePaths.Length];
                Thread[] workerThreads = new Thread[ThreadsNmbr];

                int i = 0, k = 0, s = 0;

                while (k < FilePaths.Length)
                {
                    if (FilePaths.Length - k > ThreadsNmbr)
                    {
                        Console.WriteLine("\nboucle 1 " + k);
                        for (i = 0; i < ThreadsNmbr; i++)
                        {

                            workerThreads[i] = new Thread(() =>
                            {
                                lock (myLock)
                                {
                                    Console.WriteLine("\nId of current running " + "thread: {0}", Thread.CurrentThread.ManagedThreadId);
                                    Console.WriteLine("je gere le fichier numero " + s);
                                    myProcess[i] = new Process();
                                    myProcess[i].StartInfo.FileName = @"C:\Users\Nico0\Downloads\CryptoSoft_1\CryptoSoft\CryptoSoft\bin\Debug\netcoreapp3.1\CryptoSoft.exe";
                                    myProcess[i].StartInfo.ArgumentList.Add(FilePaths[s]);
                                    myProcess[i].StartInfo.ArgumentList.Add(@"C:\Users\Nico0\Desktop\oui\oui2\file" + s + "crypté.txt");
                                    myProcess[i].StartInfo.ArgumentList.Add("haha1234875");
                                    myProcess[i].Start();
                                    s = s + 1;
                                }
                            });
                            workerThreads[i].Start();

                        }

                        for (i = 0; i < ThreadsNmbr; i++)
                        {
                            workerThreads[i].Join();
                        }
                        k = k + ThreadsNmbr;
                        s = k;
                    }
                    else
                    {
                        s = k;
                        Console.WriteLine("\n\nje commence depuis " + s);

                        Enumerable.Range(0, FilePaths.Length - k).ToList().ForEach(f =>
                        {

                            new Thread(() =>
                            {
                                lock (myLock)
                                {
                                    Console.WriteLine("\nId of current running " + "thread: {0}", Thread.CurrentThread.ManagedThreadId);
                                    Console.WriteLine("je gere le fichier numero " + s);
                                    myProcess[i] = new Process();
                                    myProcess[i].StartInfo.FileName = @"C:\Users\Nico0\Downloads\CryptoSoft_1\CryptoSoft\CryptoSoft\bin\Debug\netcoreapp3.1\CryptoSoft.exe";
                                    myProcess[i].StartInfo.ArgumentList.Add(FilePaths[s]);
                                    myProcess[i].StartInfo.ArgumentList.Add(@"C:\Users\Nico0\Desktop\oui\oui2\file" + s + "crypté.txt");
                                    myProcess[i].StartInfo.ArgumentList.Add("haha1234875");
                                    myProcess[i].Start();
                                    i = i + 1;
                                    s = s + 1;
                                }
                            }).Start();
                            k = k + ThreadsNmbr;
                        });
                    }
                }
            
        }
    } 
}
