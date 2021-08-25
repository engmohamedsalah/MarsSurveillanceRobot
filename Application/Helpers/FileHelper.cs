using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Application.Exceptions;

namespace Application.Helpers
{
    internal class FileHelper
    {
        public static void checkFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)
                || !File.Exists(filePath))
                throw new InvalidFilePathException(filePath);
        }
    }
}