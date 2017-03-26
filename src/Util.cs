namespace Mhanxx.Util.IO
{
    public class Path
    {

    }
    public class File
    {
        public static void Move(string sourceFileName, string destinationFileName)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(sourceFileName, destinationFileName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        }

        public static void Copy(string sourceFileName, string destinationFileName)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(sourceFileName, destinationFileName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (System.IO.IOException)
            {
                destinationFileName = ResolveDuplicate(destinationFileName);
                Copy(sourceFileName, destinationFileName);
            }
       }

        public static void Delete(string file)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(file, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void Rename(string file, string newName)
        {
            try
            { 
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(file, newName);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        private static string ResolveDuplicate(string sourceDirectoryName)
        {
            if (System.IO.File.Exists(sourceDirectoryName))
            {
                sourceDirectoryName += " - Copy";
            }

            int index = 2;
            string tempPath = sourceDirectoryName + " ({0}) ";
            while (System.IO.File.Exists(sourceDirectoryName))
            {
                sourceDirectoryName = System.String.Format(tempPath, index);
                index++;
            }

            return sourceDirectoryName;
        }
    }

    public class Directory
    {
        public static void Copy(string sourceDirectoryName, string destinationDirectoryName)
        {
            try
            { 
                //stinationDirectoryName = ResolveDuplicate(destinationDirectoryName);
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(sourceDirectoryName, destinationDirectoryName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (System.IO.IOException)
            {
                destinationDirectoryName = ResolveDuplicate(destinationDirectoryName);
                Copy(sourceDirectoryName, destinationDirectoryName);
            }
            catch (System.InvalidOperationException)
            {
                Copy(sourceDirectoryName, System.IO.Directory.GetParent(destinationDirectoryName).FullName);
            }
        }

        public static void Move(string sourceDirectoryName, string destinationDirectoryName)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(sourceDirectoryName, destinationDirectoryName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (System.IO.IOException)
            {
                System.Windows.Forms.MessageBox.Show("Cannot move '" + System.IO.Path.GetFileName(destinationDirectoryName) + "'. The destination folder is the same as the source folder.", "List", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void Delete(string directory)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(directory, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void Rename(string directory, string newName)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(directory, newName);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        private static string ResolveDuplicate(string sourceDirectoryName)
        {
            if (System.IO.Directory.Exists(sourceDirectoryName))
            {
                sourceDirectoryName += " - Copy";
            }

            int index = 2;
            string tempPath = sourceDirectoryName + " ({0}) ";
            while (System.IO.Directory.Exists(sourceDirectoryName))
            {
                sourceDirectoryName = System.String.Format(tempPath, index);
                index++;
            }

            return sourceDirectoryName;
        }
    }
}