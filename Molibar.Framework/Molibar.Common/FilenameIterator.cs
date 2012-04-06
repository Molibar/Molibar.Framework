using System;

namespace Molibar.Common
{
    public class FilenameIterator
    {
        public static string Iterate(string filename)
        {
            return Iterate(filename, true);
        }

        /// <summary>
        /// This function iterates the sent in filename.
        /// <code>
        /// file - file.1
        /// file.2 - file.3
        /// file.txt - file.txt.1
        /// file.txt.1 - file.txt.2
        /// 
        /// If iterateAfterExtension is false:
        /// file - file.1
        /// file.2 - file.1.2 (seems stupid, but this is by design)
        /// file.txt - file.1.txt
        /// file.1.txt - file.2.txt)
        /// </code>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="iterateAfterExtension"></param>
        /// <returns></returns>
        public static string Iterate(string filename, bool iterateAfterExtension)
        {
            if (string.IsNullOrEmpty(filename)) throw new ArgumentException("Filename not set exception");
            var arr = filename.Split(new[] { '.' });
            var offset = (iterateAfterExtension || arr.Length == 1) ? 1 : 2;

            var sIdx = arr[arr.Length - offset];
            short idx;
            if (short.TryParse(sIdx, out idx))
            {
                arr[arr.Length - offset] = (++idx).ToString();
            }
            else
            {
                var tmp = new string[arr.Length + 1];
                Array.Copy(arr, 0, tmp, 0, (arr.Length - offset) + 1);
                tmp[tmp.Length - offset] = (1).ToString();
                Array.Copy(arr, (arr.Length - offset) + 1, tmp, (tmp.Length - offset) + 1, offset - 1);
                arr = tmp;
            }
            return string.Join(".", arr);
        }
    }
}
