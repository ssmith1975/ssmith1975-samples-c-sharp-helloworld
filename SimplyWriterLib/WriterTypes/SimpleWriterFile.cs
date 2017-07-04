using System;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace SimplyWriterLib {
    public class SimpleWriterFile : SimpleWriterBase {

        public SimpleWriterFile():this(@".\SimpleWriterFileOutput.txt") {

            // Create file in current directory the string fileName

        }

        public SimpleWriterFile(string fileName) {
            
           // // Get full path of file name
           FileName = Path.GetFullPath(fileName);
           setupTargetDirectory(fileName);

        }

        private string FileName {
            get; set;
        }

        public override void SimplyWrite() {


            // Create FileStream object
            using (Stream stream = new FileStream(FileName, FileMode.Create)) {

                // Write output to file
                WriteMemoryToStream(stream);
                stream.Flush();
                Console.WriteLine("Output file to selected directory {0}", FileName);
            }
               // Memory.Dispose();
        }
        private void setupTargetDirectory(string filename) {
           string filePathDirectory;
           string errorMsg;

            // Setup target directory
           filePathDirectory = Path.GetDirectoryName(filename);

            // Does target directory exists?
            if (!Directory.Exists(filePathDirectory)) {

                // Setup write permission on file
                if (HasWriteAccessToFile(filename)) {
                    Directory.CreateDirectory(filePathDirectory);
                } else {

                    // Setup error
                    errorMsg = String.Format("Not authorized to create file in {0} directory", filePathDirectory);

                    // Throw exception
                    throw new UnauthorizedAccessException(errorMsg);
                }

            }

        }

        //}
        // Method borrowed from StackOverflow 
        // (https://stackoverflow.com/questions/130617/how-do-you-check-for-permissions-to-write-to-a-directory-or-file)
        private static bool HasWriteAccessToFile(string filePath) {
            try {
                var permissionSet = new PermissionSet(PermissionState.None);
                var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filePath);

                permissionSet.AddPermission(writePermission);

                return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
            } catch (Exception ex) {

                return false;
            }
        }

    }
}
