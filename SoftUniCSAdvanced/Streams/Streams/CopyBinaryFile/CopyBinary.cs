using System;
using System.IO;

namespace CopyBinaryFile
{
    class CopyBinary
    {
        static void Main()
        {
            // ../../../
            // NOT WORKING
            using (var sourceFile = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                
                using (var copiedFile = new FileStream("../../../new.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var bytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (bytes<=0)
                        {
                            break;
                        }
                        copiedFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
